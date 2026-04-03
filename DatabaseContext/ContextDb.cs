using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DatabaseContext;

public class ContextDb: DbContext
{
        public ContextDb(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
}