using AutoMapper;
using Infobip.Models;

namespace Infobip.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TravelPlanDto, TravelPlan>();
        }
    }
}