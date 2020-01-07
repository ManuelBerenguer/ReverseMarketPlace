using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.MessageBroker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Common.Extensions;

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
            // We get an instance of the command handler suppossed to handle the command type
            dynamic commandHandler = command.GetCommandHandler(_serviceProvider);

            // We run the command handler
            await commandHandler.HandleAsync((dynamic)command, CorrelationContext.Empty);
        }
    }
}
