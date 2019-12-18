using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Dispatchers
{
    /// <summary>
    /// Type use to dispatch commands or queries
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Dispatch a command
        /// </summary>        
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Dispatch a query
        /// </summary>
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
