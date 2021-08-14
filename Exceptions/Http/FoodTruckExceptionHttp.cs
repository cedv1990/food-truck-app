using System.Net;

namespace Exceptions.Http
{
    public class FoodTruckExceptionHttp : FoodTruckException
    {
        public HttpStatusCode StatusCode;
        
        public FoodTruckExceptionHttp(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}