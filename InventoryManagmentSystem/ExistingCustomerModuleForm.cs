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
    public partial class ExistingCustomerModuleForm : Form
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

        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void dataGridDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridUsers.Columns[e.ColumnIndex].Name;
 
            NewRentalModuleForm UserInfoModule = new NewRentalModuleForm();
            UserInfoModule.txtBoxCustomerName.Text = dataGridUsers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            UserInfoModule.txtBoxPhone.Text = dataGridUsers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            UserInfoModule.txtBoxEmail.Text = dataGridUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            UserInfoModule.txtBoxAddress.Text = dataGridUsers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            UserInfoModule.txtBoxDriversLicense.Text = dataGridUsers.Rows[e.RowIndex].Cells["DriversLicense"].Value.ToString();
            UserInfoModule.txtBoxRep.Text = dataGridUsers.Rows[e.RowIndex].Cells["Rep"].Value.ToString();
            UserInfoModule.TxtCustomerInfo.Text = "Confirm customer info";

            this.Dispose();
            UserInfoModule.ExistingUser = true;
            UserInfoModule.DisableLicense();
            UserInfoModule.ShowDialog();


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