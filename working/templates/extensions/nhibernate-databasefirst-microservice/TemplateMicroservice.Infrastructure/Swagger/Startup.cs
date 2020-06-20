using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.Swagger
{
    public static class Startup
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc(AppSettings.GetAppSetting("SwaggerSettings:Version"),
                    new OpenApiInfo
                    {
                        Title = AppSettings.GetAppSetting("SwaggerSettings:Title"),
                        Version = AppSettings.GetAppSetting("SwaggerSettings:Version"),
                        Description = AppSettings.GetAppSetting("SwaggerSettings:Description")
                    });
            });
        }

        public static void AddSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = AppSettings.GetAppSetting("SwaggerSettings:RoutePrefix");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", AppSettings.GetAppSetting("SwaggerSettings:Title"));
            });
        }
    }
}