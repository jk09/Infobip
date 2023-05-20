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

        public async Task<IEnumerable<Car>> GetUnallocatedCars()
        {

            var query = from car in _db.Cars
                        join plan in _db.TravelPlans on car.Id equals plan.CarId into joinGroup
                        from joinGrp in joinGroup.DefaultIfEmpty()
                        where joinGrp == null
                        select car;



            return await query.ToListAsync();
        }

        public async Task<int> GetEmployeesCount()
        {
            return await _db.Employees.CountAsync();
        }

        public async Task<int> GetCarsCount()
        {
            return await _db.Cars.CountAsync();
        }

        public async Task<int> GetTravelPlansCount()
        {
            return await _db.TravelPlans.CountAsync();
        }

        public async Task<IEnumerable<Employee>> GetUnallocatedEmployees()
        {
            //var query = from emp in _db.Employees
            //            join plan in _db.TravelPlans on emp.Id equals plan.EmployeeId into joinGroup
            //            from joinGrp in joinGroup.DefaultIfEmpty()
            //            where joinGrp == null
            //            select emp;

            //return await query.ToListAsync();

            return await Task.FromResult(Enumerable.Empty<Employee>());

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