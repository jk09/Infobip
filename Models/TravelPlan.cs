using System.ComponentModel.DataAnnotations.Schema;

namespace Infobip.Models
{
    public class TravelPlan
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
