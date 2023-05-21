using Infobip.Controllers;
using Infobip.Models;

namespace Infobip.Services
{
    public interface ICarpoolRepository
    {
        Task AddNewTravelPlan(TravelPlanDto plan);
        Task DeleteTravelPlan(TravelPlan plan);
        Task EditTravelPlan(TravelPlan plan);
        Task<IEnumerable<Car>> GetUnallocatedCars();
        Task<IEnumerable<Employee>> GetUnallocatedEmployees();
        
        Task<IEnumerable<TravelPlanEvent>> GetTravelPlansEvents();
    }
}