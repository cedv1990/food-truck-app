using Microsoft.EntityFrameworkCore;

namespace Abstractions.Infrastructure
{
    public interface IConfigureConnection
    {
        void Configure(DbContextOptionsBuilder builder);
    }
}