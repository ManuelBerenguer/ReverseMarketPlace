using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using ReversemarketPlace.Demands.Tests.TestData;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Handlers.Demands;
using ReverseMarketPlace.Demands.Core.Mappers;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ReversemarketPlace.Demands.Tests.Handlers
{
    //[Collection("Repository Collection")]
    public class FindGroupsForDemandHandlerTest : IClassFixture<RepositoryFactory>
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FindGroupsForDemandHandler _findGroupsForDemandHandler;

        private readonly Mock<IStringLocalizer<FindGroupsForDemandHandler>> _localizer;
        private readonly Mock<ILogger<FindGroupsForDemandHandler>> _logger;
        private readonly IMapper _mapper;

        public FindGroupsForDemandHandlerTest(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = _repositoryFactory.GetUnitOfWork();

            _localizer = new Mock<IStringLocalizer<FindGroupsForDemandHandler>>();
            _logger = new Mock<ILogger<FindGroupsForDemandHandler>>();

            // We create an instance of the autoMapper
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _findGroupsForDemandHandler = new FindGroupsForDemandHandler(_unitOfWork, _localizer.Object, _logger.Object, _mapper);
        }

        [Fact]
        public async Task T001_NotFoundDemandThrowsException()
        {
            FindGroupsForDemandCommand findGroupsForDemandCommand = new FindGroupsForDemandCommand(100000);

            await Assert.ThrowsAsync<DemandNotFoundException>(
                () => _findGroupsForDemandHandler.Handle(findGroupsForDemandCommand, CancellationToken.None)
            );
        }

        [Fact]
        public async Task T002_NewGroupCreatedForDemandWithCategoryWithoutGroups()
        {
            SeedData.PopulateDemandCategory4WithInchesAttribute(_repositoryFactory.GetDbContext());

            FindGroupsForDemandCommand findGroupsForDemandCommand = new FindGroupsForDemandCommand(4);

            var findGroupsForDemandResult = await _findGroupsForDemandHandler.Handle(findGroupsForDemandCommand, CancellationToken.None);

            Assert.IsType<FindGroupsForDemandResult>(findGroupsForDemandResult);
            // The list of suitable groups should be null cause the category does not have any group yet
            Assert.Null(findGroupsForDemandResult.SuitableDemandGroups);
            // The list of groups where the demand is already included shouls be not null (on group was created for the demand)
            Assert.NotNull(findGroupsForDemandResult.DemandGroups);
            // The list of groups where the demand is already included should contain only one group (the group created just for the demand)
            Assert.True(findGroupsForDemandResult.DemandGroups.Count() == 1);
            // The group demands is not null cause our demand was added to the group
            Assert.True(findGroupsForDemandResult.DemandGroups.First().NumberOfDemands == 1);            
        }

    }
}
