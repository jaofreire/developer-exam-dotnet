using FluentValidation;
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
        private readonly IValidator<KeyModel> _validator;

        public KeyController(IKeyRepository keyRepository, IValidator<KeyModel> validator)
        {
            _keyRepository = keyRepository ?? throw new ArgumentNullException(nameof(keyRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpPost("/key/register")]
        public async Task<IResult> RegisterNewKey(KeyModel newKey)
        {

            var validation = await _validator.ValidateAsync(newKey);
            if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

            await _keyRepository.AddKey(newKey);
            return Results.Ok(newKey);

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

        [HttpPut("/key/update/{id}")]
        public async Task<IResult> Update(int id, KeyModel keyUpdate)
        {
            var validation = await _validator.ValidateAsync(keyUpdate);
            if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

            keyUpdate.Id = id;
            return Results.Ok( await _keyRepository.UpdateKey(keyUpdate, id));
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
