using Microsoft.EntityFrameworkCore;

namespace todoDotNet6
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }

}