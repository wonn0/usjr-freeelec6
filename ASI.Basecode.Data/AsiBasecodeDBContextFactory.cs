using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ASI.Basecode.Data
{
    public class AsiBasecodeDBContextFactory : IDesignTimeDbContextFactory<AsiBasecodeDBContext>
    {
        public AsiBasecodeDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("/Users/garfieldgreglim/Documents/Alliance/usjr-freeelec6/ASI.Basecode.WebApp/appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AsiBasecodeDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new AsiBasecodeDBContext(optionsBuilder.Options);
        }
    }
}
