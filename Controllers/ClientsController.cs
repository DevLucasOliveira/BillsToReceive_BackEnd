using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Controllers
{

    [Route("api/[Controller]")]

    public class ClientsController : Controller
    {

        private readonly IClientsRepository _clientRepository;

        public ClientsController(IClientsRepository contasRepo)
        {
            _clientRepository = contasRepo;
        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult GetById(long id)
        {
            var client = _clientRepository.Find(id);
            if (client == null)
                return NotFound();
            

            return new ObjectResult(client);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            

            _clientRepository.Add(client);

            return CreatedAtRoute("GetClient", new { id = client.IdClient }, client);

        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Client client)
        {
            if (client == null || client.IdClient != id)
                return BadRequest();

            var _client = _clientRepository.Find(id);

            if (client == null)
                return NotFound();

            _client.Name = client.Name;
            _client.Phone = client.Phone;

            _clientRepository.Update(_client);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var client = _clientRepository.Find(id);

            if (client == null)
                return NotFound();

            _clientRepository.Remove(id);
            return new NoContentResult();
        }



    }
}
