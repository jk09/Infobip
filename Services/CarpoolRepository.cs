using Infobip.Models;
using Microsoft.EntityFrameworkCore;

namespace Infobip.Services
{
    public class CarpoolRepository
    {
        private readonly CarpoolDbContext _db;

        public CarpoolRepository(CarpoolDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Car>> GetAvailableCars()
        {

            var queryCarsLeftJoinPlans = from car in _db.Cars
                                         join plan in _db.TravelPlans on car.Id equals plan.Id 
                                         select car;


            return await queryCarsLeftJoinPlans.ToListAsync();
        }

        public async Task AddNewTravelPlan(TravelPlan plan)
        {
            _db.TravelPlans.Add(plan);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteTravelPlan(TravelPlan plan)
        {
            _db.TravelPlans.Remove(plan);

            await _db.SaveChangesAsync();
        }

        public async Task EditTravelPlan(TravelPlan plan)
        {
            _db.TravelPlans.Attach(plan);
            _db.Entry(plan).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        
    }
}
