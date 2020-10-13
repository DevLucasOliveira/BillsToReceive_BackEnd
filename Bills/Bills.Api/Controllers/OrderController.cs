using Bills.Domain.Commands;
using Bills.Domain.Orders.Commands;
using Bills.Domain.Orders.Handlers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Api.Controllers
{
    [Route("v1/orders")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult CreateOrder(
            [FromBody]CreateOrderItemCommand command,
            [FromServices]OrderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
