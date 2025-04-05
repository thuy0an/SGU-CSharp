
using Microsoft.EntityFrameworkCore;

namespace sgu_c_sharf_backend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ThanhVien.ThanhVien> ThanhViens { get; set; }
        public DbSet<LoaiThietBi.LoaiThietBi> LoaiThietBis { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ThanhVien>()
        //         .Property(t => t.TrangThai)
        //         .HasConversion<string>(); // Lưu enum dưới dạng chuỗi
        //
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
