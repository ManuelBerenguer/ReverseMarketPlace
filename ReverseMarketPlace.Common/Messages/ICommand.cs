using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Messages
{
    /// <summary>
    /// Marker interface (pattern). Empty interface only to mark some objects as commands. Obj A "is a" ICommand. 
    /// </summary>
    public interface ICommand : IMessage
    {

    }
}
