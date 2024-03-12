using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixApi.Models;
using PixApi.Repositories.Interface;

namespace PixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransitionController : ControllerBase
    {
        private readonly ITransitionRepository _transitionRepository;

        public TransitionController(ITransitionRepository transitionRepository)
        {
            _transitionRepository = transitionRepository;
        }

        [HttpPost("transition/register")]
        public async Task<ActionResult<Transition>> RegisterNewTransition(string? issuerKey, string? receiverKey, double depositvalue)
        {
            return await _transitionRepository.CreateTransition(issuerKey, receiverKey, depositvalue);
        }

        [HttpGet("transition/getAll")]
        public async Task<ActionResult<List<Transition>>> GetAll()
        {
            return await _transitionRepository.GetAllTransitions();
        }

        [HttpGet("transition/getById/{id}")]
        public async Task<ActionResult<Transition>> GetById(int id)
        {
            return await _transitionRepository.GetTransitionById(id);
        }

        [HttpGet("transition/getByKey/{key}")]
        public async Task<ActionResult<List<Transition>>> GetByKey(string? key)
        {
            return await _transitionRepository.GetTransitionByKey(key);
        }

    }
}
