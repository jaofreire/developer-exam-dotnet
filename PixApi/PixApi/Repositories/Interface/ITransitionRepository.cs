using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface ITransitionRepository
    {
        Task<Transition> CreateTransition( string? IssuerKey, string? ReceiverKey, double depositValue );
        Task<List<Transition>> GetAllTransitions();
        Task<List<Transition>> GetTransitionByKey(string? key);
        Task<Transition> GetTransitionById(int id);
    }
}
