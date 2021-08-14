using System.Collections.Generic;
using Abstractions.DataServices;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed partial class FoodTruckContext : DbContext, IFoodTruckServices
    {
        public FoodTruckContext(DbContextOptions<FoodTruckContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}