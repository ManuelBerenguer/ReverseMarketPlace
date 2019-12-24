using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using ReversemarketPlace.Demands.Tests.TestData;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Handlers.Demands;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Messages.Events;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Core.UseCases.Demands;
using ReverseMarketPlace.Demands.Core.UseCases.ProductTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ReversemarketPlace.Demands.Tests.Handlers
{
    public class CreateDemandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IAttributesBelongToProductTypeUseCase> _attributesBelongToProductTypeUseCase
            = new Mock<IAttributesBelongToProductTypeUseCase>();
        private readonly Mock<ICheckDuplicatedDemandUseCase> _checkDuplicatedDemandUseCase
            = new Mock<ICheckDuplicatedDemandUseCase>();
        private readonly Mock<IBusPublisher> _busPublisher = new Mock<IBusPublisher>();

        private readonly Mock<IStringLocalizer<CreateDemandHandler>> _localizerCreateDemand 
            = new Mock<IStringLocalizer<CreateDemandHandler>>();

        private readonly Mock<ILogger<CreateDemandHandler>> _loggerCreateDemand 
            = new Mock<ILogger<CreateDemandHandler>>();

        private readonly CreateDemandHandler _createDemandHandler;
        
        public CreateDemandHandlerTests()
        {
            _createDemandHandler = new CreateDemandHandler(_unitOfWork.Object, _attributesBelongToProductTypeUseCase.Object,
                _checkDuplicatedDemandUseCase.Object, _busPublisher.Object, _localizerCreateDemand.Object, _loggerCreateDemand.Object);
        }

        [Fact]
        public async Task T001_CreateDemandWithNonPositiveQuantityThrowsException()
        {
            CreateDemand createDemandCommand = new CreateDemand(Guid.Empty, TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(), 0, null);

            await Assert.ThrowsAsync<QuantityMustBeGreaterThanZeroException>(
                () => _createDemandHandler.HandleAsync(createDemandCommand, null)
            );
        }

        [Fact]
        public async Task T002_CreateDemandWithUnknownProductTypeThrowsException()
        {
            CreateDemand createDemandCommand = new CreateDemand(Guid.Empty, TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(), 1, null);

            // Set up the repository mock
            _unitOfWork.Setup(uw => uw.ProductTypesRepository.GetByIdAsync(createDemandCommand.ProductTypeId)).Returns(Task.FromResult<ProductType>(null));

            await Assert.ThrowsAsync<ProductTypeNotFoundException>(
                () => _createDemandHandler.HandleAsync(createDemandCommand, null)
            );
        }

        [Fact]
        public async Task T003_DemandWithAttributeNotBelongingProductTypeThrowsException()
        {            
            // Inches attribute with value 55
            var attributes = new Dictionary<Guid, object>() {
                { TestAttributeFactory.INCHES_ATTRIBUTE_GUID(), 55 } 
            };

            CreateDemand createDemandCommand = new CreateDemand(Guid.Empty, TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(), 1, attributes);

            // We mock to return a product type without attributes for televisions product type
            _unitOfWork.Setup(uw => uw.ProductTypesRepository.GetByIdAsync(createDemandCommand.ProductTypeId))
                .Returns(Task.FromResult<ProductType>(TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_WITHOUT_ATTRIBUTES()));

            // We mock to consider that one or more attributes don't belong to product type
            _attributesBelongToProductTypeUseCase.Setup(uc => uc.ExecuteAsync(It.IsAny<ProductType>(), It.IsAny<ICollection<Guid>>()))
                .Returns(Task.FromResult<bool>(false));

            await Assert.ThrowsAsync<ProductTypeAttributeNotFoundException>(
                () => _createDemandHandler.HandleAsync(createDemandCommand, null)
            );
        }

        [Fact]
        public async Task T004_DuplicatedDemandThrowsException()
        {
            CreateDemand createDemandCommand = new CreateDemand(Guid.Empty, TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(), 1, null);

            // We mock to return a product type without attributes for televisions product type
            _unitOfWork.Setup(uw => uw.ProductTypesRepository.GetByIdAsync(createDemandCommand.ProductTypeId))
                .Returns(Task.FromResult<ProductType>(TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_WITHOUT_ATTRIBUTES()));

            // We mock the GetBuyerDemands method from DemandsRepository
            _unitOfWork.Setup(uw => uw.DemandsRepository.GetBuyerDemands(createDemandCommand.BuyerId))
                .Returns(Task.FromResult<IEnumerable<Demand>>(new List<Demand>()));

            // We mock to consider the demand as duplicated
            _checkDuplicatedDemandUseCase.Setup(uc => uc.ExecuteAsync(It.IsAny<IEnumerable<Demand>>(), It.IsAny<Demand>()))
                .Returns(Task.FromResult<bool>(true));

            await Assert.ThrowsAsync<DuplicatedDemandException>(
                () => _createDemandHandler.HandleAsync(createDemandCommand, null)
            );
        }

        [Fact]
        public async Task T005_DemandCreatedSuccessfullyPublishEvent()
        {
            CreateDemand createDemandCommand = new CreateDemand(Guid.Empty, TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(), 1, null);

            // We mock to return a product type without attributes for televisions product type
            _unitOfWork.Setup(uw => uw.ProductTypesRepository.GetByIdAsync(createDemandCommand.ProductTypeId))
                .Returns(Task.FromResult<ProductType>(TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_WITHOUT_ATTRIBUTES()));

            // We mock the GetBuyerDemands method from DemandsRepository
            _unitOfWork.Setup(uw => uw.DemandsRepository.GetBuyerDemands(createDemandCommand.BuyerId))
                .Returns(Task.FromResult<IEnumerable<Demand>>(new List<Demand>()));

            // We mock to consider the demand as not duplicated
            _checkDuplicatedDemandUseCase.Setup(uc => uc.ExecuteAsync(It.IsAny<IEnumerable<Demand>>(), It.IsAny<Demand>()))
                .Returns(Task.FromResult<bool>(false));

            await _createDemandHandler.HandleAsync(createDemandCommand, null);

            // We setup the bus publisher mock to verify if it was called to publish the demand
            _busPublisher.Verify(bp => bp.PublishAsync(It.IsAny<DemandCreated>(), It.IsAny<ICorrelationContext>()), Times.Once());
        }
    }
}
