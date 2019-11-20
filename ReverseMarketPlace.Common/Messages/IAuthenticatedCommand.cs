using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Messages
{
    public interface IAuthenticatedCommand : ICommand
    {
        string UserReference { get; }
    }
}
