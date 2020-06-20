using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.Domain.Services;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.IoC
{
    public static class Startup
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(_ => _
            .FromAssemblies(
                typeof(HealthCheckService).Assembly, //Domain
                typeof(Startup).Assembly) //Infra
            .AddClasses()
            .AsImplementedInterfaces());
        }
    }
}