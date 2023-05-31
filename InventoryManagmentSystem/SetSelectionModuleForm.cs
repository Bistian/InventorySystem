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
    public partial class SetSelectionModuleForm : Form
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

        public string DayNight;
        public string client;
        public string license;
        int itemType = 0;
        string firetec = "Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC'";

        public SetSelectionModuleForm(string client, string license, string DayNight)
        {
            this.client = client;
            this.license = license;
            this.DayNight = DayNight;

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

            string firetec = "(Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC')";
            if (itemType == 1)
            {
                FinalColumn = ", Color";
                Sizes = "";
                CurrTable = "tbHelmets";
            }
            else if (itemType == 2)
            {
                FinalColumn = "";
                Sizes = " Size,";
                CurrTable = "tbJackets";
            }
            else if (itemType == 3)
            {
                FinalColumn = "";
                Sizes = " Size,";
                CurrTable = "tbPants";
            }
            else if (itemType == 4)
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
                CurrTable = "tbBoots";
            }
            else
            {
                return ("SELECT ItemType,Brand,SerialNumber,Size,ManufactureDate,UsedNew FROM tbJackets WHERE " + firetec);
            }
            
            return ("SELECT ItemType, Brand, SerialNumber," + Sizes + " ManufactureDate, UsedNew " 
                + FinalColumn + " FROM " + CurrTable +
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

            if (itemType == 1)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else if (itemType == 2 || itemType == 3)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), "NA");
                }
            }
            else if (itemType == 4)
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
            if (comboBoxSet.SelectedIndex == 0)
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
            else if (comboBoxSet.SelectedIndex == 1)
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
            else if (comboBoxSet.SelectedIndex == 2)
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
            else if (comboBoxSet.SelectedIndex == 3)
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

        private void BtnNewItem_Click(object sender, EventArgs e)
        {
            NewItemModuleForm ModForm = new NewItemModuleForm(true);
            ModForm.ShowDialog();
        }

        private void textBoxHelmet_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxHelmet.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber,ManufactureDate, UsedNew, Color FROM tbHelmets WHERE (" + firetec + ") AND SerialNumber LIKE '%" + searchTerm + "%'", con);
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

        private void textBoxJacket_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxJacket.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadInventory(); }

            // SQL
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew FROM tbJackets WHERE (" + firetec + ") AND SerialNumber LIKE '%" + searchTerm + "%'", con);
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
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew FROM tbPants WHERE (" + firetec + ") AND SerialNumber LIKE '%" + searchTerm + "%'", con);
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
            cm = new SqlCommand("SELECT ItemType, Brand, SerialNumber,Size, ManufactureDate, UsedNew, Material FROM tbBoots WHERE (" + firetec + ") AND SerialNumber LIKE '%" + searchTerm + "%'", con);
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (comboBoxSet.SelectedIndex != -1)
            {
                WorkOrderModuleForm ModForm = new WorkOrderModuleForm(labelClientName.Text, DayNight, comboBoxSet.Text);
                this.Dispose();
                ModForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a rental option");
            }
        }

        private void dataGridInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to rent this item to " + client, "Rent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DateTime.Today != DatepickerDue.Value.Date)
                {
                    // Helmet
                    if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Helmet")
                    {
                        itemType = 1;
                        try
                        {
                            textBoxHelmet.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                            cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                            cm.Parameters.AddWithValue("@location", license);
                            cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                            cm.Parameters.AddWithValue("@serial", textBoxHelmet.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Rental has been successfully completed");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                            con.Close();
                            return;
                        }
                    }

                    // Jacket
                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Jacket")
                    {
                        itemType = 2;
                        try
                        {
                            textBoxJacket.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                            cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                            cm.Parameters.AddWithValue("@location", license);
                            cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                            cm.Parameters.AddWithValue("@serial", textBoxJacket.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Rental has been successfully completed");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                            con.Close();
                            return;
                        }
                    }

                    // Pants
                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Pants")
                    {
                        itemType = 3;
                        try
                        {
                            textBoxPants.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                            cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                            cm.Parameters.AddWithValue("@location", license);
                            cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                            cm.Parameters.AddWithValue("@serial", textBoxPants.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Rental has been successfully completed");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                            con.Close();
                            return;
                        }
                    }

                    else if (dataGridInv.Rows[e.RowIndex].Cells["Type"].Value.ToString() == "Boots")
                    {
                        itemType = 4;
                        textBoxBoots.Text = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                        cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", license);
                        cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                        cm.Parameters.AddWithValue("@serial", textBoxBoots.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Rental has been successfully completed");
                    }
                    LoadClient();
                    LoadInventory();
                }
                else
                {
                    MessageBox.Show("Please select a due date");
                }
            }
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return this item", "Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Helmet
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Helmet")
                {
                    itemType = 1;
                    try
                    {
                        textBoxHelmet.Text = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", textBoxHelmet.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
                        return;
                    }
                }

                // Jacket
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Jacket")
                {
                    itemType = 2;
                    try
                    {
                        textBoxJacket.Text = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", textBoxJacket.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
                        return;
                    }
                }

                // Pants
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Pants")
                {
                    itemType = 3;
                    try
                    {
                        textBoxPants.Text = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", textBoxPants.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
                        return;
                    }
                }

                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Boots")
                {
                    itemType = 4;
                    textBoxBoots.Text = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                    cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", textBoxBoots.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Returned");
                }
                LoadClient();
                LoadInventory();
            }
        }

        private void dataGridInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
