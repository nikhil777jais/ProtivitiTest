using ProtivitiTest.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using ProtivitiTest.WebAPI.Data;
using ProtivitiTest.WebAPI.Repositories.CustomerRepo;
using ProtivitiTest.WebAPI.Services.AvatarService;

namespace ProtivitiTest.WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            #region configure db
            
            services.AddDbContext<SqliteDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("SqlLiteConnection"));
            });

            #endregion

            #region injecting dependencies
            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddHttpClient<AvatarService>();

            #endregion

            #region auto mapper config   

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            #endregion
            
            return services;
        }
    }
}
