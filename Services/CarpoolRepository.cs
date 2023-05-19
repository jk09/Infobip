using Infobip.Models;
using Microsoft.EntityFrameworkCore;

namespace Infobip.Services
{
    public class CarpoolRepository
    {
        private readonly CarpoolDbContext _dbContext;

        public CarpoolRepository(CarpoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetAvailableCars()
        {

            var queryCarsLeftJoinPlans = from car in _dbContext.Set<Car>()
                                         join plan in _dbContext.Set<TravelPlan>() on car.Id equals plan.Id 
                                         select car;


            return await queryCarsLeftJoinPlans.ToListAsync();
        }
    }
}
