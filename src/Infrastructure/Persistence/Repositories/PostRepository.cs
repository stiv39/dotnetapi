using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context) { }

        public DbContext GetContext
        {
            get { return Context; }
        }
    }
}
