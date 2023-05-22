namespace Infobip.Services
{
    public class TravelPlanValidationException : Exception
    {

        public TravelPlanValidationException(string? message) : base(message)
        {
        }
    }
}