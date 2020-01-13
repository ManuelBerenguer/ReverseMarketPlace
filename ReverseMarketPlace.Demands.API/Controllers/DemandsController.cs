using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Common.Types.MessageBroker;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;

namespace ReverseMarketPlace.Demands.API.Controllers
{
    [Route("api/[controller]")]    
    public class DemandsController : BaseController
    {
        public DemandsController(IDispatcher dispatcher, IBusPublisher busPublisher) : base(dispatcher, busPublisher) {}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody, BindRequired] CreateDemand createDemandCommand)
            => await PublishAsync(createDemandCommand, createDemandCommand.Id, "demands");

        [HttpPost("Prueba")]
        public async Task<IActionResult> Prueba([FromBody] CreateDemand createDemandCommand)
        {
            await SendAsync(createDemandCommand);

            return AcceptedAtAction(nameof(Post));
        }
    }
}