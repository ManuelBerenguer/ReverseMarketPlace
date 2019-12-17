using Microsoft.AspNetCore.Mvc;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.API.Controllers
{
    /// <summary>
    /// Shared things across all Controllers
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Dispatcher to dispatch commands or queries (CQRS)
        /// </summary>
        private readonly IDispatcher _dispatcher;

        public BaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Method to dispatch a command (CQRS write side)
        /// </summary>
        /// <param name="command">The command to be dispatched</param>
        /// <returns>Task</returns>
        protected async Task SendAsync(ICommand command)
            => await _dispatcher.SendAsync(command);

        /// <summary>
        /// Method to dispatch a query (CQRS read side)
        /// </summary>
        /// <typeparam name="TResult">Generic result type</typeparam>
        /// <param name="query">The query to be dispatched</param>
        /// <returns>Task of TResult</returns>
        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _dispatcher.QueryAsync<TResult>(query);
    }
}
