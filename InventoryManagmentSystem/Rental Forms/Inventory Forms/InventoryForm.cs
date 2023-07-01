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

        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection connection = new SqlConnection(connectionString);
        //Creating command
        SqlCommand command = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        public InventoryForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        private string QueryItems(bool isSearch=false, string searchTerm="")
        {
            string CurrTable = "tb" + comboBoxItem.Text;
            string firetec = "Location='Fire-Tec'";
            string sizes;
            string finalColumn;
            string specificWhere;
            if(comboBoxItem.SelectedIndex == 0) // Helmets
            {
                finalColumn = "Color,";
                sizes = "";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%' OR" +
                    " SerialNumber LIKE '%" + searchTerm + "%') AND " + firetec;
            }
            else if (comboBoxItem.SelectedIndex == 3) // Boots
            {
                finalColumn = ", Material";
                sizes = "Size,";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%' OR" +
                    " SIZE LIKE '%" + searchTerm + "%' OR" +
                    " SerialNumber LIKE '%" + searchTerm + "%') AND " + firetec;
            }
            else // Pants && Jackets
            {
                finalColumn = "";
                sizes = "Size,";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%' OR" +
                    " SIZE LIKE '%" + searchTerm + "%' OR" +
                    " SerialNumber LIKE '%" + searchTerm + "%') AND " + firetec;
            }

            string query = "SELECT Brand, SerialNumber," +
                "UsedNew," + "ManufactureDate," +
                sizes + finalColumn + 
                "Location" + " FROM " + CurrTable;

            if (!isSearch)
            {
                return (query + " WHERE " + firetec);
            }

            return (query + specificWhere);
        }

        private string QueryItems2(string searchTerm = "")
        {
            if(comboBoxItem.Text == "Boots") { return QueryBoots(searchTerm); }
            if(comboBoxItem.Text == "Helmets") { return QueryHelmets(searchTerm); }
            if(comboBoxItem.Text == "Jackets" || comboBoxItem.Text == "Pants") { return QueryJacketsAndPants(searchTerm); }
            return "";
        }

        private string QueryBoots(string searchTerm)
        {
            string select = "SELECT Brand, SerialNumber, UsedNew, ManufactureDate, Size, Material, Location FROM tbBoots ";
            string where =
                $"WHERE (Brand LIKE '%{searchTerm}%' OR " +
                $"SerialNumber LIKE '%{searchTerm}%' OR " +
                $"UsedNew LIKE '%{searchTerm}%' OR " +
                $"Size LIKE '%{searchTerm}%') AND " +
                $"Location='Fire-Tec'";
            return (select + where);
        }
        
        private string QueryHelmets(string searchTerm)
        {
            string select = "SELECT Brand, SerialNumber, UsedNew, ManufactureDate, Color, Location FROM tbHelmets ";
            string where =
                $"WHERE (Brand LIKE '%{searchTerm}%' OR " +
                $"SerialNumber LIKE '%{searchTerm}%' OR " +
                $"UsedNew LIKE '%{searchTerm}%' OR " +
                $"Color LIKE '%{searchTerm}%') AND " +
                $"Location='Fire-Tec'";
            return (select + where);
        }

        private string QueryJacketsAndPants(string searchTerm)
        {
            string from = "tbPants ";
            if(comboBoxItem.Text == "Jackets") { from = "tbJackets "; }
            string select = "SELECT Brand, SerialNumber, UsedNew, ManufactureDate, Size, Location FROM ";
            string where =
                $"WHERE (Brand LIKE '%{searchTerm}%' OR " +
                $"SerialNumber LIKE '%{searchTerm}%' OR " +
                $"UsedNew LIKE '%{searchTerm}%' OR " +
                $"Size LIKE '%{searchTerm}%') AND " +
                $"Location='Fire-Tec'";
            return (select + from + where);
        }

        /// <summary>
        /// loads different tables
        /// </summary>
        public void LoadInventory()
        {
            if (comboBoxItem.SelectedIndex != -1)
            {
                dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
                int i = 0;
                dataGridInv.Rows.Clear();
                command = new SqlCommand(QueryItems2(), connection);
                connection.Open();
                dr = command.ExecuteReader();

                //Check which item was selected
                if (comboBoxItem.Text == "Helmets")
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), "Size", "Material", dr[4].ToString(), dr[5].ToString());
                    }
                }
                else if(comboBoxItem.Text == "Boots")
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), "Color");
                    }
                }
                else if (comboBoxItem.Text == "Jackets" || comboBoxItem.Text == "Pants")
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4], dr[5].ToString(), "Material", "Color");
                    }
                }
                dr.Close();
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
            if (comboBoxItem.Text == "Boots")
            {
                dataGridInv.Columns["Color"].Visible = false;
                dataGridInv.Columns["Size"].Visible = true;
                dataGridInv.Columns["Material"].Visible = true;
            }
            else if (comboBoxItem.Text == "Helmets")
            {
                dataGridInv.Columns["Color"].Visible = true;
                dataGridInv.Columns["Size"].Visible = false;
                dataGridInv.Columns["Material"].Visible = false;
            }
            else if (comboBoxItem.Text == "Jackets" || comboBoxItem.Text == "Pants")
            {
                dataGridInv.Columns["Color"].Visible = false;
                dataGridInv.Columns["Size"].Visible = true;
                dataGridInv.Columns["Material"].Visible = false;
            }
        }

        private void UsersButton_Click_1(object sender, EventArgs e)
        {
                NewItemModuleForm ModForm = new NewItemModuleForm(true);
                ModForm.ShowDialog();
                LoadInventory();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxItem.SelectedIndex != -1)
            {
                string searchTerm = searchBar.Text;
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadInventory();
                    return;
                }

                //SQL
                int i = 0;
                dataGridInv.Rows.Clear();
                string query = QueryItems2(searchTerm);
                command = new SqlCommand(query, connection);
                connection.Open();

                try
                {
                    dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        i++;
                        if (comboBoxItem.Text == "Helmets")
                        {
                            dataGridInv.Rows.Add(i,
                            dr[0].ToString(),
                            dr[1].ToString(),
                            dr[2].ToString(),
                            "NA",
                            dr[3].ToString(),
                            dr[4].ToString(),
                            dr[5].ToString(),
                            dr[6].ToString());
                        }
                        else if (comboBoxItem.Text == "Boots")
                        {
                            dataGridInv.Rows.Add(i,
                                dr[0].ToString(),
                                dr[1].ToString(),
                                dr[2].ToString(),
                                dr[3].ToString(),
                                dr[4].ToString(),
                                dr[5].ToString(),
                                dr[6].ToString(),
                                dr[7].ToString());
                        }
                        else // Pants && Jackets
                        {
                            dataGridInv.Rows.Add(i,
                                dr[0].ToString(),
                                dr[1].ToString(),
                                dr[2].ToString(),
                                dr[3].ToString(),
                                dr[4].ToString(),
                                dr[5].ToString(),
                                "NA",
                                dr[6].ToString());
                        }
                    }

                    dr.Close();
                    connection.Close();
                    dataGridInv.Refresh();
                }
                catch (Exception ex)
                {
                    dr.Close();
                    connection.Close();
                    Console.WriteLine(ex.Message);
                }  
            }
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridInv.Columns[e.ColumnIndex].Name;
            string itemType = comboBoxItem.Text;
            try
            {
                if (colName == "Edit")
                {
                    if (itemType == "Jackets" || itemType == "Pants") { UpdateJacketOrPants(e); }
                    else if (itemType == "Helmets") { UpdateHelmet(e); }
                    else if (itemType == "Boots") { UpdateBoots(e); }
                }
                else if (colName == "Delete")
                {
                    string serialNumber = dataGridInv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    DeleteItem(serialNumber);
                }
                LoadInventory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateBoots(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm("Boots", true);
            itemForm.txtBoxSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.comboBoxBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.comboBoxUsedNew.Text =                 GetCellValueAsString(e, "UsedNew");
            itemForm.dateTimePickerManufactureDate.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.comboBoxSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.comboBoxMaterial.Text =                GetCellValueAsString(e, "Material");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateHelmet(DataGridViewCellEventArgs e)
        {
            NewItemForm itemForm = new NewItemForm("Helmet", true);
            itemForm.txtBoxSerialNumber.Text =              GetCellValueAsString(e, "Serial");
            itemForm.comboBoxBrand.Text =                   GetCellValueAsString(e, "Brand");
            itemForm.comboBoxUsedNew.Text =                 GetCellValueAsString(e, "UsedNew");
            itemForm.dateTimePickerManufactureDate.Text =   GetCellValueAsString(e, "ManufactureDate");
            itemForm.comboBoxSize.Text =                    GetCellValueAsString(e, "Size");
            itemForm.comboBoxColor.Text =                   GetCellValueAsString(e, "Color");
            itemForm.SaveButton.Enabled = true;
            itemForm.ShowDialog();
            itemForm.Close();
        }

        private void UpdateJacketOrPants(DataGridViewCellEventArgs e)
        {
            string item = "Jacket";
            if(comboBoxItem.Text == "Pants") { item = "Pants"; }
            NewItemForm itemForm = new NewItemForm(item, true);
            itemForm.txtBoxSerialNumber.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
            itemForm.comboBoxBrand.Text = dataGridInv.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
            itemForm.comboBoxUsedNew.Text = dataGridInv.Rows[e.RowIndex].Cells["UsedNew"].Value.ToString();
            itemForm.dateTimePickerManufactureDate.Text = dataGridInv.Rows[e.RowIndex].Cells["ManufactureDate"].Value.ToString();
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
            
            string table = "tb" + comboBoxItem.Text;
            try
            {
                connection.Open();
                command = new SqlCommand($"DELETE FROM {table} WHERE SerialNumber LIKE '{serialNumber}'", connection);
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
    }
}
