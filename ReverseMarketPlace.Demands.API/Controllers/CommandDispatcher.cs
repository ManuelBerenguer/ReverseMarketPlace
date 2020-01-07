using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.API.Controllers
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
            // We get the type of the command
            Type commandType = command.GetType();

            // We build the type of command handler necessary for the command T
            Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);

            // We get instance of that type from the DI container
            dynamic commandHandler = _serviceProvider.GetRequiredService(commandHandlerType);                      
            
            // We run the handler
            await commandHandler.HandleAsync((dynamic)command, CorrelationContext.Empty);
        }
    }
}
