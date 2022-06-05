using Datactx.Dbcontext;
using Microsoft.EntityFrameworkCore;

namespace CMS_Lucky
{
    public static class DataConnect
    {
        public static IServiceCollection ServicesCollection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseContext"),
              x => x.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)), ServiceLifetime.Transient);

            return service;
        }
    }
}
