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
            cbItemType.SelectedItem = "All";
            dataGridItems.Columns["column_acquired"].DefaultCellStyle.Format = "d";
            dataGridItems.Columns["column_last_rent"].DefaultCellStyle.Format = "d";
            LoadHistories();
        }

        private void LoadHistories()
        {
            string query = HelperQuery.HistoryGeneralInformation();
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dataGridItems.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewRow row;
            string selectedType = cbItemType.SelectedItem.ToString().ToLower();

            // Need to make words singular to match item type.
            if(selectedType == "helmets") { selectedType = "helmet"; }
            else if(selectedType == "jackets") { selectedType = "jacket"; }

            int length = dataGridItems.Rows.Count;
            for (int i = 0; i < length; ++i)
            {
                row = dataGridItems.Rows[i];
                string itemType = row.Cells["column_item_type"].Value.ToString();
                if(selectedType == "all") 
                {
                    row.Visible = true;
                }
                else if (itemType != selectedType)
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = true;
                }
            }
        }

        private void dataGridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridHistory.Rows.Clear();
            DataGridViewRow row = dataGridItems.CurrentRow;
            Guid itemId = (Guid)row.Cells["column_item_id"].Value;

            string query = HelperQuery.HistoryClientAndDates(itemId);
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dataGridHistory.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            connection.Close();
        }
    }
}
