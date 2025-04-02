using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Extensions
{
    public static class MyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            var dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"Server=tcp:{dbHostname},1433;Initial Catalog={dbName};Persist Security Info=False;User ID={dbUser};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
