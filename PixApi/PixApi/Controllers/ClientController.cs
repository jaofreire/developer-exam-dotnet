using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories.Interface;

namespace PixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        [HttpPost("/client/register")]
        public async Task<ActionResult<ClientModel>> RegisterNewClient(ClientModel clientModel)
        {
            await _clientRepository.AddClient(clientModel);
            return clientModel;
        }

        [HttpGet("/client/getAll")]
        public async Task<ActionResult<List<ClientModel>>> GetAll()
        {
            return await _clientRepository.GetAllClients();
        }

        [HttpGet("/client/getByName")]
        public async Task<ActionResult<List<ClientModel>>> GetByName(string name)
        {
            return await _clientRepository.GetClientsByName(name);
        }

        [HttpPut("/client/update/{id}")]
        public async Task<ActionResult<ClientModel>> Update(ClientModel newClient, int id)
        {
            newClient.Id = id;
            return await _clientRepository.UpdateClient(newClient, id);
        }

        [HttpPut("/client/updateKey/{id}")]
        public async Task<ActionResult<ClientModel>> UpdateKey(int keyId, int id)
        {
            return await _clientRepository.UpdateClientKey(keyId, id);
        }

        [HttpDelete("client/remove/{id}")]
        public async Task<ActionResult<bool>> Remove(int id)
        {
            return await _clientRepository.DeleteClient(id);
        }


    }
}
