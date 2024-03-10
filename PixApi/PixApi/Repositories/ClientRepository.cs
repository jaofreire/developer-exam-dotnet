using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories.Interface;

namespace PixApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApiDbContext _context;

        public ClientRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ClientModel> AddClient( ClientModel newClient)
        {
            await _context.Clients.AddAsync(newClient);
            await _context.SaveChangesAsync();

            return newClient;
        }
    }
}
