using InventoryManagmentSystem.All_Forms;
using InventoryManagmentSystem.C__Files;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace InventoryManagmentSystem
{
    internal static class Program
    {
        // Global settings
        public static SettingsManager SettingsManager { get; private set; }
        public static string ConnectionString { get; private set; }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the settings manager
            SettingsManager = new SettingsManager();

            // Initialize settings manager and ensure settings are loaded
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

        static void Debug()
        {
            #if DEBUG
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            #endif
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            MessageBox.Show($"An unhandled exception occurred: {exception?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}