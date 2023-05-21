using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("api/createnewtravelplan")]
    public class CreateNewTravelPlanController : ControllerBase
    {
        readonly CarpoolRepository _carpoolRepository;
        public CreateNewTravelPlanController(CarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet("unallocatedcars")]
        public IEnumerable<Car> GetUnallocatedCars()
        {
            var res = _carpoolRepository.GetUnallocatedCars().Result;
            return res.ToList();
        }

        [HttpGet("unallocatedemployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            var res = _carpoolRepository.GetUnallocatedEmployees().Result;
            return res.ToList();
        }

        [HttpPost("submit")]
        public ActionResult Submit([FromForm] TravelPlanDto travelPlan)
        {
            var employeeIds = JsonSerializer.Deserialize<int[]>(travelPlan.EmployeeIds);
            return Ok();
        }
    }
}