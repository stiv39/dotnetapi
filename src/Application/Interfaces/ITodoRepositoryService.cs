using Application.Dtos;

namespace Application.Interfaces
{
    public interface ITodoRepositoryService
    {
        Task<IEnumerable<TodoDto>> GetAll();

        Task<TodoDto?> GetById(int id);

        int? Add(CreateTodoDto entity);

        bool Update(TodoDto entity);

        Task<bool> Delete(int id);
    }
}
