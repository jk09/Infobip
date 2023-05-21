using AutoMapper;
using Infobip.Controllers;
using Infobip.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace Infobip.Services
{
    public class CarpoolRepository : ICarpoolRepository
    {
        private readonly IMapper _mapper;

        public CarpoolRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetUnallocatedCars()
        {
            using (var context = new CarpoolDbContext())
            {
                var allocatedCars = context.TravelPlans.Select(x => x.CarId);
                var ans = await context.Cars.Where(c => !allocatedCars.Any(i => i == c.Id)).ToListAsync() ;
                return ans;
            }
        }

        

        public async Task<IEnumerable<Employee>> GetUnallocatedEmployees()
        {
            using (var context = new CarpoolDbContext())
            {
                var allocatedEmployees = context.TravelPlans.SelectMany(tp => tp.Employees);
                var ans = await context.Employees.Where(e => !allocatedEmployees.Any(t => t.Id == e.Id)).ToListAsync();
                return ans;
            }
        }

        public async Task AddNewTravelPlan(TravelPlanDto dto)
        {
          
            var plan = _mapper.Map<TravelPlanDto, TravelPlan>(dto);
            plan.Employees = new  List<Employee>();

            using (var context = new CarpoolDbContext())
            {
                var employeeIds = JsonSerializer.Deserialize<int[]>(dto.EmployeeIds);
                Debug.Assert(employeeIds != null && employeeIds.Length > 0);

                foreach (var employeeId in employeeIds)
                {
                    var employee = context.Employees.Find(employeeId);
                    Debug.Assert(employee != null);

                    plan.Employees.Add(employee);
                }
                context.TravelPlans.Add(plan);

                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteTravelPlan(TravelPlan plan)
        {
            throw new NotImplementedException();
        }

        public async Task EditTravelPlan(TravelPlan plan)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<TravelPlanEvent>> GetTravelPlansEvents()
        {
            using (var context = new CarpoolDbContext())
            {
                var plansCars = context.TravelPlans
                    .Join(context.Cars, x => x.CarId, y => y.Id, 
                    (plan, car) => new { id=plan.Id, employees = plan.Employees.Select(emp=>emp.Name), carName = car.Name, startDate = plan.StartDate, endDate= plan.EndDate, endLocation=plan.EndLocation, startLocation=plan.StartLocation });

                var data = await plansCars.ToListAsync();

                var events = data.Select(x => new TravelPlanEvent() { Id = x.id, CarName = x.carName, Employees = x.employees, EndDate = x.endDate, StartDate = x.startDate, EndLocation = x.endLocation, StartLocation = x.startLocation }).ToList();

                return events;

}
        }
    }


}