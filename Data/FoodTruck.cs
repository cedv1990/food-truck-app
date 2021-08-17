using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Exceptions.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;

namespace Data
{
    public sealed partial class FoodTruckContext
    {
        public DbSet<FoodTruck> FoodTrucks { get; set; }

        public IEnumerable<FoodTruck> GetFoodTruckListService()
        {
            return FoodTrucks.Select(x => x).ToList();
            
            return FoodTrucks.ToList();
        }

        public async Task<IEnumerable<FoodTruckDTO>> GetFoodTruckListFromExternalService()
        {
            var client = new HttpClient();
            try
            {
                var response = await client.GetFromJsonAsync<IEnumerable<FoodTruckDTO>>("https://data.sfgov.org/resource/rqzj-sfat.json");
                return response;
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode.HasValue)
                {
                    throw new FoodTruckExceptionHttp(ex.StatusCode.Value, ex.Message);
                }
            }
            return null;
        }

        public IEnumerable<Models.FoodTruck> SaveFoodTruckList(IEnumerable<FoodTruck> list)
        {
            try
            {
                FoodTrucks.AddRange(list);
                SaveChanges();
                return GetFoodTruckListService();
            }
            catch (Exception ex)
            {
                throw new FoodTruckInvalidParametersException("Error trying to save data in db");
            }
        }
    }
}