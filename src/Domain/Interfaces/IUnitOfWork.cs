using Domain.Repositories;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ITodoRepository Todos { get; }
        Task<int> CompleteAsync();
    }
}
