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
    public partial class NewRentalModuleForm : Form
    {

        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
        //Creating command
        SqlCommand cm = new SqlCommand();
        bool isNewItem;
        #endregion SQL_Variables

        public NewRentalModuleForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtBoxCustomerName.Clear();
            txtBoxPhone.Clear();
            txtBoxEmail.Clear();
            txtBoxDriversLicense.Clear();
            txtBoxAddress.Clear();
            txtBoxRep.Clear();
            comboBoxAcademy.SelectedIndex = -1;
            comboDayNight.SelectedIndex = -1;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void SaveClient()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Info?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbClients(Name,Phone,Email,Academy,DayNight,DriversLicenseNumber,Address,FireTecRepresentative)" +
                        "VALUES(@Name,@Phone,@Email,@Academy,@DayNight,@DriversLicenseNumber,@Address,@FireTecRepresentative)", con);
                    cm.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                    cm.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                    cm.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                    cm.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                    cm.Parameters.AddWithValue("@Address", txtBoxAddress.Text);
                    cm.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                    cm.Parameters.AddWithValue("@Academy", comboBoxAcademy.Text);
                    cm.Parameters.AddWithValue("@DayNight", comboDayNight.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Info has been successfully saved");
                    Clear();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            SaveClient();
        }
    }
}
