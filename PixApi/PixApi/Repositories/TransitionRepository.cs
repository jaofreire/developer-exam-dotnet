using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories.Interface;

namespace PixApi.Repositories
{
    public class TransitionRepository : ITransitionRepository
    {
        private readonly ApiDbContext _context;

        public TransitionRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Transition> CreateTransition(Transition Newtransition, ClientModel clientA, ClientModel ClientB)
        {

            return Newtransition;
        }
    }
}
