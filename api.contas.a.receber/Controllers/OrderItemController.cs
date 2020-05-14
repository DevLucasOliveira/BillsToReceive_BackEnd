using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : Controller
    {

        private readonly IOrderItemRepository _orderRepository;

        public OrderItemController(IOrderItemRepository contasRepo)
        {
            _orderRepository = contasRepo;
        }

        [HttpGet]
        public IEnumerable<OrderItem> GetAll()
        {
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetById(long id)
        {
            var order = _orderRepository.Find(id);
            if (order == null)
                return NotFound();


            return new ObjectResult(order);
        }


        [HttpPost]
        public IActionResult Create([FromBody] OrderItem order)
        {
            if (order == null)
                return BadRequest();


            _orderRepository.Add(order);

            return CreatedAtRoute("GetOrder", new { id = order.IdOrder }, order);
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderItem order)
        {

            if (order == null)
                return NotFound();


            _orderRepository.Update(order);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _orderRepository.Remove(id);
            return new NoContentResult();
        }

        [HttpDelete("orders/{idOrder}")]
        public IActionResult DeleteOrderOfOrder(long idOrder)
        {
            var orders = _orderRepository.GetAll().Where(w => w.IdOrder == idOrder);

            if (orders == null)
                return NotFound();

            foreach (var order in orders)
            {
                _orderRepository.Remove(order.IdOrder);
            }

            return new NoContentResult();

        }

        [HttpGet("orders/{idOrder}")]
        public IActionResult GetByIdOrder(long idOrder)
        {
            var orders = _orderRepository.GetByIdOrderItem(idOrder);

            if (orders == null)
                return NotFound();


            return new ObjectResult(orders);
        }
    }
}
