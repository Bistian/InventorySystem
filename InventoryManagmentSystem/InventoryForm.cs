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

namespace InventoryManagmentSystem
{
    public partial class InventoryForm : Form
    {

        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
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

        private string QueryItems()
        {
            CurrTable = "tb" + comboBoxItem.Text;
            if(comboBoxItem.SelectedIndex == 0)
            {
                FinalColumn = ", Color";
                Sizes = "";
            }
            else if (comboBoxItem.SelectedIndex == 3)
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
            }
            else
            {
                FinalColumn = "";
                Sizes = " Size,";
            }
            return ("SELECT ItemType, Brand, SerialNumber,"+ Sizes + " ManufactureDate, UsedNew " + FinalColumn + ",Location" + " FROM " + CurrTable +
                     " WHERE Location='Fire-Tec'");
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
            LoadInventory();
        }


        private void UsersButton_Click_1(object sender, EventArgs e)
        {
                NewItemModuleForm ModForm = new NewItemModuleForm(true);
                ModForm.ShowDialog();
                LoadInventory();
        }
    }
}
