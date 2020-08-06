using Bills.Domain.Clients.Commands;
using Bills.Domain.Clients.Handlers;
using Bills.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Api.Controllers
{
    [Route("v1/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult CreateClient(
            [FromBody] CreateClientCommand command,
            [FromServices] ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
