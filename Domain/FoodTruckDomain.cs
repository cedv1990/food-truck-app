using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Domain;
using Extensions;
using Models;
using Models.DTO;
using Models.Enums;

namespace Domain
{
    public class FoodTruckDomain : IFoodTruckDomain
    {
        public IEnumerable<FoodTruck> LoadFromDTO(IEnumerable<FoodTruckDTO> data)
        {
            return data
                .Select(foodTruck => new FoodTruck(
                    facilityType: (FacilityType)Enum.Parse(typeof(FacilityType), foodTruck.facilitytype.CleanSpaces()),
                    name: foodTruck.applicant
                ));
        }
    }
}