using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Messages
{
    public interface IAuthenticatedCommand : ICommand
    {
        string UserReference { get; }
    }
}
