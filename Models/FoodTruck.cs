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
        public static readonly string INVALID_ADDRESS = "Address is required";
        
        public int Id { get; private set; }
        
        [Column("facility_type")]
        public FacilityType FacilityType { get; private set; }
        
        [Column("name")]
        public string Name { get; private set; }
        
        [Column("location_description")]
        public string LocationDescription { get; private set; }
        
        [Column("address")]
        public string Address { get; private set; }
        
        [Column("food_items")]
        public string FoodItems { get; private set; }

        [Column("location_latitude")]
        public double Latitude { get; private set; }

        [Column("location_longitude")]
        public double Longitude { get; private set; }
        
        private FoodTruck() {}

        public FoodTruck(
            FacilityType facilityType,
            string name = "",
            string address = "",
            string locationDescription = "",
            string foodItems = "",
            double latitude = -1d,
            double longitude = -1d
        )
        {
            if (facilityType.IsInValid()) throw new FoodTruckInvalidParametersException(INVALID_FACILITY_TYPE);
            if (string.IsNullOrEmpty(name)) throw new FoodTruckInvalidParametersException(INVALID_NAME);
            if (string.IsNullOrEmpty(address)) throw new FoodTruckInvalidParametersException(INVALID_ADDRESS);
            
            FacilityType = facilityType;
            Name = name;
            LocationDescription = locationDescription;
            Address = address;
            FoodItems = foodItems;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}