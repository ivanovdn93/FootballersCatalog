using Microsoft.EntityFrameworkCore;
using FootballersCatalog.Models;

namespace FootballersCatalog.Data
{
    public class FootballersCatalogContext : DbContext
    {
        public FootballersCatalogContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Footballer> Footballers { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}