using Microsoft.EntityFrameworkCore;

namespace LeThanhHai_231230758_de02.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LeThanhHai_231230758_de02.Models.HvtCatalog> HvtCatalog { get; set; }
    }
}
