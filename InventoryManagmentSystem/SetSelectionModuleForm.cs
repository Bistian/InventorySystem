using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class SetSelectionModuleForm : Form
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

        public string client;
        public string license;

        public SetSelectionModuleForm(string client,string license)
        {
            this.client = client;
            this.license = license;
            InitializeComponent();
            LoadClient();
            lableHelmet.Visible = false;
            textBoxHelmet.Visible = false;

            labelJacket.Visible = false;
            textBoxJacket.Visible = false;

            labelPants.Visible = false;
            textBoxPants.Visible = false;

            labelBoots.Visible = false;
            textBoxBoots.Visible = false;
        }

        private string QueryClient()
        {
            //return ("SELECT Type, DueDate, SerialNumber FROM tbBoots WHERE Location='Client1'");
            return ("SELECT ItemType, DueDate, SerialNumber FROM tbPants " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbBoots " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbJackets " +
                "WHERE Location='" + license + "' " +
                "ORDER BY DueDate");
        }

        private void LoadClient()
        {
            labelClientName.Text = client;
            // Change the styling for the date column.
            dataGridViewClient.Columns["DueDate"].DefaultCellStyle.Format = "d";

            dataGridViewClient.Rows.Clear();
            cm = new SqlCommand(QueryClient(), con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                ++i;
                dataGridViewClient.Rows.Add(i,
                    dr[0].ToString(),
                    dr[1],
                    dr[2].ToString()
                );
            }

            dr.Close();
            con.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private string QueryItems()
        {
            if (textBoxHelmet.Focused)
            {
                FinalColumn = ", Color";
                Sizes = "";
                CurrTable = "tbHelmets";
            }
            else if (textBoxJacket.Focused || textBoxPants.Focused)
            {
                FinalColumn = "";
                Sizes = " Size,";
                CurrTable = "tbJackets";
            }
            else if (textBoxBoots.Focused)
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
                CurrTable = "tbBoots";
            }
            string firetec = "(Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC')";
            return ("SELECT ItemType, Brand, SerialNumber," + Sizes + " ManufactureDate, UsedNew " + FinalColumn + " FROM " + CurrTable +
                     " WHERE " + firetec);
        }

        private void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand(QueryItems(), con);
            con.Open();
            dr = cm.ExecuteReader();

            if (textBoxHelmet.Focused)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else if(textBoxJacket.Focused || textBoxPants.Focused)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "NA");
                }
            }
            else if(textBoxBoots.Focused)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5]);
                }
            }
            dr.Close();
            con.Close();
        }

        private void comboBoxSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //full set
            if(comboBoxSet.SelectedIndex == 0)
            {
                lableHelmet.Visible = true;
                textBoxHelmet.Visible = true;

                labelJacket.Visible = true;
                textBoxJacket.Visible = true;
                
                labelPants.Visible = true;
                textBoxPants.Visible = true;

                labelBoots.Visible = true;
                textBoxBoots.Visible = true;
            }
            //set only helmet
            else if(comboBoxSet.SelectedIndex == 1) 
            {
                lableHelmet.Visible = true;
                textBoxHelmet.Visible = true;

                labelJacket.Visible = true;
                textBoxJacket.Visible = true;

                labelPants.Visible = true;
                textBoxPants.Visible = true;

                labelBoots.Visible = false;
                textBoxBoots.Visible = false;
            }
            //set only boots
            else if(comboBoxSet.SelectedIndex == 2) 
            {

                lableHelmet.Visible = false;
                textBoxHelmet.Visible = false;

                labelJacket.Visible = true;
                textBoxJacket.Visible = true;

                labelPants.Visible = true;
                textBoxPants.Visible = true;

                labelBoots.Visible = true;
                textBoxBoots.Visible = true;
            }
            else if(comboBoxSet.SelectedIndex == 3)
            {
                lableHelmet.Visible = false;
                textBoxHelmet.Visible = false;

                labelJacket.Visible = true;
                textBoxJacket.Visible = true;

                labelPants.Visible = true;
                textBoxPants.Visible = true;

                labelBoots.Visible = false;
                textBoxBoots.Visible = false;
            }
        }

        private void textBoxHelmet_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxHelmet.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber,ManufactureDate, UsedNew, Color FROM tbHelmets WHERE Location ='Fire-Tec' AND SerialNumber LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void BtnNewItem_Click(object sender, EventArgs e)
        {
            NewItemModuleForm ModForm = new NewItemModuleForm(true);
            ModForm.ShowDialog();
        }

        private void dataGridInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (MessageBox.Show("Are you sure you want to rent this item to " + client, "Rent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Helmet")
                    {
                        textBoxHelmet.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                        cm = new SqlCommand("UPDATE tbHelmets SET location = @location WHERE SerialNumber LIKE " + textBoxHelmet.Text, con);
                        cm.Parameters.AddWithValue("@location", license);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Rental has been successfully completed");
                    }


                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Jacket")
                    {
                        textBoxJacket.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                    cm = new SqlCommand("UPDATE tbJacket SET location = @location WHERE SerialNumber LIKE " + textBoxJacket.Text, con);
                    cm.Parameters.AddWithValue("@location", license);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rental has been successfully completed");
                }

                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Pants")
                    {
                        textBoxPants.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                    cm = new SqlCommand("UPDATE tbPants SET location = @location WHERE SerialNumber LIKE " + textBoxPants.Text, con);
                    cm.Parameters.AddWithValue("@location", license);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rental has been successfully completed");
                }

                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Boots")
                    {
                        textBoxBoots.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                    cm = new SqlCommand("UPDATE tbBoots SET location = @location WHERE SerialNumber LIKE " + textBoxBoots.Text, con);
                    cm.Parameters.AddWithValue("@location", license);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rental has been successfully completed");
                }
                    LoadClient();
                }

            
            
        }

        private void textBoxJacket_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxJacket.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew FROM tbJackets WHERE Location ='Fire-Tec' AND SerialNumber LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], "NA");
            }
            dr.Close();
            con.Close();
        }

        private void textBoxPants_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxPants.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew FROM tbPants WHERE Location ='Fire-Tec' AND SerialNumber LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], "NA");
            }
            dr.Close();
            con.Close();
        }

        private void textBoxBoots_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxBoots.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber,Size, ManufactureDate, UsedNew, Material FROM tbBoots WHERE Location ='Fire-Tec' AND SerialNumber LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], dr[6].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
