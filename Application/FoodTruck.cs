using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Application;
using Abstractions.DataServices;
using Abstractions.Domain;

namespace Application
{
    public class FoodTruck : IFoodTruck
    {
        private IFoodTruckServices _services;
        private IFoodTruckDomain _domain;

        public FoodTruck(IFoodTruckServices services, IFoodTruckDomain domain)
        {
            _services = services;
            _domain = domain;
        }

        public async Task<IEnumerable<Models.FoodTruck>> GetFoodTruckList()
        {
            var listFromDb = _services.GetFoodTruckListService();
            if (listFromDb != null && listFromDb.Any())
            {
                return listFromDb;
            }

            var externalListDTO = await _services.GetFoodTruckListFromExternalService();
            var externalList = _domain.LoadFromDTO(externalListDTO);

            _services.SaveFoodTruckList(externalList);

            return externalList;
        }
    }
}