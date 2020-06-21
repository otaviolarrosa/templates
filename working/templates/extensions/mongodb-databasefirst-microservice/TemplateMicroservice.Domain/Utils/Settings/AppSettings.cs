using Microsoft.Extensions.Configuration;

namespace TemplateMicroservice.Infrastructure.Utils.Settings
{
    public static class AppSettings
    {
        public static IConfiguration Settings { get; set; }

        public static string GetAppSetting(string key)
        {
            var result = Settings.GetSection(key).Value;
            return result;
        }
    }
}