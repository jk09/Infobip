namespace Infobip.Models
{
    public class TravelPlan
    {
        public string StartLocation { get; set; }
        public string EndLocation  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public int EmployeeId { get; set; }

    }
}
