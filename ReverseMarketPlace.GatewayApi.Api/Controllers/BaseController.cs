using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Common.Types.Messages;

namespace ReverseMarketPlace.GatewayApi.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Bus Publisher to send commands to our bus
        /// </summary>
        private readonly IBusPublisher _busPublisher;

        protected BaseController(IBusPublisher busPublisher/*, ITracer tracer*/)
        {
            _busPublisher = busPublisher;
            //_tracer = tracer;
        }

        /// <summary>
        /// Send a command to the bus
        /// </summary>
        /// <typeparam name="T">Type of the command</typeparam>
        /// <param name="command">Command to be sent to the bus</param>
        /// <param name="resourceId"></param>
        /// <param name="resource"></param>
        /// <returns>Http Accepted</returns>
        protected async Task<IActionResult> SendAsync<T>(T command,
            Guid? resourceId = null, string resource = "") where T : ICommand
        {
            ICorrelationContext context = null; //GetContext<T>(resourceId, resource);
            await _busPublisher.SendAsync(command, context);

            return Accepted(context);
        }
    }
}