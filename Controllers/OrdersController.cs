

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebapiContas.Interfaces;
using WebapiContas.Models;
using WebapiContas.Repository;

namespace WebapiContas.Controllers
{

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

        [HttpGet("{id}", Name="GetOrder")]
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
            if(order == null)
                return BadRequest();
            

            _orderRepository.Add(order);

            return CreatedAtRoute("GetOrder", new { id = order.IdOrder }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Order order)
        {
            if (order == null || order.IdOrder != id)
                return BadRequest();

            var _order = _orderRepository.Find(id);

            if (order == null)
                return NotFound();

            _order.ProductName = order.ProductName;
            _order.Price = order.Price;
            _order.Quantity = order.Quantity;
            _order.Date = order.Date;
            _order.Total = order.Total;

            _orderRepository.Update(_order);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var order = _orderRepository.Find(id);

            if (order == null)
                return NotFound();

            _orderRepository.Remove(id);
            return new NoContentResult();
                
        }

    }
}
