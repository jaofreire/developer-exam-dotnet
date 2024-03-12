using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<Transition> CreateTransition(string? IssuerKey, string? ReceiverKey, double depositValue)
        {

            var issuer = await _context.Clients.Include(x => x.Key).FirstOrDefaultAsync(x => x.Key.Key == IssuerKey) ??
                throw new Exception("Issuer client not found or Not exist");

            var receiver = await _context.Clients.Include(x => x.Key).FirstOrDefaultAsync(x => x.Key.Key == ReceiverKey) ??
                throw new Exception("Receiver client not found or Not exist");

            var transition = new Transition()
            {
                IssuerClient = issuer.Name,
                IssuerClientKey = issuer.Key.Key,
                ReceiverClient = receiver.Name,
                ReceiverClientKey = receiver.Key.Key,

                DepositValue = depositValue,
            };

            await _context.Transitions.AddAsync(transition);
            await _context.SaveChangesAsync(); 

            return transition;
        }

        public async Task<List<Transition>> GetAllTransitions()
        {
            return await _context.Transitions.ToListAsync();
        }

        public async Task<Transition> GetTransitionById(int id)
        {
            return await _context.Transitions.FindAsync(id) ??
                throw new Exception("Transition not found");
        }

        public async Task<List<Transition>> GetTransitionByKey(string? key)
        {
            List<Transition> getTransitionByIssuerKey = await _context.Transitions.Where(x => x.IssuerClientKey == key).ToListAsync();

            List<Transition> getTransitionByReceiverKey = await  _context.Transitions.Where(x => x.ReceiverClientKey == key).ToListAsync();

            List<Transition> transitions = new List<Transition>();

            if (getTransitionByIssuerKey.Any())
                transitions.AddRange(getTransitionByIssuerKey);

            if ( getTransitionByReceiverKey.Any())
                transitions.AddRange(getTransitionByReceiverKey);

            if (getTransitionByIssuerKey.IsNullOrEmpty() && getTransitionByReceiverKey.IsNullOrEmpty())
                throw new Exception("NO ONE TRANSITION FOUND");

            return transitions;

        }
        
    }
}
