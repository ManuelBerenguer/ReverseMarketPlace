using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Handlers;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    public class FindGroupsForDemandHandler : BaseCommandHandler<FindGroupsForDemandHandler>, IRequestHandler<FindGroupsForDemandCommand, FindGroupsForDemandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindGroupsForDemandHandler(IUnitOfWork unitOfWork, IStringLocalizer<FindGroupsForDemandHandler> localizer, 
            ILogger<FindGroupsForDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindGroupsForDemandResult> Handle(FindGroupsForDemandCommand request, CancellationToken cancellationToken)
        {
            // We get the demand by id and if the demand doesn't exist we throw exception
            var demand = await _unitOfWork.DemandsRepository.GetByIdAsync(request.Id);
            if (demand.IsNull())
                throw new DemandNotFoundException(_localizer[ExceptionConstants.DemandNotFound]);

            return null;
        }
    }
}
