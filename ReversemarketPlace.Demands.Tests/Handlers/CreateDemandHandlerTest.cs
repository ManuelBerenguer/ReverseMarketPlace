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
    public class CreateDemandHandlerTest
    {
        // We mock repositories
        private readonly Mock<IDemandsRepository> _demandsRepository;
        private readonly Mock<IRepository<Category>> _categoriesRepository;

        private readonly Mock<IStringLocalizer<CreateDemandHandler>> _localizer;
        private readonly Mock<ILogger<CreateDemandHandler>> _logger;

        private readonly CreateDemandHandler _createDemandHandler;

        private readonly IMapper _mapper;

        public CreateDemandHandlerTest()
        {
            _demandsRepository = new Mock<IDemandsRepository>();
            _categoriesRepository = new Mock<IRepository<Category>>();
            _localizer = new Mock<IStringLocalizer<CreateDemandHandler>>();
            _logger = new Mock<ILogger<CreateDemandHandler>>();            

            // We create an instance of the autoMapper
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _createDemandHandler = new CreateDemandHandler(_demandsRepository.Object, _categoriesRepository.Object, _localizer.Object, _logger.Object, _mapper);
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
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 100, 1);

            _categoriesRepository.Setup(repo => repo.GetByIdAsync(100)).Returns(Task.FromResult<Category>(null));

            await Assert.ThrowsAsync<CategoryNotFoundException>(
                () => _createDemandHandler.Handle(createDemandCommand, CancellationToken.None)
            );
        }

        [Fact]
        public async Task UserCannotCreateDuplicatedDemand()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 1, 1);

            _categoriesRepository.Setup(repo => repo.GetByIdAsync(1)).Returns(Task.FromResult<Category>( TestCategoryFactory.Category1() ));

            IEnumerable<Demand> buyerDemands = new List<Demand>() { TestDemandFactory.OneUnitOfCategory1Buyer111(), TestDemandFactory.ThreeUnitsOfCategory2Buyer111() };
            _demandsRepository.Setup(repo => repo.GetBuyerDemands("111")).Returns(Task.FromResult( buyerDemands ));

            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Created);
            Assert.NotNull(createDemandResult.Duplicated);
            Assert.Equal(createDemandResult.Duplicated, _mapper.Map<DemandDto>(TestDemandFactory.OneUnitOfCategory1Buyer111()));
        }

        [Fact]
        public async Task UserCanCreateNotDuplicatedDemand()
        {
            CreateDemandCommand createDemandCommand = new CreateDemandCommand("111", 3, 5);

            _categoriesRepository.Setup(repo => repo.GetByIdAsync(3)).Returns(Task.FromResult<Category>(TestCategoryFactory.Category3()));

            IEnumerable<Demand> buyerDemands = new List<Demand>() { TestDemandFactory.OneUnitOfCategory1Buyer111(), TestDemandFactory.ThreeUnitsOfCategory2Buyer111() };
            _demandsRepository.Setup(repo => repo.GetBuyerDemands("111")).Returns(Task.FromResult(buyerDemands));

            var createDemandResult = await _createDemandHandler.Handle(createDemandCommand, CancellationToken.None);

            Assert.IsType<CreateDemandResult>(createDemandResult);
            Assert.Null(createDemandResult.Duplicated);
            Assert.NotNull(createDemandResult.Created);
            Assert.Equal(createDemandResult.Created, _mapper.Map<DemandDto>(TestDemandFactory.FiveUnitsOfCategory3Buyer111()));
        }
    }
}
