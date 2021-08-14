using System.Threading.Tasks;
using Abstractions.Application;

namespace API.Controllers
{
    using Models;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    
    [ApiController]
    [Route("[controller]")]
    public class FoodTruckController : ControllerBase
    {
        private readonly ILogger<FoodTruckController> _logger;
        private IFoodTruck _foodTruck;

        public FoodTruckController(ILogger<FoodTruckController> logger, IFoodTruck foodTruck)
        {
            _foodTruck = foodTruck;
            _logger = logger;
        }

        [HttpGet]
        public Task<IEnumerable<FoodTruck>> Get()
        {
            return _foodTruck.GetFoodTruckList();
        }
    }
}