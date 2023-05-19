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
        
    }
}
