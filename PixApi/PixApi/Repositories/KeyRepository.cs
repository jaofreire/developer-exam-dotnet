using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories
{
    public static class KeyRepository
    {
        public static async Task<KeyModel> AddKey(ApiDbContext db, KeyModel newKey)
        {
            await db.Keys.AddAsync(newKey);
            await db.SaveChangesAsync();

            return newKey;
        }
    }
}
