using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Pro.TagHelpers
{
    public class AppConfig
    {

        private static IConfigurationBuilder builder = new ConfigurationBuilder()
                                                     .SetBasePath(Directory.GetCurrentDirectory())
                                                     .AddJsonFile($"appsettings.json")
                                                     .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true);
        private static IConfigurationRoot AppSettings
        {
            get
            {
                return builder.Build();
            }
        }



        public static string FileBase
        {
            get
            {
                return AppSettings.GetValue<String>("FileBase");
            }
        }

        public static string DownloadBase
        {
            get
            {
                return AppSettings.GetValue<String>("DownloadBase");
            }
        }
    }
}
