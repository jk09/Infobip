using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Infobip.Controllers;
using Infobip.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using System.Transactions;

namespace Infobip.Services
{
    public class CarpoolRepository : ICarpoolRepository
    {
        private readonly IMapper _mapper;

        public CarpoolRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            using (var context = new CarpoolDbContext())
            {
                // get unallocated cars
                //var allocatedCars = context.TravelPlans.Select(x => x.CarId);
                //var ans = await context.Cars.Where(c => !allocatedCars.Any(i => i == c.Id)).ToListAsync() ;
                //return ans;

                return await context.Cars.ToListAsync();
            }
        }

        public async Task<TravelPlan?> GetTravelPlan(int planId)
        {
            using (var context = new CarpoolDbContext())
            {
                return await context.TravelPlans.Include(tp=>tp.Employees).FirstOrDefaultAsync(x => x.Id == planId);
            }
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using (var context = new CarpoolDbContext())
            {
                // get unallocated employees
                //var allocatedEmployees = context.TravelPlans.SelectMany(tp => tp.Employees);
                //var ans = await context.Employees.Where(e => !allocatedEmployees.Any(t => t.Id == e.Id)).ToListAsync();
                //return ans;

                return await context.Employees.ToListAsync();
            }
        }

        private async Task ValidateTravelPlan(CarpoolDbContext context, TravelPlanDto dto)
        {

            static void Assert(bool condition, string? errorMessage = null)
            {
                if (!condition) throw new TravelPlanValidationException(errorMessage);
            }

            static bool NonOverlap(DateTime a1, DateTime a2, DateTime b1, DateTime b2)
            {
                Debug.Assert(a1 < a2 && b1 < b2);
                return a2 < b1 || b2 < a1;
            }

            async Task<IEnumerable<(DateTime startDate, DateTime endDate)>> GetCarAllocations(int carId)
            {
                var q = await context.TravelPlans.Where(tp => tp.CarId == carId).Select(tp => new { tp.StartDate, tp.EndDate }).ToListAsync();
                return q.Select(x => (x.StartDate, x.EndDate));
            }

            async Task<IEnumerable<(DateTime startDate, DateTime endDate)>> GetEmployeeAllocations(int employeeId)
            {
                var q = await context.TravelPlans.Where(tp => tp.Employees.Any(e => e.Id == employeeId)).Select(tp => new { tp.StartDate, tp.EndDate }).ToListAsync();
                return q.Select(x => (x.StartDate, x.EndDate));
            }

            // validate the new travel plan
            var employeeIds = JsonSerializer.Deserialize<int[]>(dto.EmployeeIds).ToList();
            Debug.Assert(employeeIds != null);

            Assert(dto.StartDate < dto.EndDate, "Start date must precede end date");
            Assert(dto.StartLocation != dto.EndLocation, "Start and end location must be different");

            var carAllocs = await GetCarAllocations(dto.CarId);

            try
            {
                Assert(carAllocs.All(a => NonOverlap(a.startDate, a.endDate, dto.StartDate, dto.EndDate)));
            }
            catch (TravelPlanValidationException)
            {
                var car = await context.Cars.FindAsync(dto.CarId);
                Debug.Assert(car != null);

                Assert(false, $"Car {car.Name} is already allocated");
            }

            foreach (var employeeId in employeeIds)
            {
                var employeeAllocs = await GetEmployeeAllocations(employeeId);
                try
                {
                    Assert(employeeAllocs.All(a => NonOverlap(a.startDate, a.endDate, dto.StartDate, dto.EndDate)));
                }
                catch (TravelPlanValidationException)
                {
                    var employee = await context.Employees.FindAsync(employeeId);
                    Debug.Assert(employee != null);

                    Assert(false, $"Employee {employee.Name} is already allocated");
                }
            }

            var employees = await context.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();
            Assert(employees.Any(x => x.IsDriver), "At least one employee must be a driver");

        }

        public async Task AddNewTravelPlan(TravelPlanDto dto)
        {
            var plan = _mapper.Map<TravelPlanDto, TravelPlan>(dto);
            plan.Employees = new  List<Employee>();

            using (var context = new CarpoolDbContext())
            {
                await ValidateTravelPlan(context, dto);

                var employeeIds = JsonSerializer.Deserialize<int[]>(dto.EmployeeIds).ToList();
                Debug.Assert(employeeIds != null);


                // save the data
                var employees = await context.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();

                foreach (var employee in employees)
                {
                    plan.Employees.Add(employee);
                }
                context.TravelPlans.Add(plan);

                await context.SaveChangesAsync();

               

            }


            
        }

        public async Task DeleteTravelPlan(TravelPlanDto plan)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTravelPlan(TravelPlanDto dto)
        {
            using (var context = new CarpoolDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {

                        var existingPlan = await context.TravelPlans.FindAsync(dto.Id);
                        Debug.Assert(existingPlan != null);
                        //existingPlan.Employees.
                        context.TravelPlans.Remove(existingPlan);
                        
                        await context.SaveChangesAsync();

                        await ValidateTravelPlan(context, dto);

                        var updatedPlan = _mapper.Map<TravelPlanDto, TravelPlan>(dto);
                        updatedPlan.Id = default;

                        context.TravelPlans.Add(updatedPlan);

                        await context.SaveChangesAsync();

                        tran.Commit();
                    }
                    catch(Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }

            }


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