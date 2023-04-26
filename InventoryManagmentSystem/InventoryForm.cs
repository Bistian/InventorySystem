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

namespace InventoryManagmentSystem
{
    public partial class InventoryForm : Form
    {

        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;

        //Used for query
        string CurrTable = "";
        string FinalColumn = "";
        string Sizes = "";
        #endregion SQL_Variables

        public InventoryForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        private string QueryItems(bool isSearch=false, string searchTerm="")
        {
            CurrTable = "tb" + comboBoxItem.Text;

            string firetec = "Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC'";
            string specificWhere = "";
            if(comboBoxItem.SelectedIndex == 0) // Helmets
            {
                FinalColumn = ", Color";
                Sizes = "";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%') AND " + firetec;
            }
            else if (comboBoxItem.SelectedIndex == 3) // Boots
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%' OR" +
                    " SIZE LIKE '%" + searchTerm + "%') AND " + firetec;
            }
            else // Pants && Jackets
            {
                FinalColumn = "";
                Sizes = " Size,";
                specificWhere = " WHERE (Brand LIKE '%" + searchTerm + "%' OR" +
                    " UsedNew LIKE '%" + searchTerm + "%' OR" +
                    " SIZE LIKE '%" + searchTerm + "%') AND " + firetec;
            }

            string query = "SELECT ItemType, " +
                "Brand, SerialNumber, " + 
                Sizes + " ManufactureDate, " +
                "UsedNew " + FinalColumn + 
                ", Location" + " FROM " + CurrTable;

            if (!isSearch)
            {
                return (query + " WHERE " + firetec);
            }

            return (query + specificWhere);
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
                cm = new SqlCommand(QueryItems(), con);
                con.Open();
                dr = cm.ExecuteReader();

                //Check which item was selected
                if (comboBoxItem.SelectedIndex == 0)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                }
                else if(comboBoxItem.SelectedIndex == 3)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], dr[6].ToString(), dr[7].ToString());
                    }
                }
                else if (comboBoxItem.SelectedIndex == 1 || comboBoxItem.SelectedIndex == 2)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], "NA", dr[6].ToString());
                    }
                }
                dr.Close();
                con.Close();
            }
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset search bar.
            searchBar.Text = "";
            LoadInventory();
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

                string query = "";

                query = QueryItems(true, searchTerm);

                cm = new SqlCommand(query, con);
                con.Open();
                dr = cm.ExecuteReader();

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
                        string s = dr[0].ToString();
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
                con.Close();
            }
        }

        private void dataGridInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridInv.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.UserNameTxt.Text = dataGridInv.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.NameTxtBox.Text = dataGridInv.Rows[e.RowIndex].Cells[3].Value.ToString();

                userModule.SaveButton.Enabled = true;
                userModule.UserNameTxt.Enabled = false;
                userModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dataGridInv.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item has been successfully deleted");
                }
            }
            LoadInventory();
        }
    }
}
