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
    }
}
