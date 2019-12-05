using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.MessagesQueu;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    // <summary>
    /// Handler for create demand commands
    /// </summary>
    public sealed class CreateDemandHandler : ICommandHandler<CreateDemand>
    {
        private readonly IDemandsRepository _demandsRepository;

        public CreateDemandHandler(IDemandsRepository demandsRepository)
        {
            _demandsRepository = demandsRepository;
        }

        public async Task HandleAsync(CreateDemand command, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
