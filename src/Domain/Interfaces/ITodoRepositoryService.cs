using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface ITodoRepositoryService
    {
        Task<IEnumerable<TodoDto>> GetAll();

        Task<TodoDto?> GetById(int id);

        bool Add(CreateTodoDto entity);

        bool Update(TodoDto entity);

        bool Delete(int id);
    }
}
