namespace Tests.Domain
{
    using Entities;
    using Entities.Enums;
    using NUnit.Framework;
    using Exceptions.Http;

    public class TruckTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldOnCreateANewFoodTruckValidateFacilityType()
        {
            var truck = new FoodTruck(FacilityType.Truck);

            Assert.AreEqual(FacilityType.Truck, truck.FacilityType);

            var cart = new FoodTruck(FacilityType.Cart);
            
            Assert.AreEqual(FacilityType.Cart, cart.FacilityType);

            Assert.Throws<FoodTruckInvalidParametersException>(() => new FoodTruck((FacilityType)3), FoodTruck.INVALID_FACILITY_TYPE);
        }

        [Test]
        public void ShouldOnCreateANewFoodTruckValidateNotEmptyName()
        {
            var name = "Test Truck Inc.";
            var truck = new FoodTruck(FacilityType.Truck, name);
            
            Assert.AreEqual(name, truck.Name);

            Assert.Throws<FoodTruckInvalidParametersException>(() => new FoodTruck(FacilityType.Truck, ""), FoodTruck.INVALID_NAME);
        }
    }
}