using System.Threading.Tasks;

namespace Abstractions.Application
{
    using Models;
    using System.Collections.Generic;
    
    public interface IFoodTruck
    {
        Task<IEnumerable<FoodTruck>> GetFoodTruckList();
    }
}