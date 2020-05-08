using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
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
        public IActionResult GetById([FromRoute]long id)
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


        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null)
                return NotFound();


            _clientRepository.Update(client);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _clientRepository.Remove(id);
            return new NoContentResult();
        }

        [HttpGet("Users/{idUser}")]
        public IActionResult GetByIdUser(long idUser)
        {
            var clients = _clientRepository.GetByIdUser(idUser);

            if (clients == null)
                return NotFound();


            return new ObjectResult(clients);
        }

    }
}
