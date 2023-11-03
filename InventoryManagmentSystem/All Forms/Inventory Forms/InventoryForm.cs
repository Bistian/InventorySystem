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
            if(cbItemType.Text.ToLower() == "boots") { return QueryBoots(searchTerm); }
            if(cbItemType.Text.ToLower() == "helmet") { return QueryHelmets(searchTerm); }
            if(cbItemType.Text.ToLower() == "jacket" || 
                cbItemType.Text.ToLower() == "pants" || 
                cbItemType.Text.ToLower() == "mask") { return QueryStandardItems(searchTerm); }
            return "";
        }

        private void SetItemType(string ItemType)
        {
            if (ItemType == "Jacket")
            {
                cbItemType.SelectedIndex = 0;
            }
            else if (ItemType == "Pants")
            {
                cbItemType.SelectedIndex = 1;
            }
            else if (ItemType == "Boots")
            {
                cbItemType.SelectedIndex = 2;
            }
            else if (ItemType == "Helmet")
            {
                cbItemType.SelectedIndex = 3;
            }
            else if (ItemType == "Mask")
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
                if(searchBar.Text.Length == 0)
                {
                    query = $"{initialQuery} WHERE Condition = 'Retired' AND Location='Fire-Tec'";
                } 
                else
                {
                    query = $"{initialQuery} AND Condition = 'Retired' AND Location='Fire-Tec'";
                }
            }
            else if(checkAll.Checked)
            {
                if (searchBar.Text.Length == 0)
                {
                    query = $"{initialQuery} WHERE Location='Fire-Tec'";
                }
                else
                {
                    query = $"{initialQuery} AND Location='Fire-Tec'";
                }
            }
            else
            {
                if (searchBar.Text.Length == 0)
                {
                    query = $"{initialQuery} WHERE Condition != 'Retired' AND Location='Fire-Tec'";
                }
                else
                {
                    query = $"{initialQuery} AND Condition != 'Retired' AND Location='Fire-Tec'";
                }
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private string QueryBoots(string searchTerm)
        {
            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $"SELECT {standardColumns}, Location, Size, Material FROM tbBoots";
            if(searchTerm.Length > 0)
            {
                initialQuery += $@"
                    WHERE (Brand LIKE '%{searchTerm}%' OR 
                    SerialNumber LIKE '%{searchTerm}%' OR 
                    Condition LIKE '%{searchTerm}%' OR 
                    Size LIKE '%{searchTerm}%')
                ";
            }
            return QueryRetiredCondition(initialQuery);
        }
        
        private string QueryHelmets(string searchTerm)
        {
            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $"SELECT {standardColumns}, Location, Color FROM tbHelmets";
            if (searchTerm.Length > 0)
            {
                initialQuery += $@"
                    WHERE (Brand LIKE '%{searchTerm}%' OR 
                    SerialNumber LIKE '%{searchTerm}%' OR 
                    Condition LIKE '%{searchTerm}%' OR 
                    Color LIKE '%{searchTerm}%')
                ";
            }
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
            if(cbItemType.Text.ToLower() == "jacket") { from = "tbJackets "; }
            if (cbItemType.Text.ToLower() == "mask") { from = "tbMasks "; }

            string standardColumns = HelperQuery.ItemStandardColumns();
            string initialQuery = $"SELECT {standardColumns}, Location, Size FROM {from}";
            if (searchTerm.Length > 0)
            {
                initialQuery += $@"
                    WHERE (Brand LIKE '%{searchTerm}%' OR
                    SerialNumber LIKE '%{searchTerm}%' OR
                    Condition LIKE '%{searchTerm}%' OR
                    Size LIKE '%{searchTerm}%') 
                ";
            }
            return QueryRetiredCondition(initialQuery);
        }

        /// <summary>
        /// loads different tables
        /// </summary>
        public void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            if (cbItemType.SelectedIndex != -1)
            {
                int i = 0;
                dataGridInv.Rows.Clear();
                connection.Open();
                SqlCommand command = new SqlCommand(QueryItems(), connection);
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return;
                }
                
                //Check which item was selected
                if (cbItemType.Text.ToLower() == "helmet")
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, 
                            reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), 
                            reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                            reader[6].ToString(),"N/A","N/A", reader[7].ToString()
                        );
                    }
                }
                else if(cbItemType.Text.ToLower() == "boots")
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, 
                            reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), 
                            reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString()
                        );
                    }
                }
                else if (cbItemType.Text.ToLower() == "jacket" || cbItemType.Text.ToLower() == "pants" || cbItemType.Text.ToLower() == "mask")
                {
                    while (reader.Read())
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
            }
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
            if (cbItemType.Text == "Boots")
            {
                dataGridInv.Columns["Color"].Visible = false;
                dataGridInv.Columns["Size"].Visible = true;
                dataGridInv.Columns["Material"].Visible = true;
            }
            else if (cbItemType.Text == "Helmet")
            {
                dataGridInv.Columns["Color"].Visible = true;
                dataGridInv.Columns["Size"].Visible = false;
                dataGridInv.Columns["Material"].Visible = false;
            }
            else if (cbItemType.Text == "Jacket" || cbItemType.Text == "Pants" || cbItemType.Text == "Mask")
            {
                dataGridInv.Columns["Color"].Visible = false;
                dataGridInv.Columns["Size"].Visible = true;
                dataGridInv.Columns["Material"].Visible = false;
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
            itemForm.txtBoxSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.comboBoxBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.comboBoxCondition.Text =                 GetCellValueAsString(e, "Condition");
            itemForm.dtManufacture.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.comboBoxSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.comboBoxMaterial.Text =                GetCellValueAsString(e, "Material");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateHelmet(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm(cbItemType.Text, true);
            itemForm.cbItemType.Text = "Helmet";
            itemForm.txtBoxSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.comboBoxBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.comboBoxCondition.Text =                 GetCellValueAsString(e, "Condition");
            itemForm.dtManufacture.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.comboBoxSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.comboBoxColor.Text =                   GetCellValueAsString(e, "Color");
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

            itemForm.txtBoxSerialNumber.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
            itemForm.comboBoxBrand.Text = dataGridInv.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
            itemForm.comboBoxCondition.Text = dataGridInv.Rows[e.RowIndex].Cells["Condition"].Value.ToString();
            itemForm.dtManufacture.Text = dataGridInv.Rows[e.RowIndex].Cells["ManufactureDate"].Value.ToString();
            itemForm.comboBoxSize.Text = dataGridInv.Rows[e.RowIndex].Cells["Size"].Value.ToString();
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
