namespace Infobip.Infrastructure
{
    public class TravelPlanValidationException : Exception
    {

        public TravelPlanValidationException(string? message) : base(message)
        {
        }
    }
}