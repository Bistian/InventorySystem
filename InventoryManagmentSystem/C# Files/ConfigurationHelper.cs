using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace InventoryManagmentSystem.C__Files
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Use executable's directory
            .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json"), optional: false, reloadOnChange: true)
            .Build();
        }

        public static string GetConnectionString(string name)
        {
            string connectionString = Configuration["ConnectionStrings:" + name];
            if (connectionString == null)
            {
                throw new Exception($"Connection string '{name}' not found.");
            }
            return connectionString;
        }

        public static T GetSection<T>(string sectionName)
        {
            return Configuration.GetSection(sectionName).Get<T>();
        }
    }
}
