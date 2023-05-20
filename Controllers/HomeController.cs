using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        readonly CarpoolRepository _carpoolRepository;
        public HomeController(CarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet]
        public IEnumerable<Car> GetUnallocatedCars()
        {
            var cars =  _carpoolRepository.GetUnallocatedCars().Result.ToList();

            return cars;
        }
    }
}
