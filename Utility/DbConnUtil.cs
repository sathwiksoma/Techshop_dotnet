using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Utility
{
    internal static class DbConnUtil
    {
        private static IConfiguration _configuration;
        static DbConnUtil()
        {
            GetAppSettingsFileName();
        }

        private static void GetAppSettingsFileName()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }
        public static string GetConnectionString()
        {
            return _configuration.GetConnectionString("LocalConnString");
        }
    }
}
