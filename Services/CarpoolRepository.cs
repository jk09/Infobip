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
                return await context.Cars.ToListAsync();
            }
        }

        public async Task<int> GetEmployeesCount()
        {
            using (var context = new CarpoolDbContext())
            {
                return await context.Employees.CountAsync();
            }
        }

        public async Task<int> GetCarsCount()
        {
            using (var context = new CarpoolDbContext())
            {
                return await context.Cars.CountAsync();
            }
        }

        public async Task<int> GetTravelPlansCount()
        {
            using (var context = new CarpoolDbContext())
            {

                return await context.TravelPlans.CountAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetUnallocatedEmployees()
        {
            //var query = from emp in _db.Employees
            //            join plan in _db.TravelPlans on emp.Id equals plan.EmployeeId into joinGroup
            //            from joinGrp in joinGroup.DefaultIfEmpty()
            //            where joinGrp == null
            //            select emp;

            //return await query.ToListAsync();
            using (var context = new CarpoolDbContext())
            {
                return await context.Employees.ToListAsync();
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

    }


}