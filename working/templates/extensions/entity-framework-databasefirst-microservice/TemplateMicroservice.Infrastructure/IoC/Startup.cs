using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories;
using TemplateMicroservice.Domain.Services;
using TemplateMicroservice.Infrastructure.Data.DatabaseContext;
using TemplateMicroservice.Infrastructure.Data.Repositories;

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

            services.AddScoped<DataContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}