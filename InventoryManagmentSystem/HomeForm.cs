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

        private int CountRented(string tableName)
        {
            cm = new SqlCommand("Select Count (*) FROM " +tableName+ " WHERE Location NOT IN ('Fire-Tec')", con);
            con.Open();
            int count = (int)cm.ExecuteScalar();
            con.Close();
            return count;
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

        private void ButtonCurrentlyRented_Click(object sender, EventArgs e)
        {
            OpenRented();
        }

        private void ButtonCurrentlyRentedJackets_Click(object sender, EventArgs e)
        {
            OpenRented();
        }

        private void ButtonCurrentlyRentedPants_Click(object sender, EventArgs e)
        {
            OpenRented();
        }
    }
}
