

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebapiContas.Models;
using WebapiContas.Repository;

namespace WebapiContas.Controllers
{

    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {

        private readonly IContasRepository _contasRepository;

        public OrdersController(IContasRepository contasRepo)
        {
            _contasRepository = contasRepo;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrder()
        {
            return _contasRepository.GetAllOrder();
        }

        [HttpGet("{id}", Name="GetOrder")]
        public IActionResult GetById(long id)
        {
            var order = _contasRepository.FindOrder(id);
            if (order == null)
            {
                return NotFound();
            }

            return new ObjectResult(order);
        }








    }
}
