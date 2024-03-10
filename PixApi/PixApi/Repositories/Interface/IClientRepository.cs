using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface IClientRepository
    {
        Task<ClientModel> AddClient(ClientModel newClient);
    }
}
