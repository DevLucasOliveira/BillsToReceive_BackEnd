

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models;
using WebapiContas.Repository;

namespace WebapiContas.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {

        private readonly IOrdersRepository _orderRepository;

        public OrdersController(IOrdersRepository contasRepo)
        {
            _orderRepository = contasRepo;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
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
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();


            _orderRepository.Add(order);

            return CreatedAtRoute("GetOrder", new { id = order.IdOrder }, order);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
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

        [HttpDelete("clients/{idClient}")]
        public IActionResult DeleteOrdersOfClient(long idClient)
        {
            var orders = _orderRepository.GetAll().Where(w => w.IdClient == idClient);

            if (orders == null)
                return NotFound();

            foreach (var order in orders)
            {
                _orderRepository.Remove(order.IdOrder);
            }

            return new NoContentResult();

        }

        [HttpGet("clients/{idClient}")]
        public IActionResult GetByIdClient(long idClient)
        {
            var orders = _orderRepository.GetByIdClient(idClient);

            if (orders == null)
                return NotFound();


            return new ObjectResult(orders);
        }
    }
}
