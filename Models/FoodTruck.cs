using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    using Enums;
    using Extensions;
    using Exceptions.Http;
    
    public sealed class FoodTruck
    {
        public static readonly string INVALID_FACILITY_TYPE = "Invalid facility type";
        public static readonly string INVALID_NAME = "Name is required";
        
        [Column("facility_type")]
        public FacilityType FacilityType { get; private set; }
        
        [Column("name")]
        public string Name { get; private set; }

        public int Id { get; private set; }
        
        private FoodTruck() {}

        public FoodTruck(FacilityType facilityType, string name = "")
        {
            if (facilityType.IsInValid()) throw new FoodTruckInvalidParametersException(INVALID_FACILITY_TYPE);
            if (string.IsNullOrEmpty(name)) throw new FoodTruckInvalidParametersException(INVALID_NAME);
            
            FacilityType = facilityType;
            Name = name;
        }
    }
}