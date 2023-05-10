using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(DbContext context) : base(context) { }

        public DbContext GetContext
        {
            get { return Context; }
        }
    }
}
