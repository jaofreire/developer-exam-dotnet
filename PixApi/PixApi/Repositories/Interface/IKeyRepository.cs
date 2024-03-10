using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface IKeyRepository
    {
        Task<KeyModel> AddKey(KeyModel newKey);
    }
}
