using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using InventoryManagmentSystem.Rental_Forms;
using Microsoft.VisualBasic.Devices;
using System.Net.Sockets;

namespace InventoryManagmentSystem
{
    public partial class InventoryForm : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        private List<Item> itemList = new List<Item>();

        public InventoryForm(string ItemType)
        {
            InitializeComponent();
            checkActive.Checked = true;
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            itemList = HelperSql.ItemFindAllWithSpecifications(connection);
            DisplayItems();
            SetItemType(ItemType);
        }

        private void SetItemType(string itemType)
        {
            if(itemType == null) { return; }
            if(cbItemType.Items.Count == 0)  { return; }

            int index = cbItemType.Items.IndexOf(itemType);
            if(index == -1) { return; }

            cbItemType.SelectedIndex = index;
        }

        private void DisplayItems()
        {
            dataGridInv.Rows.Clear();
            int count = 1;
            foreach(Item item in itemList)
            {
                string condition = item.GetColumnValue("Condition");
                if (checkActive.Checked && condition == "Retired") { continue; }
                if (checkRetired.Checked && condition != "Retired") { continue; }

                string type = item.GetColumnValue("ItemType");
                if(type != cbItemType.Text) { continue; }

                bool isSearchBarMatching = SearchBarIsMatching(item);
                if(!isSearchBarMatching) { continue; }

                AddItemToGrid(item, count);
                count++;
            }
        }

        private bool SearchBarIsMatching(Item item)
        {
            if(searchBar.Text.Length == 0) { return true; }
            string like = searchBar.Text;
            string serial = item.GetColumnValue("SerialNumber");
            string brand = item.GetColumnValue("Brand");

            if (HelperFunctions.IsSubstring(serial, like)) { return true; }
            if (HelperFunctions.IsSubstring(brand, like)) { return true; }

            string type = item.GetColumnValue("ItemType");
            if (type == "boots")
            {
                string size = item.GetColumnValue("Size");
                return size == like ? true : false;
            }
            else if (type == "helmet")
            {
                string color = item.GetColumnValue("Color");
                return color == like ? true : false;
            }
            else if (type == "jacket")
            {
                string size = item.GetColumnValue("Size");
                return size == like ? true : false;
            }
            else if (type == "mask")
            {
                string size = item.GetColumnValue("Size");
                return size == like ? true : false;
            }
            else if (type == "pants")
            {
                string size = item.GetColumnValue("Size");
                return size == like ? true : false;
            }
            return false;
        }

        private void AddItemToGrid(Item item, int count)
        {

            dataGridInv.Rows.Add(count,
               item.GetColumnValue("Id"),
               item.GetColumnValue("Brand"),
               item.GetColumnValue("SerialNumber"),
               item.GetColumnValue("Condition"),
               item.GetColumnValue("AcquisitionDate"),
               item.GetColumnValue("ManufactureDate"),
               item.GetColumnValue("Location"),
               item.GetColumnValue("Size"),
               item.GetColumnValue("Material"),
               item.GetColumnValue("Color"));
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset search bar.
            searchBar.Text = "";
            ChangeVisibleColumns();
            DisplayItems();
        }

        private void ChangeVisibleColumns()
        {
            if (cbItemType.Text == "boots")
            {
                dataGridInv.Columns["column_size"].Visible = true;
                dataGridInv.Columns["column_material"].Visible = true;
                dataGridInv.Columns["column_color"].Visible = false;
            }
            else if (cbItemType.Text == "helmet")
            {
                dataGridInv.Columns["column_size"].Visible = false;
                dataGridInv.Columns["column_material"].Visible = false;
                dataGridInv.Columns["column_color"].Visible = true;
            }
            else if (cbItemType.Text == "jacket" || cbItemType.Text == "pants" || cbItemType.Text == "mask")
            {
                dataGridInv.Columns["column_size"].Visible = true;
                dataGridInv.Columns["column_material"].Visible = false;
                dataGridInv.Columns["column_color"].Visible = false;
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            DisplayItems();
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            var row = dataGridInv.Rows[e.RowIndex];
            string colName = dataGridInv.Columns[e.ColumnIndex].Name;
            string itemType = cbItemType.Text.ToLower();
            string serialNumber = dataGridInv.Rows[e.RowIndex].Cells["column_serial"].Value.ToString();
            try
            {
                if (colName == "column_edit")
                {
                    if (itemType == "boots") { UpdateBoots(e); }
                    else if (itemType == "helmet") { UpdateHelmet(e); }
                    else if (itemType == "jacket" || itemType == "pants" || itemType == "mask") { UpdateJacketOrPantsOrMasks(e); }
                    DisplayItems();
                }
                else if (colName == "column_delete")
                {
                    /*DeleteItem(serialNumber);
                    LoadInventory();*/
                }
                else
                {
                    string itemId = row.Cells["column_item_id"].Value.ToString();
                    var form = new RentalHistoryForm(itemId, string.Empty);

                    if(form.IsDisposed) { MessageBox.Show("No history found"); }
                    else
                    {
                        var parentForm = this.ParentForm as MainForm;
                        parentForm.openChildForm(form);
                    } 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateBoots(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text.ToLower(), true);
            itemForm.cbItemType.Text = cbItemType.Text.ToLower();
            itemForm.tbSerialNumber.Text = GetCellValueAsString(e, "column_serial");
            itemForm.tbSerialNumber.Enabled = false;
            itemForm.cbBrand.Text = GetCellValueAsString(e, "column_brand");
            itemForm.cbCondition.Text = GetCellValueAsString(e, "column_condition");
            itemForm.dtManufacture.Text = GetCellValueAsString(e, "column_manufacture_date");
            itemForm.cbSize.Text = GetCellValueAsString(e, "column_size");
            itemForm.cbMaterial.Text = GetCellValueAsString(e, "column_material");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateHelmet(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);
            itemForm.cbItemType.Text = cbItemType.Text.ToLower();
            itemForm.tbSerialNumber.Text = GetCellValueAsString(e, "column_serial");
            itemForm.tbSerialNumber.Enabled = false;
            itemForm.cbBrand.Text = GetCellValueAsString(e, "column_brand");
            itemForm.cbCondition.Text = GetCellValueAsString(e, "column_condition");
            itemForm.dtManufacture.Text = GetCellValueAsString(e, "column_manufacture_date");
            itemForm.cbSize.Text = GetCellValueAsString(e, "column_size");
            itemForm.cbColor.Text = GetCellValueAsString(e, "column_color");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateJacketOrPantsOrMasks(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);

            itemForm.cbItemType.Text = cbItemType.Text.ToLower();
            itemForm.tbSerialNumber.Text = dataGridInv.Rows[e.RowIndex].Cells["column_serial"].Value.ToString();
            itemForm.tbSerialNumber.Enabled = false;
            itemForm.cbBrand.Text = dataGridInv.Rows[e.RowIndex].Cells["column_brand"].Value.ToString();
            itemForm.cbCondition.Text = dataGridInv.Rows[e.RowIndex].Cells["column_condition"].Value.ToString();
            itemForm.dtManufacture.Text = dataGridInv.Rows[e.RowIndex].Cells["column_manufacture_date"].Value.ToString();
            itemForm.cbSize.Text = dataGridInv.Rows[e.RowIndex].Cells["column_size"].Value.ToString();
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }
        
        private void DeleteItem(string serialNumber)
        {
            string message = "Are you sure you want to delete this item?";
            string title = "Delete Record";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return; }

            string query = $"SELECT ItemId FROM tbItems WHERE SerialNumber = '{serialNumber}'";
            // TODO: Do I really want to delete?
            Guid uuid;
            
            string table = "tb" + cbItemType.Text;

            if(cbItemType.Text == "Jacket" || cbItemType.Text == "Helmet" || cbItemType.Text == "Mask")
            {
                table += "s";
            }
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM {table} WHERE SerialNumber LIKE '{serialNumber}'", connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item has been successfully deleted");
            }
            catch(Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to delete the item.");
            }
        }

        private string GetCellValueAsString(DataGridViewCellEventArgs e, string cellName)
        {
            return dataGridInv.Rows[e.RowIndex].Cells[cellName].Value.ToString();
        }

        private void checkAll_Click(object sender, EventArgs e)
        {
            checkRetired.Checked = false;
            checkActive.Checked = false;
            DisplayItems();
        }

        private void checkRetired_Click(object sender, EventArgs e)
        {
            checkAll.Checked = false;
            checkActive.Checked = false;
            DisplayItems();
        }

        private void checkActive_Click(object sender, EventArgs e)
        {
            checkRetired.Checked = false;
            checkAll.Checked = false;
            DisplayItems();
        }

        private void UsersButton_Click_1(object sender, EventArgs e)
        {
            NewItemForm ModForm = new NewItemForm();
            ModForm.ShowDialog();
            DisplayItems();
        }
    }
}
