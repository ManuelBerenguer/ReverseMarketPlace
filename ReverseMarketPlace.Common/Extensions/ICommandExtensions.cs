using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Extensions
{
    public static class ICommandExtensions
    {
        public static dynamic GetCommandHandler(this ICommand command, IServiceProvider serviceProvider)
        {
            // We get the type of the command
            Type commandType = command.GetType();

            // We build the type of command handler necessary for the command type
            // Dynamic objects expose members such as properties and methods at run time, instead of compile time. 
            // This enables you to create objects to work with structures that do not match a static type or format.
            Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);

            // We get instance of that command handler type from the DI container
            dynamic commandHandler = serviceProvider.GetRequiredService(commandHandlerType);

            return commandHandler;
        }
    }
}
