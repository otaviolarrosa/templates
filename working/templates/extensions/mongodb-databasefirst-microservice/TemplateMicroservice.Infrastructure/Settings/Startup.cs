using Microsoft.Extensions.Configuration;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.Settings
{
    public static class Startup
    {
        public static void SetupSettings(this IConfiguration configuration)
        {
            AppSettings.Settings = configuration;
        }
    }
}