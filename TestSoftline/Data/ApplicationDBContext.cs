using Microsoft.EntityFrameworkCore;
using TestSoftline.Models;

namespace TestSoftline.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ApplicationDBContext()
        {
            Database.EnsureCreated();
        }
    }
}
