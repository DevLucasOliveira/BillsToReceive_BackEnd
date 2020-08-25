using Bills.Domain.Admin.Commands;
using Bills.Domain.Admin.Handlers;
using Bills.Domain.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Api.Controllers
{
    [ApiController]
    [Route("v1/admin")]
    [EnableCors("MyPolicy")]
    public class AdminController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public GenericCommandResult CreateAdmin(
            [FromServices] AdminHandler handler,
            [FromBody] CreateAdminCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [HttpPost]                
        [Route("keyaccess")]
        public GenericCommandResult CreateKeyAccess(
            [FromServices] KeyAccessHandler handler,
            [FromBody] CreateAccessKeyCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
