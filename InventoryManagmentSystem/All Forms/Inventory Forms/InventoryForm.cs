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
        private List<Item> bootsList = new List<Item>();
        private List<Item> helmetsList = new List<Item>();
        private List<Item> jacketsList = new List<Item>();
        private List<Item> masksList = new List<Item>();
        private List<Item> pantsList = new List<Item>();

        public InventoryForm(string ItemType)
        {
            InitializeComponent();
            checkActive.Checked = true;
            LoadInventory();
            HelperFunctions.LoadItemTypes(connection, ref cbItemType);
            InitializeItems();
            SetItemType(ItemType);
        }

        private void SetItemType(string itemType)
        {
            if(itemType == null) { return; }
            if(cbItemType.Items.Count == 0)  { return; }

            if (itemType.ToLower() == "jacket")
            {
                cbItemType.SelectedIndex = 0;
            }
            else if (itemType.ToLower() == "pants")
            {
                cbItemType.SelectedIndex = 1;
            }
            else if (itemType.ToLower() == "boots")
            {
                cbItemType.SelectedIndex = 2;
            }
            else if (itemType.ToLower() == "helmet")
            {
                cbItemType.SelectedIndex = 3;
            }
            else if (itemType.ToLower() == "mask")
            {
                cbItemType.SelectedIndex = 4;
            }
            else
            {
                cbItemType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Add retired condition to item queries.
        /// </summary>
        /// <param name="initialQuery">Initial part of the query.</param>
        /// <returns>Complete query</returns>

        private void InitializeItems()
        {
            bootsList = HelperDatabaseCall.BootsFindAll(connection);
            helmetsList = HelperDatabaseCall.HelmetFindAll(connection);
            jacketsList = HelperDatabaseCall.JacketFindAll(connection);
            masksList = HelperDatabaseCall.MaskFindAll(connection);
            pantsList = HelperDatabaseCall.PantsFindAll(connection);
        }

        private void DisplayBoots()
        {
            int count = 0;
            foreach (Item item in bootsList)
            {
                if (checkActive.Checked && item.Condition == "Retired") { continue; }
                if (checkRetired.Checked && item.Condition != "Retired") { continue; }
                count++;
                var boots = (Boots)item.Specifications;
                if(searchBar.Text.Length > 0)
                {
                    string like = searchBar.Text;
                    if (boots.Size == like) { }
                    else if (HelperFunctions.IsSubstring(item.SerialNumber, like)) { }
                    else if (HelperFunctions.IsSubstring(boots.Brand, like)) { }
                    else { continue; }
                }
                dataGridInv.Rows.Add(count,
                    item.Id,
                    boots.Brand,
                    item.SerialNumber,
                    item.Condition,
                    boots.AcquisitionDate,
                    boots.ManufactureDate,
                    item.Location,
                    boots.Size,
                    boots.Material, "Color");
            }
        }

        private void DisplayHelmets()
        {
            int count = 0;
            foreach (Item item in helmetsList)
            {
                if (checkActive.Checked && item.Condition == "Retired") { continue; }
                if (checkRetired.Checked && item.Condition != "Retired") { continue; }
                count++;
                var helmet = (Helmet)item.Specifications;
                if (searchBar.Text.Length > 0)
                {
                    string like = searchBar.Text;
                    if (HelperFunctions.IsSubstring(item.SerialNumber, like)) { }
                    else if (HelperFunctions.IsSubstring(helmet.Brand, like)) { }
                    else { continue; }
                }
                dataGridInv.Rows.Add(count,
                    item.Id,
                    helmet.Brand,
                    item.SerialNumber,
                    item.Condition,
                    helmet.AcquisitionDate,
                    helmet.ManufactureDate,
                    item.Location,
                    "Size", "Material",
                    helmet.Color);
            }
        }

        private void DisplayJackets()
        {
            int count = 0;
            foreach (Item item in jacketsList)
            {
                if (checkActive.Checked && item.Condition == "Retired") { continue; }
                if (checkRetired.Checked && item.Condition != "Retired") { continue; }
                count++;
                var jacket = (Jacket)item.Specifications;
                if (searchBar.Text.Length > 0)
                {
                    string like = searchBar.Text;
                    if (jacket.Size == like) { }
                    else if (HelperFunctions.IsSubstring(item.SerialNumber, like)) { }
                    else if (HelperFunctions.IsSubstring(jacket.Brand, like)) { }
                    else { continue; }
                }
                dataGridInv.Rows.Add(count,
                    item.Id,
                    jacket.Brand,
                    item.SerialNumber,
                    item.Condition,
                    jacket.AcquisitionDate,
                    jacket.ManufactureDate,
                    item.Location,
                    jacket.Size,
                    "Size", "Color");
            }
        }

        private void DisplayMasks()
        {
            int count = 0;
            foreach (Item item in masksList)
            {
                if (checkActive.Checked && item.Condition == "Retired") { continue; }
                if (checkRetired.Checked && item.Condition != "Retired") { continue; }
                count++;
                var mask = (Mask)item.Specifications;
                if (searchBar.Text.Length > 0)
                {
                    string like = searchBar.Text;
                    if (mask.Size == like) { }
                    else if (HelperFunctions.IsSubstring(item.SerialNumber, like)) { }
                    else if (HelperFunctions.IsSubstring(mask.Brand, like)) { }
                    else { continue; }
                }
                dataGridInv.Rows.Add(count,
                    item.Id,
                    mask.Brand,
                    item.SerialNumber,
                    item.Condition,
                    mask.AcquisitionDate,
                    mask.ManufactureDate,
                    item.Location,
                    mask.Size,
                    "Size", "Color");
            }
        }

        private void DisplayPants()
        {
            int count = 0;
            foreach (Item item in pantsList)
            {
                if (checkActive.Checked && item.Condition == "Retired") { continue; }
                if (checkRetired.Checked && item.Condition != "Retired") { continue; }
                count++;
                var pants = (Pants)item.Specifications;
                if (searchBar.Text.Length > 0)
                {
                    string like = searchBar.Text;
                    if (pants.Size == like) { }
                    else if (HelperFunctions.IsSubstring(item.SerialNumber, like)) { }
                    else if (HelperFunctions.IsSubstring(pants.Brand, like)) { }
                    else { continue; }
                }
                dataGridInv.Rows.Add(count,
                    item.Id,
                    pants.Brand,
                    item.SerialNumber,
                    item.Condition,
                    pants.AcquisitionDate,
                    pants.ManufactureDate,
                    item.Location,
                    pants.Size,
                    "Size", "Color");
            }
        }

        /// <summary>
        /// loads different tables
        /// </summary>
        public void LoadInventory()
        {
            if (cbItemType.SelectedIndex == -1) { return; }
            dataGridInv.Rows.Clear();
            dataGridInv.Columns["column_acquisition_date"].DefaultCellStyle.Format = "d";
            dataGridInv.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";

            string itemType = cbItemType.Text.ToLower();
            if (itemType == "boots") { DisplayBoots(); }
            else if (itemType == "helmet") { DisplayHelmets(); }
            else if (itemType == "jacket") { DisplayJackets(); }
            else if (itemType == "mask") { DisplayMasks(); }
            else if(itemType == "pants") { DisplayPants(); }
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset search bar.
            searchBar.Text = "";
            ChangeVisibleColumns();
            LoadInventory();
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
            LoadInventory();
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

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
                    LoadInventory();
                }
                else if (colName == "column_delete")
                {
                    /*DeleteItem(serialNumber);
                    LoadInventory();*/
                }
                else
                {
                    // Open History.
                    RentalHistoryForm form = new RentalHistoryForm(itemType, serialNumber);
                    var parentForm = this.ParentForm as MainForm;
                    parentForm.openChildForm(form);
                    this.Close();
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
            LoadInventory();
        }

        private void checkRetired_Click(object sender, EventArgs e)
        {
            checkAll.Checked = false;
            checkActive.Checked = false;
            LoadInventory();
        }

        private void checkActive_Click(object sender, EventArgs e)
        {
            checkRetired.Checked = false;
            checkAll.Checked = false;
            LoadInventory();
        }

        private void UsersButton_Click_1(object sender, EventArgs e)
        {
            NewItemForm ModForm = new NewItemForm();
            ModForm.ShowDialog();
            LoadInventory();
        }
    }
}
