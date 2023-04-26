using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
                catch
                {
                    Application.Run(new DatabaseCreationModule());

                }    
                
            }
        }
    }
}