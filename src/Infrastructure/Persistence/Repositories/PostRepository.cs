using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post?> GetById(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }

        public async Task<bool> Add(Post entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Post entity)
        {
            var postFromDb = await _context.Posts.FirstOrDefaultAsync(p =>p.Id == entity.Id);
            if(postFromDb == null)
            {
                return false;
            }

            _context.Posts.Update(entity);

            return true;
        }

        public async Task<bool> Delete(Post entity)
        {
            var postFromDb = await _context.Posts.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (postFromDb == null)
            {
                return false;
            }
            _context.Posts.Remove(postFromDb);
            return true;
        }
    }
}
