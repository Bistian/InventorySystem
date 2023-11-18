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

namespace InventoryManagmentSystem
{
    public partial class InventoryForm : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public InventoryForm(string ItemType)
        {
            InitializeComponent();
            checkActive.Checked = true;
            LoadInventory();
            HelperFunctions.LoadItemTypes(connection, ref cbItemType);
            SetItemType(ItemType);
        }

        private string QueryItems(string searchTerm = "")
        {
            if(cbItemType.Text.Length == 0) { return ""; }
            return HelperQuery.ItemSelect(cbItemType.Text, searchTerm);
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
        private string QueryRetiredCondition(string initialQuery)
        {
            string query = "";
            if (checkRetired.Checked)
            {
                query = $"{initialQuery} AND Condition = 'Retired' AND Location='Fire-Tec'";
            }
            else if(checkAll.Checked)
            {
                query = $"{initialQuery} AND Location='Fire-Tec'";
            }
            else
            {
                query = $"{initialQuery} AND Condition != 'Retired' AND Location='Fire-Tec'";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private string QueryBoots(string searchTerm)
        {
            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $@"
                SELECT {standardColumns}, Location, Size, Material 
                FROM tbBoots 
                WHERE (Brand LIKE '%{searchTerm}%' OR 
                SerialNumber LIKE '%{searchTerm}%' OR 
                Condition LIKE '%{searchTerm}%' OR 
                Size LIKE '%{searchTerm}%')
            ";
            return QueryRetiredCondition(initialQuery);
        }
        
        private string QueryHelmets(string searchTerm)
        {
            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $@"
                SELECT {standardColumns}, Location, Color 
                FROM tbHelmets 
                WHERE (Brand LIKE '%{searchTerm}%' OR 
                SerialNumber LIKE '%{searchTerm}%' OR 
                Condition LIKE '%{searchTerm}%' OR 
                Color LIKE '%{searchTerm}%')
            ";
            return QueryRetiredCondition(initialQuery);
        }

        /// <summary>
        /// Standard items are Jackets, Masks, and Pants.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        private string QueryStandardItems(string searchTerm)
        {
            string from = "tbPants ";
            if(cbItemType.Text == "Jacket") { from = "tbJackets "; }
            if (cbItemType.Text == "Mask") { from = "tbMasks "; }

            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $@"
                SELECT {standardColumns}, Location, Size 
                FROM {from}
                WHERE (Brand LIKE '%{searchTerm}%' OR
                SerialNumber LIKE '%{searchTerm}%' OR
                Condition LIKE '%{searchTerm}%' OR
                Size LIKE '%{searchTerm}%') 
            ";
            return QueryRetiredCondition(initialQuery);
        }

        /// <summary>
        /// loads different tables
        /// </summary>
        public void LoadInventory()
        {
            if (cbItemType.SelectedIndex == -1) { return; }
            dataGridInv.Columns["column_acquisition_date"].DefaultCellStyle.Format = "d";
            dataGridInv.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";
            try
            {
                int i = 0;
                dataGridInv.Rows.Clear();
                connection.Open();
                SqlCommand command = new SqlCommand(QueryItems(), connection);
                SqlDataReader reader = command.ExecuteReader();
                //Check which item was selected
                if (cbItemType.Text == "helmet")
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i,
                            reader.GetOrdinal("Id"),
                            reader.GetOrdinal("Brand"),
                            reader.GetOrdinal("SerialNumer"),
                            reader.GetOrdinal("Condition"),
                            reader.GetOrdinal("AcquisitionDate"),
                            reader.GetOrdinal("ManufactureDate"),
                            reader.GetOrdinal("Location"),
                            "Size", "Material",
                            reader.GetOrdinal("Color")
                        );
                    }
                }
                else if (cbItemType.Text == "boots")
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i,
                            reader.GetOrdinal("Id"),
                            reader.GetOrdinal("Brand"),
                            reader.GetOrdinal("SerialNumer"),
                            reader.GetOrdinal("Condition"),
                            reader.GetOrdinal("AcquisitionDate"),
                            reader.GetOrdinal("ManufactureDate"),
                            reader.GetOrdinal("Location"),
                            reader.GetOrdinal("Size"),
                            reader.GetOrdinal("Material"),
                            "Color"
                        );
                    }
                }
                else if (cbItemType.Text == "jacket" || cbItemType.Text == "pants" || cbItemType.Text == "mask")
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i,
                            reader.GetOrdinal("Id"),
                            reader.GetOrdinal("Brand"),
                            reader.GetOrdinal("SerialNumer"),
                            reader.GetOrdinal("Condition"),
                            reader.GetOrdinal("AcquisitionDate"),
                            reader.GetOrdinal("ManufactureDate"),
                            reader.GetOrdinal("Location"),
                            reader.GetOrdinal("Size"),
                            "Material", "Color"
                        );
                    }
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            
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

        private void UsersButton_Click_1(object sender, EventArgs e)
        {
                NewItemForm ModForm = new NewItemForm();
                ModForm.ShowDialog();
                LoadInventory();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0)
            {
                return;
            }

            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadInventory();
                return;
            }

            //SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            string query = QueryItems(searchTerm);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    i++;
                    if (cbItemType.Text == "Helmet")
                    {
                        dataGridInv.Rows.Add(i,
                           reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                           reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                           reader[6].ToString(), "N/A", "N/A", reader[7].ToString()
                       );
                    }
                    else if (cbItemType.Text == "Boots")
                    {
                        i++;
                        dataGridInv.Rows.Add(i,
                            reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                            reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString()
                        );
                    }
                    else // Pants && Jackets && Masks
                    {
                        i++;
                        dataGridInv.Rows.Add(i,
                            reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                            reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString());
                    }
                }

                reader.Close();
                connection.Close();
                dataGridInv.Refresh();
            }
            catch (Exception ex)
            {
                if(reader != null) { reader.Close(); }
                connection.Close();
                Console.WriteLine(ex.Message);
            }  
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string colName = dataGridInv.Columns[e.ColumnIndex].Name;
            string itemType = cbItemType.Text;
            string serialNumber = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
            try
            {
                if (colName == "Edit")
                {
                    if (itemType == "Jacket" || itemType == "Pants" || itemType == "Mask") { UpdateJacketOrPantsOrMasks(e,itemType); }
                    else if (itemType == "Helmet") { UpdateHelmet(e); }
                    else if (itemType == "Boots") { UpdateBoots(e); }
                    LoadInventory();
                }
                else if (colName == "Delete")
                {
                    DeleteItem(serialNumber);
                    LoadInventory();
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
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);
            itemForm.cbItemType.Text = "Boots";
            itemForm.tbSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.cbBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.cbCondition.Text =                 GetCellValueAsString(e, "Condition");
            itemForm.dtManufacture.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.cbSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.cbMaterial.Text =                GetCellValueAsString(e, "Material");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateHelmet(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);
            itemForm.cbItemType.Text = "Helmet";
            itemForm.tbSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.cbBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.cbCondition.Text =                 GetCellValueAsString(e, "Condition");
            itemForm.dtManufacture.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.cbSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.cbColor.Text =                   GetCellValueAsString(e, "Color");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateJacketOrPantsOrMasks(DataGridViewCellEventArgs e,string ItemType)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);


            if (ItemType == "Mask")
            {
                itemForm.cbItemType.Text = "Mask";
            }
            else if (ItemType == "Jacket")
            {
                itemForm.cbItemType.Text = "Jacket";
            }
            else if (ItemType == "Pants")
            {
                itemForm.cbItemType.Text = "Pants";
            }

            itemForm.tbSerialNumber.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
            itemForm.cbBrand.Text = dataGridInv.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
            itemForm.cbCondition.Text = dataGridInv.Rows[e.RowIndex].Cells["Condition"].Value.ToString();
            itemForm.dtManufacture.Text = dataGridInv.Rows[e.RowIndex].Cells["ManufactureDate"].Value.ToString();
            itemForm.cbSize.Text = dataGridInv.Rows[e.RowIndex].Cells["Size"].Value.ToString();
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

        private void labelNewItem_Click(object sender, EventArgs e)
        {

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
    }
}
