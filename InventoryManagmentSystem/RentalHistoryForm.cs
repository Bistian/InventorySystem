using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class RentalHistoryForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        #endregion SQL_Variables

        public RentalHistoryForm()
        {
            InitializeComponent();
        }

        private void LoadItems()
        {
            string query = @"
              SELECT Id, Brand,  
            ";
        }

        public bool AddToHistories(Guid itemId, Guid clietId, DateTime? rentDate, DateTime returnDate)
        {
            DateTime rent = rentDate ?? DateTime.Now;
            string query = @"
                INSERT INTO rbHistories (ItemId, ClientId, RentDate, ReturnDate)
                VALUES (@ItemId, @ClientId, @Rent, @Return);
            ";
            HelperFunctions.RemoveLineBreaksFromString(query);

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
                command.Parameters.AddWithValue("@ClietId", clietId);
                command.Parameters.AddWithValue("@RentDate", rentDate);
                if (returnDate.Equals(DateTime.MinValue))
                {
                    command.Parameters.AddWithValue("@ReturnDate", null);
                }
                else 
                { 
                    command.Parameters.AddWithValue("@ReturnDate", returnDate); 
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}
