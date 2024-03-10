using PixApi.Data;
using PixApi.Models;
using PixApi.Repositories.Interface;

namespace PixApi.Repositories
{
    public class KeyRepository : IKeyRepository
    { 
        private readonly ApiDbContext _context;

        public KeyRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<KeyModel> AddKey( KeyModel newKey)
        {
            await _context.Keys.AddAsync(newKey);
            await _context.SaveChangesAsync();

            return newKey;
        }
    }
}
