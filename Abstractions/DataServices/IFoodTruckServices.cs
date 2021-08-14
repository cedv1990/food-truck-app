using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTO;

namespace Abstractions.DataServices
{
    public interface IFoodTruckServices
    {
        IEnumerable<Models.FoodTruck> GetFoodTruckListService();
        Task<IEnumerable<FoodTruckDTO>> GetFoodTruckListFromExternalService();
        void SaveFoodTruckList(IEnumerable<Models.FoodTruck> list);
    }
}