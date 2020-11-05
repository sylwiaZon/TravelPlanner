using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface ITravelService
    {
        Task<IEnumerable<Travel>> GetTravels(User user);
        Task AddTravel(NewTravel travel);
    }

    public class TravelService : ITravelService
    {
        private TravelRepository TravelRepository;

        public TravelService()
        {
            TravelRepository = new TravelRepository();
        }

        public async Task<IEnumerable<Travel>> GetTravels(User user)
        {
            return await TravelRepository.GetTravels(user);
        }

        public async Task AddTravel(NewTravel newTravel)
        {
            var travel = new Travel(newTravel);
            await TravelRepository.AddTravelToUser(travel);
        }
    }
}
