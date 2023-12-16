using Microsoft.EntityFrameworkCore;
using TestSoftline.Models;

namespace TestSoftline.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new {StatusId = 1 , StatusName = "Создана"},
                new { StatusId = 2, StatusName = "В работе" },
                new { StatusId = 3, StatusName = "Завершена" }
                );
        }
    }
}
