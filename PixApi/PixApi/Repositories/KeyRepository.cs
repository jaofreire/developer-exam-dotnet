
using Microsoft.EntityFrameworkCore;
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
  
            var getEqualKey = await _context.Keys.FirstOrDefaultAsync(x => x.Key == newKey.Key);

            if (getEqualKey != null)
                throw new Exception("Other key have this value, try other value");

            await _context.Keys.AddAsync(newKey);
            await _context.SaveChangesAsync();

            return newKey;
        }

        public async Task<List<KeyModel>> GetAllKeys()
        {
            var keys = await _context.Keys.ToListAsync();
            return keys;
        }

        public async Task<List<KeyModel>> GetKey(string key)
        {
            var keyGet = await _context.Keys.Where(x => x.Key == key).ToListAsync() ??
                throw new Exception("Key not found");
            return keyGet;
        }

        public async Task<List<KeyModel>> GetKeyByType(string type)
        {
            var keyGet = await _context.Keys.Where(x => x.TypeKey == type).ToListAsync() ??
                throw new Exception("Key not found");
            return keyGet;
        }

        public async Task<KeyModel> UpdateKey(KeyModel keyUpdate, int id)
        {
            var keyGet = await _context.Keys.FindAsync(id) ??
                throw new Exception("Key not found");

            var getEqualKey = await _context.Keys.FirstOrDefaultAsync(x => x.Key == keyUpdate.Key);

            if (getEqualKey != null)
                throw new Exception("Other key have this value, try other value");

            keyGet.TypeKey = keyUpdate.TypeKey;
            keyGet.Key = keyUpdate.Key;

            _context.Keys.Update(keyGet);
            await _context.SaveChangesAsync();

            return keyUpdate;
        }

        public async Task<KeyModel> UpdateJustKey(string newKey, int id)
        {
            var keyGet = await _context.Keys.FindAsync(id) ??
               throw new Exception("Key not found");


            var getEqualKey = await _context.Keys.FirstOrDefaultAsync(x => x.Key == newKey);

            if (getEqualKey != null)
                throw new Exception("Other key have this value, try other value");

            keyGet.Key = newKey;

            _context.Keys.Update(keyGet);
            await _context.SaveChangesAsync();

            return keyGet;

        }

        public async Task<bool> DeleteKey(int id)
        {
            var keyGet = await _context.Keys.FindAsync(id) ??
              throw new Exception("Key not found");

            var client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientKeyId == id);

            if (client != null)
            {
                client.ClientKeyId = null;

                _context.Update(client);
                await _context.SaveChangesAsync();
            }

            _context.Keys.Remove(keyGet);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
