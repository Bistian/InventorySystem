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
        string clientType = "Individuals";
        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            LoadUsers();
            cbClientType.SelectedIndex = 0;
        }

        private bool DeleteItem(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6) { return false; }

            string message = "Do you want to delete this price?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return true; }

            string query = "DELETE FROM tbClients WHERE name=@name";
            string name = dataGridUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                cm = new SqlCommand(query, con);
                cm.Parameters.AddWithValue("@name", name);
                con.Open();
                cm.ExecuteNonQuery();
                LoadUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();

            return true;
        }

        private void UpdateItem(string clientName, string licence)
        {
            NewRentalModuleForm form = new NewRentalModuleForm(cbClientType.Text, clientName);
            var parentForm = this.ParentForm as MainForm;
            bool isNotIndividual = true;
            try
            {
                if (cbClientType.SelectedIndex == 0)
                {
                    isNotIndividual = false;
                }
                form.UpdateProfile(isNotIndividual, licence);
                parentForm.openChildForm(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }

            LoadUsers();
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridUsers.Rows[e.RowIndex];
            string column = dataGridUsers.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0) { return; }

            string clientName = row.Cells["column_name"].Value.ToString();
            string licence = row.Cells["column_id"].Value.ToString();
            if (column == "column_update")
            {
                UpdateItem(clientName, licence);
                return;
            }
            if (DeleteItem(e)) { return; }

            string message = "Are you sure you want to select this client";
            if (!HelperFunctions.YesNoMessageBox(message, "Continue"))
            {
                return;
            }

            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null,clientName);
            try
            {
                if (cbClientType.Text == "Individuals")
                {
                    Profile.LoadProfile(false, licence);
                }
                else if(cbClientType.Text == "Departments")
                {
                    Profile.LoadProfile(true, licence);
                }
                else if(cbClientType.Text == "Academies")
                {
                    Profile.LoadProfile(true, licence);
                }
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
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
            dataGridUsers.Rows.Clear();
            cm = new SqlCommand("SELECT Name, Phone, Email, Academy, Address,DriversLicenseNumber, FireTecRepresentative FROM tbClients WHERE Type = @ClientType", con);
            cm.Parameters.AddWithValue("@ClientType", clientType);
            con.Open();
            try
            {
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridUsers.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
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
            cm = new SqlCommand("SELECT Name, Phone, Email, Academy, Address,DriversLicenseNumber, FireTecRepresentative FROM tbClients WHERE (Name LIKE '%" + searchTerm + "%' OR Academy LIKE '%" + searchTerm + "%') AND Type = @ClientType", con);
            cm.Parameters.AddWithValue("@ClientType", clientType);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                dataGridUsers.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }

            dr.Close();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbClientType.SelectedIndex == 0) 
            {
                clientType = "Individuals";
                dataGridUsers.Columns[0].HeaderText = "Name";
                dataGridUsers.Columns[3].HeaderText = "Academy";
            }
            else if(cbClientType.SelectedIndex == 1)
            {
                clientType = "Departments";
                dataGridUsers.Columns[0].HeaderText = "Point Of Contact";
                dataGridUsers.Columns[3].HeaderText = "Department";
            }
            else if (cbClientType.SelectedIndex == 2)
            {
                clientType = "Academies";
                dataGridUsers.Columns[0].HeaderText = "Point Of Contact";
                dataGridUsers.Columns[3].HeaderText = "Academy";
            }
            LoadUsers();
        }

        private void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}