using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using ReversemarketPlace.Demands.Tests.TestData;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Handlers.Demands;
using ReverseMarketPlace.Demands.Core.Mappers;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Core.UseCases.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ReversemarketPlace.Demands.Tests.Handlers
{
    //[Collection("Repository Collection")]
    public class CreateDemandHandlerTestOld : IClassFixture<RepositoryFactory>
    {
        private RepositoryFactory _repositoryFactory;
        
        private readonly Mock<IStringLocalizer<CreateDemandHandlerOld>> _localizerCreateDemand;
        private readonly Mock<ILogger<CreateDemandHandlerOld>> _loggerCreateDemand;
             
        private readonly Mock<IStringLocalizer<CheckDuplicateDemandHandler>> _localizerDuplicateDemand;
        private readonly Mock<ILogger<CheckDuplicateDemandHandler>> _loggerDuplicateDemand;

        private readonly CreateDemandHandlerOld _createDemandHandler;        
        private readonly CheckDuplicateDemandHandler _checkDuplicateDemandHandler;

        private readonly IAttributesBelongToCategoryUseCase _attributesBelongToCategoryUseCase;

        private readonly IMapper _mapper;

        public CreateDemandHandlerTestOld(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
                                    
            _localizerCreateDemand = new Mock<IStringLocalizer<CreateDemandHandlerOld>>();
            _loggerCreateDemand = new Mock<ILogger<CreateDemandHandlerOld>>();
            
            _localizerDuplicateDemand = new Mock<IStringLocalizer<CheckDuplicateDemandHandler>>();
            _loggerDuplicateDemand = new Mock<ILogger<CheckDuplicateDemandHandler>>();

            _attributesBelongToCategoryUseCase = new AttributesBelongToCategoryUseCase();

            // We create an instance of the autoMapper
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();
                        
            _checkDuplicateDemandHandler = new CheckDuplicateDemandHandler(_repositoryFactory.GetUnitOfWork(), _localizerDuplicateDemand.Object, _loggerDuplicateDemand.Object, _mapper);
            _createDemandHandler = new CreateDemandHandlerOld(_repositoryFactory.GetUnitOfWork(), _attributesBelongToCategoryUseCase, _checkDuplicateDemandHandler, _localizerCreateDemand.Object, _loggerCreateDemand.Object, _mapper);
        }

        //[Fact]
        public async Task T001_CreateDemandWithNonPositiveQuantityThrowsException()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1, 0, null);

            await Assert.ThrowsAsync<QuantityMustBeGreaterThanZeroException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        //[Fact]
        public async Task T002_CreateDemandWithUnknownCategoryThrowsException()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1000000000, 1, null);
                        
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        //[Fact]
        public async Task T003_UserCanNotCreateDuplicatedDemandWithoutAttributes()
        {
            // identical demand was created through SeedData.cs
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1, 1, new Dictionary<int, object>());
                                    
            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Created);
            Assert.NotNull(createDemandResult.Duplicated);
            Assert.Equal(createDemandResult.Duplicated, _mapper.Map<DemandDto>(await _repositoryFactory.GetUnitOfWork().DemandsRepository.GetByIdAsync(1)));
        }

        //[Fact]
        public async Task T004_UserCanCreateNotDuplicatedDemand()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 4, 5, null);
                        
            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Duplicated);
            Assert.NotNull(createDemandResult.Created);
            Assert.Equal(createDemandResult.Created, _mapper.Map<DemandDto>(TestDemandFactory.FiveUnitsOfCategory4Buyer111()));
        }

        //[Fact]
        public async Task T005_DemandWithAttributeNotBelongingCategoryThrowsException()
        {
            const int unknownAttributeId = 100; // Attribute that doesn't exist
            var attributes = new Dictionary<int, object>() {
                { unknownAttributeId, 55 } // fictional value of 55 
            };

            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 4, 5, attributes);
                        
            await Assert.ThrowsAsync<CategoryAttributeNotFoundException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        //[Fact]
        public async Task T006_CanCreateNotDuplicatedDemandWithAttributes()
        {
            const int inchesAttributeId = 1; // Existing attribute for category 4
            var attributes = new Dictionary<int, object>() {
                { inchesAttributeId, Convert.ToDouble( 55 ) } // 55 inches 
            };

            // There is already a category 4 demand created in a previous test but without attributes
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 4, 5, attributes);

            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Duplicated);
            Assert.NotNull(createDemandResult.Created);
            Assert.Equal(createDemandResult.Created, _mapper.Map<DemandDto>(TestDemandFactory.FiveUnitsOfCategory4Buyer111()));
        }
    }
}
