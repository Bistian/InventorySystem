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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace InventoryManagmentSystem
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            PrintRented();
            LoadTables(dataGridViewDueIn10, QueryWithin10Days(), "Due");
            LoadTables(dataGridViewPast30, QueryOver30Days(), "DueDate2");
        }

        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;

        //Used for counting rentals
        int total = 0;

        #endregion SQL_Variables

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

                   "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbBoots " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE)) " +

                   "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbHelmets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE))  " +

                   "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbJackets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location " +
                   "WHERE DueDate IS NOT NULL AND CAST(DueDate AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, 10, CAST(GETDATE() AS DATE))  " +
                   "ORDER BY DueDate");
        }

        private string QueryOver30Days()
        {
            return ("SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbPants " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbPants.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 30 " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbBoots " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbBoots.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 30 " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbHelmets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbHelmets.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 30  " +

                   "UNION SELECT ItemType, tbClients.Name, DueDate, SerialNumber FROM tbJackets " +
                   "INNER JOIN tbClients ON tbClients.DriversLicenseNumber = tbJackets.Location " +
                   "WHERE DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) >= 30  " +
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
       
        private Form activeForm = null;

        private void OpenRented()
        {
            Panel MainPanel = this.ParentForm.Controls.Find("MainPanel", true).FirstOrDefault() as Panel;
            RentalForm childForm = new RentalForm();

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
            OpenRented();
        }

        private void ButtonCurrentlyRentedPants_Click(object sender, EventArgs e)
        {
            OpenRented();
        }

        private void ButtonCurrentlyRentedJackets_Click(object sender, EventArgs e)
        {
            OpenRented();
        }
    }
}
