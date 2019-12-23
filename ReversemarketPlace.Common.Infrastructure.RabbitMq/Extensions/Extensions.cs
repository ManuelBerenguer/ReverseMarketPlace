using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Common;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Instantiation;
using ReversemarketPlace.Common.Infrastructure.RabbitMq.Implementations;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;
using System.Reflection;

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
                ClientConfiguration = options,
                DependencyInjection = ioc =>
                {
                    // We provide with implementation for NamingConvention
                    ioc.AddSingleton<INamingConventions>( new CustomNamingConventions(typeof(Extensions).Namespace) );
                }
                
            });

            // We can register implementation of publisher as singleton
            services.AddSingleton<IBusPublisher, RabbitBusPublisher>();
        }

        /// <summary>
        /// Implementation for NamingConventions of RawRabbit
        /// We can overwrite how exchange and queue will be called
        /// </summary>
        private class CustomNamingConventions : NamingConventions
        {
            public CustomNamingConventions(string defaultNamespace)
            {
                // We get the asembly name. For example -> 'reversemarketplace.demands.api'
                var assemblyName = Assembly.GetEntryAssembly().GetName().Name;

                // We overwrite how to get the name of the exchange. The exchange will be created automatically first time we connect and publish.
                // For us, the exchange's name will be the value of the MessageNamespace attribute added to the command class or the command class namespace in case 
                // the attribute was not specified. For example, 'demands'
                ExchangeNamingConvention = type => GetNamespace(type, defaultNamespace).ToLowerInvariant();

                // We overwrite how to get the routing key.
                // For us, the routing key will be namesapce.class_name. For example 'demands.create_demand'.
                // Pay attention that in RabbitMq the routing key should be created like '#.demands.create_demand'
                RoutingKeyConvention = type =>
                    $"{GetRoutingKeyNamespace(type, defaultNamespace)}{type.Name.Underscore()}".ToLowerInvariant();

                // We overwrite how to get the queue's name.
                // For us, the queue's name will be the assembly name of the command following the namespace and the class name of the command.
                // For example, 'reversemarketplace.demands.api/demands.create_demand'
                QueueNamingConvention = type => GetQueueName(assemblyName, type, defaultNamespace);

                ErrorExchangeNamingConvention = () => $"{defaultNamespace}.error";
                RetryLaterExchangeConvention = span => $"{defaultNamespace}.retry";
                RetryLaterQueueNameConvetion = (exchange, span) =>
                    $"{defaultNamespace}.retry_for_{exchange.Replace(".", "_")}_in_{span.TotalMilliseconds}_ms".ToLowerInvariant();
            }

            private static string GetRoutingKeyNamespace(Type type, string defaultNamespace)
            {
                var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

                return string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";
            }

            private static string GetNamespace(Type type, string defaultNamespace)
            {
                var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

                return string.IsNullOrWhiteSpace(@namespace) ? type.Name.Underscore() : $"{@namespace}";
            }

            private static string GetQueueName(string assemblyName, Type type, string defaultNamespace)
            {
                var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;
                var separatedNamespace = string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";

                return $"{assemblyName}/{separatedNamespace}{type.Name.Underscore()}".ToLowerInvariant();
            }
        }
    }
}
