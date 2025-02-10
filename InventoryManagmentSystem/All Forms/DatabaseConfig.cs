using InventoryManagmentSystem.C__Files;

namespace InventoryManagmentSystem
{
    public static class DatabaseConfig
    {
        private static string filePath = @"C:\Code\Projects\dataReal (1).mdf";
        public static string GetConnectionString(string customFilePath = null)
        {
            var environment = ConfigurationHelper.Configuration["Environment"];

            if (environment == "Local")
            {

                string connectionString = ConfigurationHelper.Configuration["ConnectionStrings:Local"];
                if (customFilePath == null)
                {
                    connectionString = connectionString.Replace("{filePath}", filePath);
                }
                else
                {
                    connectionString = connectionString.Replace("{filePath}", customFilePath);
                }
                return connectionString;
            }

            return ConfigurationHelper.Configuration["ConnectionStrings:Remote"];
        }
    }
}
