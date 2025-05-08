using Microsoft.Office.Interop.Excel;
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
    public partial class ReturnModule : Form
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

        public string client;
        public string license;
        int itemType = 0;

        public ReturnModule(string client, string license)
        {
            this.client = client;
            this.license = license;
            InitializeComponent();
            LoadInventory();
            LoadClient();
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
                return ("SELECT ItemType,Brand,SerialNumber,Size,ManufactureDate,Condition FROM tbJackets WHERE " + firetec);
            }

            return ("SELECT ItemType, Brand, SerialNumber," + Sizes + " ManufactureDate, Condition "
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

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return this item", "Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Jacket
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Helmet")
                {
                    itemType = 1;
                    try
                    {
                        cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString());
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
                        cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString());
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
                        cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString());
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
                    cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString());
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Returned");
                }
                LoadClient();
                LoadInventory();
            }
        }
    }
}
