using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.MessageBroker
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(
            string @namespace = null,
            string queueName = null,
            Func<TCommand, ApplicationException, IRejectedEvent> onError = null
            ) where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(
            string @namespace = null,
            string queueName = null,
            Func<TEvent, ApplicationException, IRejectedEvent> onError = null
            )
            where TEvent : IEvent;
    }
}
