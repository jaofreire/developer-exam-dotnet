using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ClientModel>> GetAllClients()
        {
            return await _context.Clients.Include(x => x.Key).ToListAsync();
        }

        public async Task<List<ClientModel>> GetClientsByName(string name)
        {
            var clients = await _context.Clients.Include(x => x.Key).Where(x => x.Name == name).ToListAsync() ??
                throw new Exception("Client not found");

            return clients;
        }

        public async Task<ClientModel> UpdateClient(ClientModel newClient, int id)
        {
            var clients = await _context.Clients.FindAsync(id) ??
                throw new Exception("Client Not found");

            clients.Name = newClient.Name;

            _context.Clients.Update(clients);
            await _context.SaveChangesAsync();

            return newClient;
            
        }

        public async Task<ClientModel> UpdateClientKey(int keyId, int id)
        {
            var clients = await _context.Clients.FindAsync(id) ??
                throw new Exception("Client Not found");

            List<ClientModel> clientList = _context.Clients.Where(x => x.ClientKeyId == keyId).ToList();

            if (clientList.Any())
            {
                throw new Exception("This key its associate in the other one Client ");
            }

            clients.ClientKeyId = keyId;
            
            _context.Clients.Update(clients);
            await _context.SaveChangesAsync();

            return clients;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var clients = await _context.Clients.FindAsync(id) ??
              throw new Exception("Client Not found");

            _context.Clients.Remove(clients);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
