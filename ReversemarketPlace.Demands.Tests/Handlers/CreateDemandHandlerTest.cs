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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ReversemarketPlace.Demands.Tests.Handlers
{
    [Collection("Repository Collection")]
    public class CreateDemandHandlerTest
    {
        private readonly IDemandsRepository _demandsRepository;
        private readonly IRepository<Category> _categoriesRepository;

        private readonly Mock<IStringLocalizer<CreateDemandHandler>> _localizer;
        private readonly Mock<ILogger<CreateDemandHandler>> _logger;

        private readonly CreateDemandHandler _createDemandHandler;

        private readonly IMapper _mapper;

        public CreateDemandHandlerTest()
        {
            // We create new in-memory database context
            //RepositoryFactory.CreateNewContext();

            _demandsRepository = RepositoryFactory.GetDemandsRepository();
            _categoriesRepository = RepositoryFactory.GetCategoryRepository();
                        
            _localizer = new Mock<IStringLocalizer<CreateDemandHandler>>();
            _logger = new Mock<ILogger<CreateDemandHandler>>();            

            // We create an instance of the autoMapper
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _createDemandHandler = new CreateDemandHandler(_demandsRepository, _categoriesRepository, _localizer.Object, _logger.Object, _mapper);
        }

        [Fact]
        public async Task CreateDemandWithNonPositiveQuantityThrowsException()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1, 0);

            await Assert.ThrowsAsync<QuantityMustBeGreaterThanZeroException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        [Fact]
        public async Task CreateDemandWithUnknownCategoryThrowsException()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1000000000, 1);
                        
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        [Fact]
        public async Task UserCannotCreateDuplicatedDemand()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1, 1);

            IEnumerable<Demand> buyerDemands = await _demandsRepository.GetBuyerDemands(createDemandCommand.BuyerReference);
            
            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Created);
            Assert.NotNull(createDemandResult.Duplicated);
            Assert.Equal(createDemandResult.Duplicated, _mapper.Map<DemandDto>(await _demandsRepository.GetByIdAsync(1)));
        }

        [Fact]
        public async Task UserCanCreateNotDuplicatedDemand()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 4, 5);

            IEnumerable<Demand> buyerDemands = await _demandsRepository.GetBuyerDemands(createDemandCommand.BuyerReference);

            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Duplicated);
            Assert.NotNull(createDemandResult.Created);
            Assert.Equal(createDemandResult.Created, _mapper.Map<DemandDto>(TestDemandFactory.FiveUnitsOfCategory4Buyer111()));
        }
    }
}
