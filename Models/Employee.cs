using Microsoft.EntityFrameworkCore;

namespace Infobip.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDriver { get; set; }
    }

    public class CarpoolDbContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TravelPlan> TravelPlans { get; set; }

        public string DbPath { get; }


        public CarpoolDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "infobip_carpool.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
