using Bills.Domain.Account.Commands;
using Bills.Domain.Account.Handlers;
using Bills.Domain.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Api.Controllers
{
    [Route("v1/users")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public GenericCommandResult RegisterUser(
            [FromServices] UserHandler handler,
            [FromBody] RegisterUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPost]
        [Route("authenticate")]
        public GenericCommandResult AuthenticateUser(
            [FromServices] UserHandler handler,
            [FromBody] AuthenticateUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }




    }
}