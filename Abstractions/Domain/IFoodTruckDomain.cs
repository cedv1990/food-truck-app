using System.Collections.Generic;
using Models;
using Models.DTO;

namespace Abstractions.Domain
{
    public interface IFoodTruckDomain
    {
        IEnumerable<FoodTruck> LoadFromDTO(IEnumerable<FoodTruckDTO> data);
    }
}