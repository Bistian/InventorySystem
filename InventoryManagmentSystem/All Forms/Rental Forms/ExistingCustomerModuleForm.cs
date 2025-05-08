using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class ExistingCustomerModuleForm : Form
    {
        List<Client> clients = new List<Client>();

        public bool isReturn = false;

        public ExistingCustomerModuleForm()
        {
            InitializeComponent();
            Program.ClientService.LoadToDataGrid(dataGridUsers);
            check_box_active.Checked = true;
        }

        private bool DeleteItem(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7) { return false; }

            string message = "Do you want to delete this Client?";

            string id = dataGridUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            
            var rentedItems = Program.ItemService.FindByClientId(Guid.Parse(id));
            
            if (rentedItems.Count > 0)
            {
                message = "Client did not return all items, cannot be deleted";
                MessageBox.Show(message, "Can't delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return true; }

            var client = Program.ClientService.FindById(Guid.Parse(id)); ;
            var isDeleted = Program.ClientService.Delete(client);
            if(isDeleted) 
            {
                message = "Client cound not be deleted";
                MessageBox.Show(message, "Can't delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            LoadClients();
            return true;
        }

        private void UpdateItem(string clientName)
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

            uint count = 1;
            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                if (check_box_active.Checked && check_box_inactive.Checked)
                {
                    AddClientToGrid(client, count);
                }
                else if (check_box_active.Checked && client.IsActive)
                {
                    AddClientToGrid(client, count);
                }
                else if (check_box_inactive.Checked && !client.IsActive)
                {
                    AddClientToGrid(client, count);
                }
                ++count;
            }
        }

        private void AddClientToGrid(Client client, uint count)
        {
            dataGridUsers.Rows.Add(
                count,
                client.Id,
                client.Name,
                client.PhoneNumber,
                client.Email,
                "Academy ID",
                "Address",
                client.DriverLicense);
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridUsers.Rows[e.RowIndex];
            string column = dataGridUsers.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_name"].Value.ToString();
            string clientLicense = row.Cells["column_drivers_license"].Value.ToString();
            if (column == "column_update")
            {
                UpdateItem(clientName);
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
                Profile.LoadProfile(clientLicense,clientName);
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
            if (searchBar.Text.Length < 1)
            {
                LoadClients();
                return;
            }
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClients(); }
            var clients = new List<Client>();
            dataGridUsers.Rows.Clear();

            clients = Program.ClientService.FindBySearchBar(searchTerm, check_box_active.Checked, check_box_inactive.Checked);
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
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClients(); }
            dataGridUsers.Rows.Clear();

            clients = Program.ClientService.FindBySearchBar(searchTerm, check_box_active.Checked, check_box_inactive.Checked);
            if (clients == null) { return; }

            uint count = 1;
            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                AddClientToGrid(client, count);
                ++count;
            }
        }

        private void cbInactive_CheckedChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClients(); }
            dataGridUsers.Rows.Clear();

            clients = Program.ClientService.FindBySearchBar(searchTerm, check_box_active.Checked, check_box_inactive.Checked);
            if (clients == null) { return; }

            uint count = 1;
            dataGridUsers.Rows.Clear();
            foreach (var client in clients)
            {
                AddClientToGrid(client, count);
                ++count;
            }
        }
    }
}
