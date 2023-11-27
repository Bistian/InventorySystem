using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace InventoryManagmentSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #if DEBUG
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            #endif

            // Get the current connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // checking if database exists
                try
                {
                    connection.Open();
                    connection.Close();
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                    try
                    {
                        Console.WriteLine(ex.Message);
                        Application.Run(new DatabaseCreationModule());
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }    
                
            }
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