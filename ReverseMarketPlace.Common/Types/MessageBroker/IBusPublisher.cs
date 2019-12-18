using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Types.MessageBroker
{
    public interface IBusPublisher
    {
        /// <summary>
        /// Sends a command to the bus
        /// </summary>
        /// <typeparam name="TCommand">Type of the command</typeparam>
        /// <param name="command">the command to be sent to the bus</param>
        /// <param name="context"></param>
        /// <returns>Task</returns>
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context)
            where TEvent : IEvent;
    }
}
