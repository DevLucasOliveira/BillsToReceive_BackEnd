using Bills.Domain.Clients.Commands;
using Bills.Domain.Clients.Handlers;
using Bills.Domain.Clients.Repositories;
using Bills.Domain.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bills.Api.Controllers
{
    [Route("v1/clients")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class ClientController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult CreateClient(
            [FromBody] CreateClientCommand command,
            [FromServices] ClientHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("{idUser}")]
        public IActionResult GetClientsOfUser(
            string idUser,
            [FromServices] IClientRepository repository)
        {
            return Ok(repository.GetClientsOfUser(new Guid(idUser)));
        }

        [HttpDelete]
        [Route("{idClient}")]
        public IActionResult DeleteClientById(
            string idClient,
            [FromServices] IClientRepository repository)
        {
            repository.Remove(new Guid(idClient));
            return Ok();
        }

    }
}
