using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ConfigureConnectionInMemory: IConfigureConnection
    {
        public void Configure(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("InMemory");
        }
    }
}