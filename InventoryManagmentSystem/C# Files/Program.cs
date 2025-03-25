using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static InventoryManagmentSystem.Academy.AcademyForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms.VisualStyles;

namespace InventoryManagmentSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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
                    UpdateClassActivity(connection);
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

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            MessageBox.Show($"An unhandled exception occurred: {exception?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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
    }
}
