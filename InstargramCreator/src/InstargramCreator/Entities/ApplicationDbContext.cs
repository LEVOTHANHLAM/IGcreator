using Microsoft.EntityFrameworkCore;

namespace InstargramCreator.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }     
        public DbSet<Accounts> Accounts { get; set; }
    }
}