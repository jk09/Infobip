using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateNewTravelPlanController : ControllerBase
    {
        readonly CarpoolRepository _carpoolRepository;
        public CreateNewTravelPlanController(CarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            var res = _carpoolRepository.GetUnallocatedCars().Result;
            return res.ToList();
        }
    }
}