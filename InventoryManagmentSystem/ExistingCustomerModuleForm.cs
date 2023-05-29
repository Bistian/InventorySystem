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
    public partial class ExistingCustomerModuleForm : Form
    {
        #region SQL_Variables
        //Database Path
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        public bool isReturn = false;
        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to select this client", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!isReturn)
                    {
                        NewRentalModuleForm UserInfoModule = new NewRentalModuleForm();
                        // Name is always index 1, so it is best to leave at that instead of a name tjat could change.
                        UserInfoModule.txtBoxCustomerName.Text = dataGridUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                        UserInfoModule.txtBoxPhone.Text = dataGridUsers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                        UserInfoModule.txtBoxEmail.Text = dataGridUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        UserInfoModule.txtBoxStreet.Text = dataGridUsers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                        UserInfoModule.txtBoxDriversLicense.Text = dataGridUsers.Rows[e.RowIndex].Cells["DriversLicense"].Value.ToString();
                        UserInfoModule.txtBoxRep.Text = dataGridUsers.Rows[e.RowIndex].Cells["Rep"].Value.ToString();
                        UserInfoModule.comboBoxAcademy.Text = dataGridUsers.Rows[e.RowIndex].Cells["Academy"].Value.ToString();

                        this.Dispose();
                        UserInfoModule.ExistingUser = true;
                        UserInfoModule.DisableLicense();
                        UserInfoModule.ShowDialog();
                    }
                    else if (isReturn)
                    {
                        ReturnModule RentalReturn = new ReturnModule(dataGridUsers.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                                  dataGridUsers.Rows[e.RowIndex].Cells["DriversLicense"].Value.ToString());

                        this.Dispose();
                        RentalReturn.ShowDialog();
                        isReturn = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR Existing Customer Module:" + ex.Message);
                }
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void LoadUsers()
        {
            int i = 0;
            dataGridUsers.Rows.Clear();
            cm = new SqlCommand("SELECT Name, Phone, Email, Academy, DayNight, DriversLicenseNumber, Address, FireTecRepresentative FROM tbClients", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridUsers.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadUsers(); }

            //SQL
            int i = 0;
            dataGridUsers.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbClients WHERE Name LIKE '%" + searchTerm + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridUsers.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }

            dr.Close();
            con.Close();
        }

    }
}