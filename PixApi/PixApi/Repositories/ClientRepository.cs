using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories
{
    public class ClientRepository
    {
        public static async Task<ClientModel> AddClient(ApiDbContext db, ClientModel newClient)
        {
            await db.Clients.AddAsync(newClient);
            await db.SaveChangesAsync();

            return newClient;
        }
    }
}
