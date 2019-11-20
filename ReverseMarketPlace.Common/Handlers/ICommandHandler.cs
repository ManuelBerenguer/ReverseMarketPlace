using ReverseMarketPlace.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Handlers
{
    /// <summary>
    /// Prototype for any command handler built following the Command Query Responsability Segregation (CQRS).
    /// </summary>
    /// <typeparam name="T">Command to handle</typeparam>
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
