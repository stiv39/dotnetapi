using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext) =>
            _dataContext = dataContext;

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _dataContext.Todos.ToListAsync();
        }

        public async Task<Todo?> GetById(int id)
        {
            return await _dataContext.Todos.FindAsync(id);
        }

        public void Add(Todo entity)
        {
            _dataContext.Todos.Add(entity);
        }

        public void Update(Todo entity)
        {
            _dataContext.Todos.Update(entity);
        }

        public void Delete(Todo entity)
        {
            _dataContext.Todos.Remove(entity);
        }
        public int GetNewlyCreatedEntityId(Todo entity)
        {
            var newEntityEntry = _dataContext.Entry(entity);
            var newEntityId = newEntityEntry.Property(x => x.Id).CurrentValue;

            return newEntityId;
        }
    }
}
