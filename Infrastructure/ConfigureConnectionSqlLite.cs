using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ConfigureConnectionSqlLite: IConfigureConnection
    {
        public void Configure(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"Data Source=data.db");
        }
    }
}