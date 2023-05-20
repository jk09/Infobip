using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        readonly CarpoolRepository _carpoolRepository;
        public HomeController(CarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetUnallocatedCars()
        {
            var cars =  await _carpoolRepository.GetUnallocatedCars();

            return Ok(cars);
        }
    }
}
