using Microsoft.EntityFrameworkCore;

namespace Infobip.Models
{
    [Index(nameof(Car.Plate), IsUnique = true)]
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        
        public string Plate { get; set; }
        public int NumberSeats { get; set; }
    }
}
