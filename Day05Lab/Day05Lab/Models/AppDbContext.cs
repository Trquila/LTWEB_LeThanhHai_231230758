using Microsoft.EntityFrameworkCore;

namespace Day05Lab.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Nguyễn Văn A",
                    Gender = "Nam",
                    Phone = "0123456789",
                    Email = "a@email.com",
                    Salary = 10000000,
                    Status = true
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Trần Thị B",
                    Gender = "Nữ",
                    Phone = "0987654321",
                    Email = "b@email.com",
                    Salary = 12000000,
                    Status = true
                }
            );
        }
    }
}