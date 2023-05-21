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
        public async Task<ActionResult> Submit([FromForm] TravelPlanDto travelPlan)
        {
            try
            {
                await _carpoolRepository.AddNewTravelPlan(travelPlan);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }


    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TravelPlanDto, TravelPlan>();
        }
    }
}