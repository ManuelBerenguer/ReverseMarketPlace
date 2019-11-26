using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
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
    }
}
