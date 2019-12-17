using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;

namespace ReverseMarketPlace.Demands.API.Controllers
{
    [Route("api/[controller]")]    
    public class DemandsController : BaseController
    {
        public DemandsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDemand createDemandCommand)
        {
            await SendAsync(createDemandCommand);

            return AcceptedAtAction(nameof(Post));
        }

    }
}