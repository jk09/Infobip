using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}