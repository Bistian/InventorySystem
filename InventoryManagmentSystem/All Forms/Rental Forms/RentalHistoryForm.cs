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
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        List<Item> historyList;

        public RentalHistoryForm(string itemId, string clientId)
        {
            InitializeComponent();
            historyList = HelperSql.HistoryFindFull(connection, itemId, clientId);
            if (historyList.Count == 0) { this.Close(); return; }
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            dataGridHistory.Rows.Clear();
            foreach(var history in historyList)
            {
                dataGridHistory.Rows.Add(
                    history.GetColumnValue("Id"),
                    history.GetColumnValue("ClientId"),
                    history.GetColumnValue("ItemId"), 
                    history.GetColumnValue("Name"),
                    history.GetColumnValue("ItemType"),
                    history.GetColumnValue("SerialNumber"),
                    history.GetColumnValue("RentDate"),
                    history.GetColumnValue("ReturnDate"));
            }
        }

        private void clickSearch(string message, string itemId, string clientId)
        {
            if(itemId == string.Empty && clientId == string.Empty) { return; }

            bool choice = HelperFunctions.YesNoMessageBox(message, "Search History");
            if (!choice) { return; }

            historyList.Clear();
            historyList = HelperSql.HistoryFindFull(connection, itemId, clientId);
            LoadDataGrid();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            InventoryForm form = new InventoryForm();
            var parentForm = this.ParentForm as MainForm;
            parentForm.openChildForm(form);
            this.Close();
        }

        private void dataGridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridHistory.Rows[e.RowIndex];
            var column = dataGridHistory.Columns[e.ColumnIndex].Name;
            
            if(column == "column_client_name")
            {
                string clientId = row.Cells["column_client_id"].Value.ToString();
                string message = "Do you want to search for this client's rental history?";
                clickSearch(message, string.Empty, clientId);
            }

            else if (column == "column_item_type")
            {
                string itemId = row.Cells["column_item_id"].Value.ToString();
                string message = "Do you want to search for this item's rental history?";
                clickSearch(message, itemId, string.Empty);
            }
        }
    }
}
