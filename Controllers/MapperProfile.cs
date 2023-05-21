using AutoMapper;
using Infobip.Models;

namespace Infobip.Controllers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TravelPlanDto, TravelPlan>();
        }
    }
}