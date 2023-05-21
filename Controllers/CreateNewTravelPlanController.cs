using AutoMapper;
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
        private readonly ICarpoolRepository _carpoolRepository;
        private readonly IMapper _mapper;

        public CreateNewTravelPlanController(ICarpoolRepository carpoolRepository, IMapper mapper)
        {
            _carpoolRepository = carpoolRepository;
            _mapper = mapper;
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
        public ActionResult Submit([FromForm] TravelPlanDto travelPlanDto)
        {
            var employeeIds = JsonSerializer.Deserialize<int[]>(travelPlanDto.EmployeeIds);
            var travelPlan = _mapper.Map<TravelPlanDto, TravelPlan>(travelPlanDto);


            return Ok();
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