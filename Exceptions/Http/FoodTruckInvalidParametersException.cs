using System.Net;

namespace Exceptions.Http
{
    public class FoodTruckInvalidParametersException : FoodTruckExceptionHttp
    {
        public FoodTruckInvalidParametersException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}