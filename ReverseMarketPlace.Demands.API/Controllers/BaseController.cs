using Microsoft.AspNetCore.Mvc;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Common.Types.MessageBroker;
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
        private static readonly string OperationHeader = "X-Operation";
        private static readonly string ResourceHeader = "X-Resource";

        /// <summary>
        /// Dispatcher to dispatch commands or queries (CQRS). The commands or queries are handled immediately.
        /// </summary>
        private readonly IDispatcher _dispatcher;

        /// <summary>
        /// Bus Publisher to send commands to our bus. We publish the message to one queu and some subscriber will handle it at some point.
        /// </summary>
        private readonly IBusPublisher _busPublisher;

        public BaseController(IDispatcher dispatcher, IBusPublisher busPublisher)
        {
            _dispatcher = dispatcher;
            _busPublisher = busPublisher;
        }

        /// <summary>
        /// Method to dispatch a command (CQRS write side)
        /// </summary>
        /// <param name="command">The command to be dispatched</param>
        /// <returns>Task</returns>
        protected async Task SendAsync(ICommand command)
            => await _dispatcher.SendAsync(command);

        /// <summary>
        /// Method to publish a command to the bus. Some subscriber will handle the command. 
        /// </summary>
        /// <typeparam name="T">Type of the command</typeparam>
        /// <param name="command">Command to be sent to the bus</param>
        /// <param name="resourceId"></param>
        /// <param name="resource"></param>
        /// <returns>Http Accepted</returns>
        protected async Task<IActionResult> PublishAsync<T>(T command,
            Guid? resourceId = null, string resource = "") where T : ICommand
        {
            ICorrelationContext context = CorrelationContext.Empty; //GetContext<T>(resourceId, resource); TODO: Implement GetContext
            await _busPublisher.SendAsync(command, context);

            return Accepted(context);
        }

        protected IActionResult Accepted(ICorrelationContext context)
        {
            Response.Headers.Add(OperationHeader, $"operations/{context.Id}");
            if (!string.IsNullOrWhiteSpace(context.Resource))
            {
                Response.Headers.Add(ResourceHeader, context.Resource);
            }

            return base.Accepted();
        }

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
