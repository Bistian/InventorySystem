using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InventoryManagmentSystem.Config_Files;

namespace InventoryManagmentSystem
{
    internal static class Program
    {
        // Global settings
        public static SettingsManager SettingsManager
        {
            get; private set;
        }

        public static string ConnectionString
        {
            get; private set;
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Debug();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the settings manager (this will load settings or create the file if missing)
            SettingsManager = new SettingsManager();

            // Get the current connection string
            ConnectionString = DatabaseConfig.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("Could not connect to database");
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            MessageBox.Show($"An unhandled exception occurred: {exception?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Hack to normalize class activities
        private static void UpdateClassActivity(SqlConnection connection)
        {
            string query = "UPDATE TBCLASSES " +
                           "SET isFinished = 'true' " +
                           "WHERE endDate <= CAST(GETDATE() AS DATE); ";

            var command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private static void Debug()
        {
#if DEBUG
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
        }
    }
}
