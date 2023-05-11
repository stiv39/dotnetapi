using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();

        Task<Todo?> GetById(int id);

        void Add(Todo entity);

        void Update(Todo entity);

        void Delete(Todo entity);
    }
}
