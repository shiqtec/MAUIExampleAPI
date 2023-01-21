using Microsoft.EntityFrameworkCore;

namespace MAUIExampleAPI.Models.Database
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }
        DbSet<Todo> Todos { get; set; }
    }
}
