using Microsoft.EntityFrameworkCore;

namespace Infobip.Models
{
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);

        }

        private readonly string[] FIRST_NAMES = new string[] {
    "Alice",
    "Bob",
    "Charlie",
    "David",
    "Emma",
    "Frank",
    "Grace",
    "Henry",
    "Isabel",
    "Jack"
};

        private readonly string[] CAR_MODELS = new string[] {
    "Toyota Corolla",
    "Ford F-150",
    "BMW 3 Series",
    "Honda Civic",
    "Chevrolet Camaro",
    "Hyundai Sonata",
    "Nissan Altima",
    "Audi A4",
    "Subaru Outback",
    "Tesla Model 3"
};

        private readonly string[] EMPLOYEE_NAMES = new string[] {
    "Anna Smith",
    "Brian Jones",
    "Chloe Wilson",
    "Daniel Lee",
    "Ella Brown",
    "Felix Garcia",
    "Grace Miller",
    "Harry Johnson",
    "Ivy Davis",
    "James Taylor",
    "Kayla Martin",
    "Leo Thompson",
    "Mia Williams",
    "Noah Rodriguez",
    "Olivia Anderson",
    "Ryan Clark",
    "Sophia Lopez",
    "Tyler Lewis",
    "Zoe Walker",
    "Adam White",
    "Bella Harris",
    "Connor Hall",
    "Emma Young",
    "Liam Allen",
    "Nora King"
};


        private readonly string[] COLORS = new string[] {
    "Red",
    "Orange",
    "Yellow",
    "Green",
    "Blue",
    "Indigo",
    "Violet",
    "Black",
    "White",
    "Gray"
};

        private readonly string[] LICENSE_PLATES = new string[] {
    "ABC-123",
    "DEF-456",
    "GHI-789",
    "JKL-012",
    "MNO-345",
    "PQR-678",
    "STU-901",
    "VWX-234",
    "YZA-567",
    "BCD-890"
};
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new Car() { Id=1,  })
        }

        private IEnumerable<Car> GetRandomCarData(int count)
        {
            var rnd = new Random();

            for(int i = 0; i < count; i++)
            {
                var car = new Car() { Id=i, CarType };
                yield return car;
            }
        }
    }
}
