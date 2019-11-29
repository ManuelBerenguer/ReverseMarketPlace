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
    [Collection("Repository Collection")]
    public class FindGroupsForDemandHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FindGroupsForDemandHandler _findGroupsForDemandHandler;

        private readonly Mock<IStringLocalizer<FindGroupsForDemandHandler>> _localizer;
        private readonly Mock<ILogger<FindGroupsForDemandHandler>> _logger;
        private readonly IMapper _mapper;

        public FindGroupsForDemandHandlerTest()
        {
            _unitOfWork = RepositoryFactory.GetUnitOfWork();

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
        public async Task NotFoundDemandThrowsException()
        {
            FindGroupsForDemandCommand findGroupsForDemandCommand = new FindGroupsForDemandCommand(100000);

            await Assert.ThrowsAsync<DemandNotFoundException>(
                () => _findGroupsForDemandHandler.Handle(findGroupsForDemandCommand, CancellationToken.None)
            );
        }

        [Fact]
        public async Task NewGroupCreatedForDemandWithCategoryWithoutGroups()
        {
            FindGroupsForDemandCommand findGroupsForDemandCommand = new FindGroupsForDemandCommand(4); // The demand with the id 4 is the only one created on Demands tests

            var findGroupsForDemandResult = await _findGroupsForDemandHandler.Handle(findGroupsForDemandCommand, CancellationToken.None);

            Assert.IsType<FindGroupsForDemandResult>(findGroupsForDemandResult);
            // The list of groups should not be null
            Assert.NotNull(findGroupsForDemandResult.DemandGroups);
            // The list of groups should contain only one group (the group created just for the demand)
            Assert.True(findGroupsForDemandResult.DemandGroups.Count() == 1);
            // The group demands is not null cause our demand was added to the group
            Assert.NotNull(findGroupsForDemandResult.DemandGroups.First().Demands);
            // The group demands collection just contains our demand cause the group was created exclusively for us
            Assert.True(findGroupsForDemandResult.DemandGroups.First().Demands.Count() == 1);
            // We check the demand is the one with category 4 and 5 units
            Assert.Equal(findGroupsForDemandResult.DemandGroups.First().Demands.First(), _mapper.Map<DemandDto>(TestDemandFactory.FiveUnitsOfCategory4Buyer111()));            
        }

    }
}
