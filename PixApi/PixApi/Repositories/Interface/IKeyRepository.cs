using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface IKeyRepository
    {
        Task<KeyModel> AddKey(KeyModel newKey);
        Task<List<KeyModel>> GetAllKeys();
        Task<List<KeyModel>> GetKey(string key);
        Task<List<KeyModel>> GetKeyByType(string type);
        Task<List<KeyModel>> GetKeyByClientID(int clientId);
        Task<KeyModel> UpdateKey(KeyModel keyUpdate, int id);
        Task<KeyModel> UpdateJustKey(string newKey, int id);
        Task<bool> DeleteKey(int id);
    }
}
