using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebapiContas.Models;
using WebapiContas.Repository;

namespace WebapiContas.Controllers
{

    [Route("api/[Controller]")]

    public class ClientsController : Controller
    {

        private readonly IContasRepository _contasRepository;

        public ClientsController(IContasRepository contasRepo)
        {
            _contasRepository = contasRepo;
        }

        [HttpGet]
        public IEnumerable<Client> GetAllClient()
        {
            return _contasRepository.GetAllClient();
        }

        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult GetById(long id)
        {
            var client = _contasRepository.FindClient(id);
            if (client == null)
            {
                return NotFound();
            }

            return new ObjectResult(client);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            _contasRepository.AddClient(client);

            return CreatedAtRoute("GetClient", new { id = client.IdClient }, client);

        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Client client)
        {
            if (client == null || client.IdClient != id)
                return BadRequest();

            var _client = _contasRepository.FindClient(id);

            if (client == null)
                return NotFound();

            _client.Name = client.Name;
            _client.Phone = client.Phone;

            _contasRepository.UpdateClient(_client);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var client = _contasRepository.FindClient(id);

            if (client == null)
                return NotFound();

            _contasRepository.RemoveClient(id);
            return new NoContentResult();
        }



    }
}
