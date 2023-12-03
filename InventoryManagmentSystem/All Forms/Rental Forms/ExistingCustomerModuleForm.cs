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
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public bool isReturn = false;
        string clientType = "Individuals";

        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            LoadClients();
            cbClientType.SelectedIndex = 0;
        }

        private bool DeleteItem(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7) { return false; }

            string message = "Do you want to delete this Client?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return true; }

            string query = "DELETE FROM tbClients WHERE Name=@Name";
            string name = dataGridUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                command.ExecuteNonQuery();
                LoadClients();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();

            LoadClients();
            return true;
        }

        private void UpdateItem(string clientName, string clientId)
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
                form.UpdateProfile(isNotIndividual, clientId);
                parentForm.openChildForm(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }

            LoadClients();
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridUsers.Rows[e.RowIndex];
            string column = dataGridUsers.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_name"].Value.ToString();
            string clientId = row.Cells["column_id"].Value.ToString();
            if (column == "column_update")
            {
                UpdateItem(clientName, clientId);
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
                    Profile.LoadProfile(false, clientId);
                }
                else if(cbClientType.Text == "Departments")
                {
                    Profile.LoadProfile(true, clientId);
                }
                else if(cbClientType.Text == "Academies")
                {
                    Profile.LoadProfile(true, clientId);
                }
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void LoadClients()
        {
            var clients = HelperSql.ClientFindByType(connection, clientType);
            if(clients == null) { return; }

            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                AddClientToGrid(client);
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClients(); }

            dataGridUsers.Rows.Clear();
            var clients = HelperSql.ClientFindBySearchBar(connection, searchTerm);
            if (clients == null) { return; }

            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                AddClientToGrid(client);
            }
        }

        private void AddClientToGrid(Dictionary<string,string> client)
        {
            dataGridUsers.Rows.Add(
                client["Name"],
                client["Phone"],
                client["Email"],
                client["Academy"],
                client["Address"],
                client["Id"]);
        }
    }
}