using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;


namespace Infrastructure.Persistence.Repositories
{
    public class CachedTodoRepository : ITodoRepository
    {
        private readonly ITodoRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CachedTodoRepository(ITodoRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public void Add(Todo entity)
        {
            _decorated.Add(entity);
        }

        public void Delete(Todo entity)
        {
            _decorated.Delete(entity);
        }

        public Task<IEnumerable<Todo>> GetAll()
        {
            return _decorated.GetAll();
        }

        public Task<Todo?> GetById(int id)
        {
            string key = $"member-{id}";

            return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                    return _decorated.GetById(id);
                });
        }

        public void Update(Todo entity)
        {
            _decorated.Update(entity);
        }
    }
}
