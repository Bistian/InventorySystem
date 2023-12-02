using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class RentalForm : Form
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
        #endregion SQL_Variables

        //Makes date red if it is less than this number.
        int daysForWarning = 14;
        int setSelection = 0;

        public RentalForm(string ItemType)
        {
            InitializeComponent();
            RefreshForm(ItemType);
        }

        /// <summary>
        /// Query for rented and post due grids.
        /// </summary>
        /// <param name="isRented">true for rented, false for past due</param>
        /// <returns></returns>
        private string Query(bool isRented, string ItemType)
        {
            string query = "";
            string sign = isRented ? ">=" : "<";
            if (ItemType == "Jacket")
            {
                query = $@"SELECT ItemType='Jacket', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbJackets 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
                ";
            }
            else if (ItemType == "Pants")
            {
                query = $@"SELECT ItemType='Pants', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbPants 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbPants.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
                ";
            }
            else if (ItemType == "Boots")
            {
                query = $@"SELECT ItemType='Boots', tbClients.Name, tbClients.DriversLicenseNumber,  DueDate, SerialNumber FROM tbBoots 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
                ";
            }
            else if (ItemType == "Helmet")
            {
                query = $@"SELECT ItemType='Helmet', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbHelmets 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
                ";
            }
            else if (ItemType == "Mask")
            {
                query = $@"SELECT ItemType='Mask', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbMasks 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbMasks.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
                ";
            }

            else if (ItemType == null)
            {
                query = $@"
                SELECT ItemType='Boots', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbBoots 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 

                UNION SELECT ItemType='Helmet', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbHelmets 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 

                UNION SELECT ItemType='Jacket', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbJackets 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 

                UNION SELECT ItemType='Pants', tbClients.Name, tbClients.DriversLicenseNumber, DueDate, SerialNumber FROM tbPants 
                INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbPants.Location 
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE()) 
            ";
            }
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        /// <summary>
        /// Render the tables.
        /// </summary>
        /// <param name="grid">Which table you are going to render.</param>
        /// <param name="query">SQL code for the table.</param>
        /// <param name="columnName">Name of the column as it is in Edit Columns.</param>
        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            grid.Columns[columnName].DefaultCellStyle.Format = "d";

            grid.Rows.Clear();
            cm = new SqlCommand(query, con);
            con.Open();
            try
            {
                dr = cm.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    ++i;
                    grid.Rows.Add(i,
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3],
                        dr[3].ToString()
                    );
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        // Check if rented due date is getting closer and turns date red.
        private void dataGridRented_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Is this the Due Date column?
            if (e.ColumnIndex != 3) { return; }

            //Check if the date is getting close.
            DateTime date = DateTime.Parse(e.Value.ToString());
            if ((date - DateTime.Now).TotalDays > daysForWarning) { return; }

            //Change cell color.
            e.CellStyle.ForeColor = Color.Red;
        }

        private void dataGridRented_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, false);
        }

        private void dataGridPastDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, true);
        }

        /// <summary>
        /// Makes the pop up window with the client's information.
        /// </summary>
        /// <param name="e">Event from the click.</param>
        /// <param name="isPastDue">Flag checking if the function is working with the rented table or the past due.</param>
        private void ClientPopUp(DataGridViewCellEventArgs e, bool isPastDue)
        {
            // Check if the clicked cell is in a row
            if (e.RowIndex < 0) { return; }

            // Column 2 is the only one this function should operate on.
            if (e.ColumnIndex != 2) { return; }

            // Get the data from rentee at that row.
            DataGridViewRow row;
            if (isPastDue)
            {
                row = dataGridPastDue.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridRented.Rows[e.RowIndex];
            }


            string rentee = row.Cells[2].Value.ToString();
            // Check if there is at least one item with that name on the clints table.
            string query = (
                "SELECT COUNT(*) FROM tbClients " +
                "WHERE Name ='" + rentee + "'");

            cm = new SqlCommand(query, con);
            con.Open();

            // If there are no matches with that name, return.
            if ((int)cm.ExecuteScalar() <= 0)
            {
                con.Close();
                return;
            }
            con.Close();

            // Show the details of the row in a new form or dialog
            DialogBoxClient dialogBoxClient = new DialogBoxClient(rentee);
            dialogBoxClient.ShowDialog();
        }

        private void ButtonNewRental_Click(object sender, EventArgs e)
        {
            NewOrExistingCustomerModuleForm ModForm = new NewOrExistingCustomerModuleForm();
            ModForm.ShowDialog();
            RefreshForm(null);
        }

        private void RefreshForm(string ItemType)
        {
            if (ItemType == null)
            {
                cbItemType.SelectedIndex = 5;
                LoadTables(dataGridRented, Query(true, null), "DueDate");
                LoadTables(dataGridPastDue, Query(false, null), "DDate");
            }
            else if (ItemType == "Jacket")
            {
                cbItemType.SelectedIndex = 0;
                LoadTables(dataGridRented, Query(true, "Jacket"), "DueDate");
                LoadTables(dataGridPastDue, Query(false, "Jacket"), "DDate");
            }
            else if (ItemType == "Pants")
            {
                cbItemType.SelectedIndex = 1;
                LoadTables(dataGridRented, Query(true, "Pants"), "DueDate");
                LoadTables(dataGridPastDue, Query(false, "Pants"), "DDate");
            }
            else if (ItemType == "Boots")
            {
                cbItemType.SelectedIndex = 2;
                LoadTables(dataGridRented, Query(true, "Boots"), "DueDate");
                LoadTables(dataGridPastDue, Query(false, "Boots"), "DDate");
            }
            else if (ItemType == "Helmet")
            {
                cbItemType.SelectedIndex = 3;
                LoadTables(dataGridRented, Query(true, "Helmet"), "DueDate");
                LoadTables(dataGridPastDue, Query(false, "Helmet"), "DDate");
            }
            else if (ItemType == "Mask")
            {
                cbItemType.SelectedIndex = 4;
                LoadTables(dataGridRented, Query(true, "Mask"), "DueDate");
                LoadTables(dataGridPastDue, Query(false, "Mask"), "DDate");
            }
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbItemType.SelectedIndex == 0)
            {
                RefreshForm("Jacket");
            }
            else if (cbItemType.SelectedIndex == 1)
            {
                RefreshForm("Pants");
            }
            else if (cbItemType.SelectedIndex == 2)
            {
                RefreshForm("Boots");
            }
            else if (cbItemType.SelectedIndex == 3)
            {
                RefreshForm("Helmet");
            }
            else if (cbItemType.SelectedIndex == 4)
            {
                RefreshForm("Mask");
            }
            else if (cbItemType.SelectedIndex == 5)
            {
                RefreshForm(null);
            }
        }

        private void dataGridRented_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridRented.Rows[e.RowIndex];
            string name = row.Cells["Rentee"].Value.ToString();
            string licence = row.Cells["License"].Value.ToString();

            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, name);
            try
            {
                    Profile.LoadProfile(false, licence);
                    parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void dataGridPastDue_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridPastDue.Rows[e.RowIndex];
            string name = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            string licence = row.Cells["LicensePast"].Value.ToString();

            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, name);
            try
            {
                Profile.LoadProfile(false, licence);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }
    }
}
