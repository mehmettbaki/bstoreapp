using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Repositories.config;

namespace webapi.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext( DbContextOptions options) : base (options)
        {
            
        }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration( new BookConfig() );
        }
    }
}
