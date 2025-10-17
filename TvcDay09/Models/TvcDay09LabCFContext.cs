using Microsoft.EntityFrameworkCore;
namespace TvcDay09.Models
{
    public class TvcDay09LabCFContext : DbContext
    {
        public TvcDay09LabCFContext(DbContextOptions<TvcDay09LabCFContext> options) : base(options) { }

        public DbSet<Tvc_Loai_San_Pham> tvc_Loai_San_Phams { get; set; }

        public DbSet<TvcSan_Pham> TvcSan_Phams { get; set; }
    }
}
