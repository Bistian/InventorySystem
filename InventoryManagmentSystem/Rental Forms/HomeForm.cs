using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace InventoryManagmentSystem
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            PrintRented();
            LoadTables(dataGridViewDueIn10, QueryWithin10Days(), "Due");
            LoadTables(dataGridViewPast30, QueryLateItems(), "DueDate2");

        }

        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;

        //Used for counting rentals
        int total = 0;

        #endregion SQL_Variables

        private Form activeForm = null;
        string firetec = "Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC'";

        private int CountRented(string tableName)
        {
            cm = new SqlCommand("Select Count (*) FROM " + tableName + " WHERE Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') AND Location IS NOT NULL", con);
            con.Open();
            int count = (int)cm.ExecuteScalar();
            con.Close();
            return count;
        }

        private string QueryWithin10Days()
        {
            return ("SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbPants " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbPants.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE)) " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbBoots " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE)) " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbHelmets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE))  " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbJackets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE))  " +
                   "ORDER BY DueDate");
        }

        private string QueryLateItems()
        {
            return ("SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbPants " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbPants.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 0 " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbBoots " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 0 " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbHelmets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 0  " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbJackets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 0  " +
                   "ORDER BY DueDate");
        }

        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            grid.Columns[columnName].DefaultCellStyle.Format = "d";

            grid.Rows.Clear();
            cm = new SqlCommand(query, con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                ++i;
                grid.Rows.Add(i,
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2]
                    );
            }

            dr.Close();
            con.Close();
        }

        private int CountTotalRented()
        {
            return CountRented("tbPants") + CountRented("tbJackets");
        }

        private void PrintRented()
        {
            ButtonCurrentlyRentedPants.Text = "Pants " + System.Environment.NewLine + CountRented("tbPants");
            ButtonCurrentlyRentedJackets.Text = "Coats " + System.Environment.NewLine + CountRented("tbJackets");
            ButtonCurrentlyRented.Text = "Items Rented" + System.Environment.NewLine + CountTotalRented();
        }

        private void OpenDockedForm(string formType)
        {
            Form childForm = null;
            //access the main panel in the parent form that will be docked into
            Panel MainPanel = this.ParentForm.Controls.Find("MainPanel", true).FirstOrDefault() as Panel;

            //deciding the type of form that will be docked
            if (formType == "RentalForm")
            {
                childForm = new RentalForm();
            }
            else if (formType == "NewRentalModuleForm")
            {
                childForm = new NewRentalModuleForm();
            }
            else if (formType == "ExistingCustomerModuleForm")
            {
                childForm = new ExistingCustomerModuleForm();
            }


            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.Dispose();
        }

        private void ButtonCurrentlyRented_Click_1(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            parentForm.ColorTabSwitch("Rentals");
            OpenDockedForm("RentalForm");
        }

        private void ButtonCurrentlyRentedPants_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            parentForm.ColorTabSwitch("Rentals");
            OpenDockedForm("RentalForm");
        }

        private void ButtonCurrentlyRentedJackets_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            parentForm.ColorTabSwitch("Rentals");
            OpenDockedForm("RentalForm");
        }

        private void dataGridViewDueIn10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, true);
        }

        private void dataGridViewPast30_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, false);
        }

        /// <summary>
        /// Pop up with client information when client's name is clicked on table.
        /// </summary>
        /// <param name="e">Event that was triggered.</param>
        /// <param name="isDue10">Boolean representing which table was clicked.</param>
        private void ClientPopUp(DataGridViewCellEventArgs e, bool isDue10)
        {
            // Check if the clicked cell is in a row
            if (e.RowIndex < 0) { return; }

            // Column 2 is the only one this function should operate on.
            if (e.ColumnIndex != 2) { return; }

            // Get the data from rentee at that row.
            DataGridViewRow row;
            if (isDue10)
            {
                row = dataGridViewDueIn10.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewPast30.Rows[e.RowIndex];
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

        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            OpenDockedForm("NewRentalModuleForm");
        }

        private void buttonActiveRental_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            OpenDockedForm("ExistingCustomerModuleForm");
            parentForm.ColorTabSwitch("ActiveRentals", false);
        }
    }
}
