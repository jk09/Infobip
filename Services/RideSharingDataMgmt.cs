using Infobip.Models;

namespace Infobip.Services
{
    public class RideSharingDataMgmt
    {
        public void CreateNewTravelPlan()
        {
        }
    }

    public class CarpoolRepository
    {
        private readonly CarpoolDbContext _dbContext;

        public CarpoolRepository(CarpoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            var leftJoin = _dbContext.Cars.GroupJoin(_dbContext.TravelPlans, car => car.Id, plan => plan.CarId, (car, plans) => new { car, plans }).Where(x => x.plans.Any()).Select(x => x.car);

            throw new NotImplementedException();
        }
    }

}
