using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Instantiation;
using ReversemarketPlace.Common.Infrastructure.RabbitMq.Implementations;
using ReverseMarketPlace.Common.Types.MessageBroker;
using System;
using System.Collections.Generic;

namespace ReversemarketPlace.Common.Infrastructure.RabbitMq.Extensions
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfigurationSection section)
        {
            // RabbitMQ Configuration
            var options = new RawRabbit.Configuration.RawRabbitConfiguration()
            {
                Username = "jyqunqga",
                Password = "CMMQKPRvniurdFHvEHPtuw_d31CW2kHj",
                VirtualHost = "jyqunqga",
                Port = 5672,
                Hostnames = new List<string> { "stingray.rmq.cloudamqp.com" },
                RequestTimeout = TimeSpan.FromSeconds(10),
                PublishConfirmTimeout = TimeSpan.FromSeconds(1),
                RecoveryInterval = TimeSpan.FromSeconds(1),
                PersistentDeliveryMode = true,
                AutoCloseConnection = true,
                AutomaticRecovery = true,
                TopologyRecovery = true,
                Exchange = new RawRabbit.Configuration.GeneralExchangeConfiguration
                {
                    Durable = true,
                    AutoDelete = false,
                    Type = RawRabbit.Configuration.Exchange.ExchangeType.Topic
                },
                Queue = new RawRabbit.Configuration.GeneralQueueConfiguration
                {
                    Durable = true,
                    AutoDelete = false,
                    Exclusive = false,
                    
                }
            };
            
            /* This creates the RawRabbit client as a singleton instance of IBusClient*/
            services.AddRawRabbit(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            // We can register implementation of publisher as singleton
            services.AddSingleton<IBusPublisher, RabbitBusPublisher>();
        }
    }
}
