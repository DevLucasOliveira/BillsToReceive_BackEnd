using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models.Entities;

namespace WebapiContas.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly IOrderRepository _ordersRepository;


        public OrderController(IOrderRepository contasrepos)
        {
            _ordersRepository = contasrepos;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _ordersRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrders")]
        public IActionResult GetById(long id)
        {
            var orders = _ordersRepository.Find(id);
            if (orders == null)
                return NotFound();

            return new ObjectResult(orders);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order orders)
        {
            if (orders == null)
                return BadRequest();

            _ordersRepository.Add(orders);

            return CreatedAtRoute("GetOrders", new { id = orders.IdOrder }, orders);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order orders)
        {
            if (orders == null)
                return NotFound();

            _ordersRepository.Update(orders);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _ordersRepository.Remove(id);
            return new NoContentResult();
        }

        [HttpDelete("client/{idClient}")]
        public IActionResult DeleteOrdersOfClient(long idClient)
        {
            var orders = _ordersRepository.GetAll().Where(w => w.IdClient == idClient);

            if (orders == null)
                return NotFound();

            foreach (var order in orders)
            {
                _ordersRepository.Remove(order.IdClient);
            }

            return new NoContentResult();
        }

        [HttpGet("client/{idClient}")]
        public IActionResult GetByIdClient(long idClient)
        {
            var orders = _ordersRepository.GetByIdClient(idClient);

            if (orders == null)
                return NotFound();

            return new ObjectResult(orders);
        }


    }
}
