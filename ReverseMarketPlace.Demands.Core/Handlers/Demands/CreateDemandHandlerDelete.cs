using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    public class CreateDemandHandlerDelete : ICommandHandler<CreateDemand>
    {
        public CreateDemandHandlerDelete() { }

        public Task HandleAsync(CreateDemand command, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
