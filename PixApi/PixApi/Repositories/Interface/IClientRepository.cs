using PixApi.Data;
using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface IClientRepository
    {
        Task<ClientModel> AddClient(ClientModel newClient);
        Task<List<ClientModel>> GetAllClients();
        Task<List<ClientModel>> GetClientsByName(string name);
        Task<ClientModel> UpdateClient(ClientModel newClient, int id);
        Task<ClientModel> UpdateClientKey(int keyId, int id);
        Task<bool> DeleteClient(int id);

    }
}
