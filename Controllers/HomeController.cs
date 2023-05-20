using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        readonly CarpoolRepository _carpoolRepository;
        public HomeController(CarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet(Name = "GetUnallocatedCars")]
        public async Task<IEnumerable<Car>> GetUnallocatedCars()
        {
            return await _carpoolRepository.GetUnallocatedCars();
        }
    }
}
