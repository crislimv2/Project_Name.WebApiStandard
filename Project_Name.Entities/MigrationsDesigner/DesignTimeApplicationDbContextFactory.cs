using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project_Name.Entities.MigrationsDesigner
{
    internal class DesignTimeApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=project_pertama;Username=postgres;Password=123");
            optionsBuilder.UseOpenIddict();

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
