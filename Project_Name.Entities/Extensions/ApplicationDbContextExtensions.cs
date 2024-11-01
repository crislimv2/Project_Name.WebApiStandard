using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Name.Entities.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseOpenIddict();
            });
        }
    }
}
