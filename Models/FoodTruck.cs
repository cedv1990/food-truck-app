namespace Models
{
    using Enums;
    using Extensions;
    using Exceptions.Http;
    
    public sealed class FoodTruck
    {
        public static readonly string INVALID_FACILITY_TYPE = "Invalid facility type";
        public static readonly string INVALID_NAME = "Name is required";
        
        public FacilityType FacilityType { get; }
        
        public string Name { get; }

        public int Id { get; set; }
        
        public FoodTruck() {}

        public FoodTruck(FacilityType facilityType, string name = "")
        {
            if (facilityType.IsInValid()) throw new FoodTruckInvalidParametersException(INVALID_FACILITY_TYPE);
            if (string.IsNullOrEmpty(name)) throw new FoodTruckInvalidParametersException(INVALID_NAME);
            
            FacilityType = facilityType;
            Name = name;
        }
    }
}