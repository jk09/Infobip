using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
        [Consumes("multipart/form-data")]
        public ActionResult Submit([FromForm] TravelPlanDto travelPlan)
        {

            return Ok();
        }
    }

    public class TravelPlanDto
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CarId { get; set; }

        public string EmployeeIds { get; set; }
    }
}