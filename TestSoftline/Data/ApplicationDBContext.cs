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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status[] {
                new Status { StatusId = 0, StatusName = "Создана" },
                new Status { StatusId = 1, StatusName = "В работе" },
                new Status { StatusId = 2, StatusName = "Завершена" }
                });
        }

    }
}
