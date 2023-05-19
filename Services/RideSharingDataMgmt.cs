using Infobip.Models;
using Microsoft.EntityFrameworkCore;

namespace Infobip.Services
{
    public class RideSharingDataMgmt
    {
        private readonly CarpoolRepository _repository;

        public RideSharingDataMgmt(CarpoolRepository repository)
        {
            _repository = repository;
        }

        public void CreateNewTravelPlan()
        {
            
        }
    }
}
