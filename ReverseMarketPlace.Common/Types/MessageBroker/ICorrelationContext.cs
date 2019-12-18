using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.MessageBroker
{
    /// <summary>
    /// Metadata associated to the message published to the bus
    /// </summary>
    public interface ICorrelationContext
    {
        Guid Id { get; }
        Guid UserId { get; }
        Guid ResourceId { get; }
        string TraceId { get; }
        string SpanContext { get; }
        string ConnectionId { get; }
        string Name { get; }
        string Origin { get; }
        string Resource { get; }
        string Culture { get; }
        DateTime CreatedAt { get; }
        int Retries { get; set; }
    }
}
