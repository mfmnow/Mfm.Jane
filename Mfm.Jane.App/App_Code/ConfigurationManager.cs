using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Data.Services;
using Mfm.Jane.Domain.Contracts;
using Mfm.Jane.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Mfm.Jane.App.App_Code
{
    public class ConfigurationManager
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("DefaultConnection")
                .Replace("{AppDir}", Directory.GetCurrentDirectory());

            services.AddDbContext<JaneTestDbContext>(options =>
            options.UseSqlServer(_connectionString));

            //ConfigureSettings(services, configuration);
            ConfigureDataServices(services);
            ConfigureDomainServices(services);
        }

        /*private static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            var config = new AppSettings();
            configuration.Bind("AppSettings", config);
            services.AddSingleton(config);
        }*/

        private static void ConfigureDataServices(IServiceCollection services)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ITestEntityDataAccess, TestEntityDataAccess>();
            services.AddScoped<IJaneTestDbContext, JaneTestDbContext>();            
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<ITestModelDomainService, TestModelDomainService>();
        }

    }
}
