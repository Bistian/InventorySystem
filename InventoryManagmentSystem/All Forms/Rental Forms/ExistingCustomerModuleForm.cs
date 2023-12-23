using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class ExistingCustomerModuleForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        List<Dictionary<string, string>> clients = new List<Dictionary<string, string>>();

        public bool isReturn = false;

        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            clients = HelperSql.ClientFindAllProfiles(connection);
            cbActive.Checked = true;
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
            NewRentalModuleForm form = new NewRentalModuleForm(null, clientName);
            var parentForm = this.ParentForm as MainForm;
            try
            {
                form.UpdateProfile();
                parentForm.openChildForm(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }

            LoadClients();
        }

        private void LoadClients()
        {
            if(clients.Count == 0) { return; }

            uint count = 1;
            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                bool isActive = Boolean.Parse(client["IsActive"]);
                if((isActive == true && cbActive.Checked == true) || 
                    (isActive == false && cbInactive.Checked == true))
                {
                    AddClientToGrid(client, count);
                    ++count;
                }
            }
        }

        private void AddClientToGrid(Dictionary<string, string> client, uint count)
        {
            dataGridUsers.Rows.Add(
                count,
                client["Id"],
                client["Name"],
                client["Phone"],
                client["Email"],
                client["Academy"],
                client["Address"],
                client["DriversLicenseNumber"]);
                
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridUsers.Rows[e.RowIndex];
            string column = dataGridUsers.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_name"].Value.ToString();
            string clientId = row.Cells["column_id"].Value.ToString();
            string clientLicense = row.Cells["column_drivers_license"].Value.ToString();
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
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(clientLicense);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClients(); }

            dataGridUsers.Rows.Clear();
            var clients = HelperSql.ClientFindBySearchBar(connection, searchTerm);
            if (clients == null) { return; }

            uint count = 1;
            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                AddClientToGrid(client, count);
                ++count;
            }
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void cbInactive_CheckedChanged(object sender, EventArgs e)
        {
            LoadClients();
        }
    }
}