using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Messages
{
    /// <summary>
    /// Marker interface (pattern). Empty interface only to mark some objects as events. Obj A "is a" IEvent. 
    /// </summary>
    public interface IEvent : IMessage
    {
    }
}
