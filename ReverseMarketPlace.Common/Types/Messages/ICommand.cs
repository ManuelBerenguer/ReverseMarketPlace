using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Messages
{
    /// <summary>
    /// Marker interface (pattern). Empty interface only to mark some objects as commands. Obj A "is a" ICommand. 
    /// A command represents the user intention to do something. Has imperative name (DoSomething).
    /// The commands mutates the state of the application creating or editing domain entities. 
    /// It won't return any data.
    /// CQRS pattern -> https://www.youtube.com/watch?v=yqh0dN4oDTs&list=PLqqD43D6Mqz38LoZEuo_hJAp2NxXskcut&index=3
    /// We can use a message queue to enqueue the command.
    /// </summary>
    public interface ICommand : IMessage
    {

    }
}
