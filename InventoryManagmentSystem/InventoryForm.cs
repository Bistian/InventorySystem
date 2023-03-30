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
        #endregion SQL_Variables

        public InventoryForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        public void LoadInventory()
        {
            if (comboBoxItem.SelectedIndex != -1)
            {
                int i = 0;
                dataGridInv.Rows.Clear();
                //Check which item was selected 1 = helmets 2 = jackets 3 = pants 4 = boots 0 = nothing
                if (comboBoxItem.SelectedIndex == 0)
                {
                    cm = new SqlCommand("SELECT * FROM tbHelmets", con);
                    con.Open();
                    dr = cm.ExecuteReader();

                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[9].ToString(), dr[1].ToString(), dr[5].ToString(), dr[2].ToString(), dr[3].ToString(), dr[6].ToString(), dr[4].ToString());
                    }
                }
                else if (comboBoxItem.SelectedIndex == 1)
                {
                    cm = new SqlCommand("SELECT * FROM tbJackets", con);
                    con.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[4].ToString(), dr[3].ToString(), dr[8].ToString(), dr[5].ToString(), "NA");
                    }
                }
                else if (comboBoxItem.SelectedIndex == 2)
                {
                    cm = new SqlCommand("SELECT * FROM tbPants", con);
                    con.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[4].ToString(), dr[3].ToString(), dr[8].ToString(), dr[5].ToString(), "NA");
                    }
                }
                else if (comboBoxItem.SelectedIndex == 3)
                {
                    cm = new SqlCommand("SELECT * FROM tbBoots", con);
                    con.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(i, dr[7].ToString(), dr[1].ToString(), dr[3].ToString(), dr[2].ToString(), dr[9].ToString(), dr[4].ToString(), dr[6].ToString());
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
    }
}
