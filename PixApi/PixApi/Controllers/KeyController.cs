using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories;
using PixApi.Repositories.Interface;

namespace PixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IKeyRepository _keyRepository;
 
        public KeyController(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository ?? throw new ArgumentNullException(nameof(keyRepository)); ;
        }

        [HttpPost("/key/register")]
        public async Task<ActionResult<KeyModel>> RegisterNewKey(KeyModel newKey)
        {
            await _keyRepository.AddKey(newKey);
            return newKey;
        }

        [HttpGet("/key/getAll")]
        public async Task<ActionResult<List<KeyModel>>> GetAll()
        {
           return await _keyRepository.GetAllKeys();
        }

        [HttpGet("/key/getkey/{key}")]
        public async Task<ActionResult<List<KeyModel>>> GetExpecifcKey(string key)
        {
            return await _keyRepository.GetKey(key);
        }

        [HttpGet("/key/getByType/{type}")]
        public async Task<ActionResult<List<KeyModel>>> GetByType(string type)
        {
            return await _keyRepository.GetKeyByType(type);
        }

        [HttpGet("/key/byClientId/{clientId}")]
        public async Task<ActionResult<List<KeyModel>>> GetByClientID(int clientId)
        {
            return await _keyRepository.GetKeyByClientID(clientId);
        }

        [HttpPut("/key/update/{id}")]
        public async Task<ActionResult<KeyModel>> Update(int id, KeyModel keyUpdate)
        {
            keyUpdate.Id = id;
            return await _keyRepository.UpdateKey(keyUpdate, id);
        }

        [HttpPatch("/key/updateKey/{id}")]
        public async Task<ActionResult<KeyModel>> UpdateKey(int id, string newKey)
        {
            return await _keyRepository.UpdateJustKey(newKey, id);
        }

        [HttpDelete("/key/remove/{id}")]
        public async Task<ActionResult<bool>> Remove(int id)
        {
            return await _keyRepository.DeleteKey(id);
        }






    }
}
