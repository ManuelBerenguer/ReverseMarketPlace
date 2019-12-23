using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Messages
{
    public interface IRejectedEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
