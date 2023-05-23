using Infobip.Infrastructure;
using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("api/travelplans")]
    public class TravelPlansController : ControllerBase
    {
        private readonly ICarpoolRepository _carpoolRepository;

        public TravelPlansController(ICarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;

        }

        [HttpGet("events")]
        public async Task<IEnumerable<TravelPlanEvent>> GetTravelPlansEvents()
        {
            return await _carpoolRepository.GetTravelPlansEvents();
        }


        [HttpGet("travelplan/{id}")]
        public async Task<ActionResult<TravelPlan?>> GetTravelPlan(int id)
        {
            var travelPlan = await _carpoolRepository.GetTravelPlan(id);
            if (travelPlan == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(travelPlan);
            }
        }
    }
}