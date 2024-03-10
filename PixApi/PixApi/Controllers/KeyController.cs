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
    }
}
