using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.MessageBroker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ReverseMarketPlace.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispatches a new command finding the correct command handler and calling it's handle method to handle the command dispatched
        /// </summary>
        /// <typeparam name="T">Type of the command</typeparam>
        /// <param name="command">Command to be dispatched</param>
        /// <returns>Task</returns>
        public async Task SendAsync<T>(T command) where T : ICommand
        {
            // We get the handler for the T command
            ICommandHandler<T> commandHandler = _serviceProvider.GetService<ICommandHandler<T>>();

            // We run the handler
            await commandHandler.HandleAsync(command, CorrelationContext.Empty);
        }
    }
}
