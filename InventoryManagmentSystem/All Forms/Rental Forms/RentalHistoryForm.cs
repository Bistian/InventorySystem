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
        List<History> historyList = new List<History>();

        public RentalHistoryForm(string itemType = null, string serial = null)
        {
            InitializeComponent();
            dataGridItems.Columns["column_acquired"].DefaultCellStyle.Format = "d";
            dataGridItems.Columns["column_last_rent"].DefaultCellStyle.Format = "d";
            dataGridHistory.Columns["column_rented"].DefaultCellStyle.Format = "d";
            dataGridHistory.Columns["column_returned"].DefaultCellStyle.Format = "d";
            LoadHistories();

            // Add item types
            cbItemType.Items.Add("all");
            cbItemType.SelectedIndex = 0;
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            if (itemType != null && serial != null)
            {
                InitWithSelectedItem(itemType, serial);
            } 
            else
            {
                cbItemType.SelectedItem = "All";
            }
        }

        public RentalHistoryForm(Guid itemId, Guid clientId)
        {
            historyList = HelperSql.HistoryFindItem(connection, itemId, clientId);
            if (historyList.Count == 0) { this.Close(); return; }
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            int count = 1;
            foreach(History history in historyList)
            {
                var client = HelperSql.ClientFindById(connection, history.ClientId);
                dataGridHistory.Rows.Add(count++,
                    history.ClientId,
                    client["Name"],
                    history.RentDate, 
                    history.ReturnDate);
            }
        }

        private void InitWithSelectedItem(string itemType, string serial)
        {
            // Click the item type.
            cbItemType.SelectedItem = itemType;
            SwapVisibleRows();

            // Select a row by serial number.
            for (int i = 0; i < dataGridItems.Rows.Count; ++i)
            {
                string serialNumber = dataGridItems.Rows[i].Cells["column_serial"].Value.ToString();
                if (serialNumber != serial) { continue; }

                dataGridItems.Rows[i].Selected = true;
                LoadItemHistory(i);
                break;
            }
        }

        private void LoadHistories()
        {
        }

        private void LoadItemHistory(int rowIndex = -1)
        {
            dataGridHistory.Rows.Clear();

            DataGridViewRow row = dataGridItems.CurrentRow;
            if(rowIndex > 0)
            {
                row = dataGridItems.Rows[rowIndex];
            }
            if(row == null) { return; }

            Guid itemId = (Guid)row.Cells["column_item_id"].Value;

            var list = HelperSql.HistoryFindItem(connection, itemId, Guid.Empty);
            if(list == null) { return; }

            foreach(History history in list)
            {
                dataGridHistory.Rows.Add(history.ItemId, history.ClientId, history.RentDate, history.ReturnDate);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            InventoryForm form = new InventoryForm(null);
            var parentForm = this.ParentForm as MainForm;
            parentForm.openChildForm(form);
            this.Close();
        }

        private void SwapVisibleRows()
        {
            DataGridViewRow row;

            string selectedType = (string)cbItemType.SelectedItem;

            int length = dataGridItems.Rows.Count;
            for (int i = 0; i < length; ++i)
            {
                row = dataGridItems.Rows[i];
                string itemType = row.Cells["column_item_type"].Value.ToString();
                // Hide rows that are filtered out.
                if (selectedType == "all")
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

                if (checkRetired.Checked != true)
                {
                    string retired = row.Cells["column_condition"].Value.ToString();
                    if (retired == "Retired")
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwapVisibleRows();
        }

        private void dataGridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadItemHistory();
        }

        private void dataGridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            if (parentForm != null) 
            {
                parentForm.ColorTabSwitch("ActiveRentals", false);
                parentForm.openChildForm(new ExistingCustomerModuleForm());
            }
            else
            {
                // This is inside of Settings, not Main.
                var parent = this.ParentForm as ToolsForm;
                var grandparent = parent.ParentForm as MainForm;
                grandparent.OpenNavBar("Rentals");
                grandparent.ColorTabSwitch("ActiveRentals", false);
                grandparent.openChildForm(new ExistingCustomerModuleForm());
            }
            this.Close();
        }

        private void checkRetired_Click(object sender, EventArgs e)
        {
            SwapVisibleRows();
        }
    }
}
