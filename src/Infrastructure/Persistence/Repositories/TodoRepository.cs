using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            var todos = await _context.Todos.ToListAsync();
            return todos;
        }

        public async Task<Todo?> GetById(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            return todo;
        }

        public async Task<bool> Add(Todo entity)
        {
            _context.Todos.Add(entity);
            return true;
        }

        public async Task<bool> Update(Todo entity)
        {
            var todoFromDb = await _context.Todos.FirstOrDefaultAsync(t => t.Id == entity.Id);

            if(todoFromDb == null) { return false; }

            _context.Todos.Update(entity);

            return true;
        }

        public async Task<bool> Delete(Todo entity)
        {
            var todoFromDb = await _context.Todos.FirstOrDefaultAsync(t => t.Id == entity.Id);

            if (todoFromDb == null) { return false; }

            _context.Todos.Remove(entity);

            return true;

        }
    }
}
