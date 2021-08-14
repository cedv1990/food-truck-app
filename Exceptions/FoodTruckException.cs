using System;

namespace Exceptions
{
    public class FoodTruckException : Exception
    {
        public FoodTruckException(string message) : base(message)
        {
        }
    }
}