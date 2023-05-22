using Infobip.Controllers;
using Infobip.Models;

namespace Infobip.Services
{
    public interface ICarpoolRepository
    {
        Task AddNewTravelPlan(TravelPlanDto plan);
        Task DeleteTravelPlan(TravelPlan plan);
        Task EditTravelPlan(TravelPlan plan);
        Task<IEnumerable<Car>> GetCars();
        Task<IEnumerable<Employee>> GetEmployees();
        
        Task<IEnumerable<TravelPlanEvent>> GetTravelPlansEvents();
        Task<TravelPlan?> GetTravelPlan(int planId);
    }
}