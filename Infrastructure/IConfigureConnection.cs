using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IConfigureConnection
    {
        void Configure(DbContextOptionsBuilder builder);
    }
}