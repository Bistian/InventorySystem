namespace InventoryManagmentSystem.Config_Files
{
    internal class DatabaseConfig
    {
        // Use your local _database path for testing
        private static string filePath = @"C:\Code\Projects\dataReal_1.mdf";
        //private static string filePath = @"C:\Users\ferna\firetec_local.mdf";
        
        /// <summary>
        /// Get connection string to access _database
        /// </summary>
        /// <param name="customFilePath">Give a dynamic file path for _database</param>
        /// <returns></returns>
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
