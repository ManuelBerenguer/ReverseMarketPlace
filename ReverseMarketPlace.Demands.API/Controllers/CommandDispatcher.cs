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
            // We build the type of command handler necessary for the command T
            Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            ICommandHandler<T> commandHandler = _serviceProvider.GetRequiredService(commandHandlerType);

            // We get the handler for the T command
            //ICommandHandler<T> commandHandler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();

            // We run the handler
            await commandHandler.HandleAsync(command, CorrelationContext.Empty);
        }
    }
}
