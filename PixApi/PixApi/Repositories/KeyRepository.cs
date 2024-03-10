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
            newKey.ClientId = 0;

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

        public async Task<List<KeyModel>> GetKeyByClientID(int clientId)
        {
            var keyGet = await _context.Keys.Where(x => x.ClientId == clientId).ToListAsync() ??
               throw new Exception("Key not found");
            return keyGet;
        }

        public async Task<KeyModel> UpdateKey(KeyModel keyUpdate, int id)
        {
            var keyGet = await _context.Keys.FindAsync(id) ??
                throw new Exception("Key not found");

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

            keyGet.Key = newKey;

            _context.Keys.Update(keyGet);
            await _context.SaveChangesAsync();

            return keyGet;

        }

        public async Task<bool> DeleteKey(int id)
        {
            var keyGet = await _context.Keys.FindAsync(id) ??
              throw new Exception("Key not found");

            if (keyGet.ClientId != 0)
            {
                var client = await _context.Clients.FindAsync(keyGet.ClientId);
                client.Key = null;

                _context.Keys.Remove(keyGet);
                await _context.SaveChangesAsync();

                return true;
            }

            _context.Keys.Remove(keyGet);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
