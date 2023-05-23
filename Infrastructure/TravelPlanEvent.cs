namespace Infobip.Infrastructure
{
    public class TravelPlanEvent
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string CarName { get; set; }

        public IEnumerable<string> Employees { get; set; }
    }
}
