using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Persistence.Repositories
{
    public class CachedPostRepository : IPostRepository
    {
        private readonly IPostRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CachedPostRepository(IPostRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public void Add(Post entity)
        {
            _decorated.Add(entity);
        }

        public void Delete(Post entity)
        {
            _decorated.Delete(entity);
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            return _decorated.GetAll();
        }

        public Task<Post?> GetById(int id)
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

        public void Update(Post entity)
        {
            _decorated.Update(entity);
        }
    }
}
