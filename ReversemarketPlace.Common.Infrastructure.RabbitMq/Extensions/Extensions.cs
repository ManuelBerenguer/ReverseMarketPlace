using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Common.Infrastructure.RabbitMq.Extensions
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfigurationSection section)
        {
            // RabbitMQ Configuration
            var options = new RawRabbitConfiguration();
            section.Bind(options);

            // Creates a new RawRabbit client
            var client = BusClientFactory.CreateDefault(options);
        }
    }
}
