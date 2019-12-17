using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.MessagesQueu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            await _serviceProvider.GetService(typeof(ICommandHandler<T>)).HandleAsync(command, CorrelationContext.Empty);
        }
    }
}
