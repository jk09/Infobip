using AutoMapper;
using Infobip.Models;
using Infobip.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Infobip.Controllers
{
    [ApiController]
    [Route("api/createnewtravelplan")]
    public class CreateNewTravelPlanController : ControllerBase
    {
        private readonly ICarpoolRepository _carpoolRepository; 

        public CreateNewTravelPlanController(ICarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        [HttpGet("cars")]
        public IEnumerable<Car> GetUnallocatedCars()
        {
            var res = _carpoolRepository.GetCars().Result;
            return res.ToList();
        }

        [HttpGet("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            var res = _carpoolRepository.GetEmployees().Result;
            return res.ToList();
        }

        [HttpPost("submit")]
        public async Task<ActionResult> Submit([FromForm] TravelPlanDto travelPlan)
        {
            await _carpoolRepository.AddNewTravelPlan(travelPlan);

            return Ok();
        }

      
    }

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
    }
}