using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Common.Types.Messages;
using System;


namespace ReversemarketPlace.Common.Infrastructure.RabbitMq.Implementations
{
    public class RabbitBusSubscriber : IBusSubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBusClient _busClient;

        public RabbitBusSubscriber(IApplicationBuilder app)
        {            
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _busClient = _serviceProvider.GetService<IBusClient>();
        }

        public IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null, Func<TCommand, ApplicationException, IRejectedEvent> onError = null) where TCommand : ICommand
        {
            _busClient.SubscribeAsync<TCommand, CorrelationContext>(async (command, correlationText) =>            
            {
                // We get an instance of the command handler suppossed to handle that command type
                //dynamic commandHandler = command.GetCommandHandler(_serviceProvider);

                // We get the type of the command
                Type commandType = command.GetType();

                // We build the type of command handler necessary for the command type
                // Dynamic objects expose members such as properties and methods at run time, instead of compile time. 
                // This enables you to create objects to work with structures that do not match a static type or format.
                Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);

                // We create a new scope because we are out of any http request scope and most of the services are declared as scoped dependencies
                using (var scope = _serviceProvider.CreateScope())
                {
                    // We get instance of that command handler type from the DI container
                    dynamic commandHandler = scope.ServiceProvider.GetRequiredService(commandHandlerType);

                    // We run the handler
                    await commandHandler.HandleAsync((dynamic)command, correlationText);
                }                  
                
            });

            return this;
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null, Func<TEvent, ApplicationException, IRejectedEvent> onError = null) where TEvent : IEvent
        {
            _busClient.SubscribeAsync<TEvent, CorrelationContext>(async (@event, correlationText) =>
            {
                // We get the command handler related to the command type
                var commandHandler = _serviceProvider.GetService<IEventHandler<TEvent>>();

                await commandHandler.HandleAsync(@event, correlationText);
            });

            return this;
        }
    }
}
