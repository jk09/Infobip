namespace Infobip.Infrastructure
{
    public class TravelPlanDto
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CarId { get; set; }

        public string EmployeeIds { get; set; }
    }
}