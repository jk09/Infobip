using Infobip.Infrastructure;
using Infobip.Models;

namespace Infobip.Services
{
    public interface ICarpoolRepository
    {
        Task AddNewTravelPlan(TravelPlanDto plan);
        Task DeleteTravelPlan(int travelPlanId);
        Task UpdateTravelPlan(TravelPlanDto plan);
        Task<IEnumerable<Car>> GetCars();
        Task<IEnumerable<Employee>> GetEmployees();
        
        Task<IEnumerable<TravelPlanEvent>> GetTravelPlansEvents();
        Task<TravelPlan?> GetTravelPlan(int planId);
        
    }
}