using PixApi.Models;

namespace PixApi.Repositories.Interface
{
    public interface ITransitionRepository
    {
        Task<Transition> CreateTransition(Transition transition, ClientModel clientA, ClientModel ClientB);
    }
}
