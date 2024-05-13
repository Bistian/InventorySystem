using InventoryManagmentSystem.Academy;
using InventoryManagmentSystem.Rental_Forms;
using Microsoft.VisualBasic.Devices;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class NewRentalModuleForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        private string ItemIdClient = string.Empty;
        private string ItemIdInventory = string.Empty;

        private string ReplacmentSerial = "";
        private string dueDate = "";
        private string ClientId = string.Empty;
        private string ClassId = string.Empty;

        public int ReturnReplace = 0;
        public string license = "";
        public string drivers = string.Empty;
        public bool ExistingUser = false;
        public string currentUser = "";

        public NewRentalModuleForm(string rentalType = null, string clientName = null)
        {
            InitializeComponent();


            if (clientName != null)
            {
                labelProfileName.Text = clientName;
            }
            else
            {
                panelButtons.Visible = false;
                NewClientForm clientForm = new NewClientForm(rentalType, clientName);
                HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
                HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
            }
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["column_due_date"].DefaultCellStyle.Format = "d";
            dataGridViewClient.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";

            var items = HelperSql.ItemFindByClientId(connection, ClientId);
            if (items.Count == 0)
            {
                items = HelperSql.ItemFindByClientId(connection, drivers);
            }
            if (items == null) { return; }

            dataGridViewClient.Rows.Clear();
            foreach (var item in items)
            {
                dataGridViewClient.Rows.Add(
                    item.GetColumnValue("ItemType"),
                    item.GetColumnValue("DueDate"),
                    item.GetColumnValue("Brand"),
                    item.GetColumnValue("SerialNumber"),
                    item.GetColumnValue("Size"),
                    item.GetColumnValue("ManufactureDate"),
                    item.GetColumnValue("Id"));
            }
        }

        private void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            dataGridInv.Rows.Clear();
            var items = HelperSql.ItemFindBySearchBar(connection, textBoxSearchBar.Text);
            if (items == null) { return; }

            foreach (var item in items)
            {
                if (item.GetColumnValue("ItemType") != cbItemType.Text) { continue; }

                string materialOrColor = item.GetColumnValue("Material");
                if (materialOrColor == "")
                {
                    materialOrColor = item.GetColumnValue("Color");
                }
                dataGridInv.Rows.Add(
                   item.GetColumnValue("Brand"),
                   item.GetColumnValue("SerialNumber"),
                   item.GetColumnValue("Size"),
                   item.GetColumnValue("ManufactureDate"),
                   item.GetColumnValue("Condition"),
                   materialOrColor,
                   item.GetColumnValue("Id"));
            }
        }

        public void LoadProfile(string clientId)
        {
            var client = HelperSql.ClientFindById(connection, clientId);
            if (client.IsEmpty())
            {
                client = HelperSql.ClientFindByDriversLicense(connection, clientId);
            }
            if (client.Count() == 0)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            labelProfileName.Text = client.GetColumnValue("Name");
            labelClientPhone.Text = client.GetColumnValue("Phone");
            labelClientEmail.Text = client.GetColumnValue("Email");
            lableRentalInfo.Text = client.GetColumnValue("Academy");
            labelClientDrivers.Text = client.GetColumnValue("DriversLicenseNumber");
            labelClientAddress.Text = client.GetColumnValue("Address");
            labelClientChest.Text = client.GetColumnValue("Chest");
            labelClientSleeve.Text = client.GetColumnValue("Sleeve");
            labelClientWaist.Text = client.GetColumnValue("Waist");
            labelClientInseam.Text = client.GetColumnValue("Inseam");
            labelClientHips.Text = client.GetColumnValue("Hips");
            labelClientHeight.Text = client.GetColumnValue("Height");
            labelClientWeight.Text = client.GetColumnValue("Weight");
            textBoxNotes.Text = client.GetColumnValue("Notes");
            ClientId = client.GetColumnValue("Id");
            ClassId = client.GetColumnValue("IdClass");
            drivers = client.GetColumnValue("DriversLicenseNumber");
            license = labelClientDrivers.Text;

            var item = HelperSql.ClassFindByClassId(connection, ClassId);
            if (item != null)
            {
                labelClientClass.Text = item.GetColumnValue("Name");
            }

            labelProfileDrivers.Text = "Point of contact:";

            panelProfileRentalInfo.Visible = true;
            panelProfileMeasurments.Visible = true;
            flowLayoutPanelProfile.Visible = true;
            license = labelProfileName.Text;

            panelButtons.Visible = true;
            panelButtons.AutoScroll = false;
            flowLayoutPanelProfile.Visible = true;
            flowLayoutPanelProfile.AutoScroll = false;
            splitContainerInventories.Visible = true;
            panelRentals.Visible = true;

            LoadClient();
            panelButtons.Dock = DockStyle.Top;
            flowLayoutPanelProfile.Dock = DockStyle.Bottom;
        }

        public void UpdateProfile()
        {
            ExistingUser = true;
            flowLayoutPanelProfile.Visible = true;
            panelProfileRentalInfo.Visible = false;
            panelProfileMeasurments.Visible = false;
            license = labelProfileName.Text;
            flowLayoutPanelProfile.Visible = false;
            flowLayoutPanelProfile.AutoScroll = false;
            splitContainerInventories.Visible = true;
            panelRentals.Visible = true;
            LoadClient();
        }

        private void comboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void textBoxSearchBar_TextChanged(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void buttonEditNotes_Click(object sender, EventArgs e)
        {
            textBoxNotes.ReadOnly = false;
            buttonSaveNotes.Enabled = true;
            textBoxNotes.Focus();
        }

        private void buttonSaveNotes_Click(object sender, EventArgs e)
        {
            textBoxNotes.ReadOnly = true;
            buttonSaveNotes.Enabled = false;

            string query = "UPDATE tbClients SET Notes = @Notes WHERE DriversLicenseNumber = @DriversLicenseNumber";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Notes", textBoxNotes.Text);
            command.Parameters.AddWithValue("@DriversLicenseNumber", license);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Note has been successfully saved");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; };

            ReturnOrReplacecs ModForm = new ReturnOrReplacecs(this);
            ModForm.ShowDialog();

            DataGridViewRow row = dataGridViewClient.Rows[e.RowIndex];
            //Return Item
            if (ReturnReplace == 1)
            {
                string itemId = row.Cells["column_item_id"].Value.ToString();
                bool isUpdated = HelperSql.ItemUpdate(connection, itemId, "Fire-Tec");
                if (isUpdated)
                {
                    HelperSql.HistoryUpdate(connection, itemId, ClientId);
                    MessageBox.Show("Item Returned");
                }
                else { MessageBox.Show("Failed to return the item."); }
                LoadClient();
                LoadInventory();
            }
            //Replace Item
            else if (ReturnReplace == 2)
            {
                //lock the item type that is shown when a replacment is being done to match the item type of the item being replaced
                string itemType = row.Cells["column_item_type"].Value.ToString().ToLower();
                SetItemType(itemType);

                dataGridViewClient.Enabled = false;

                dueDate = row.Cells["column_due_date"].Value.ToString();
                string SelectedSerial = row.Cells["column_serial_number"].Value.ToString();
                ItemIdClient = row.Cells["column_item_id"].Value.ToString();
                labelOldItem.Text = SelectedSerial;
                labelTypeOfItem.Text = row.Cells["column_item_type"].Value.ToString();
            }
            //update client activity
            RefreshClientActivity();
        }

        private void SetItemType(string itemType)
        {
            if (itemType == "helmet")
            {
                cbItemType.SelectedIndex = 0;
            }
            if (itemType == "jacket")
            {
                cbItemType.SelectedIndex = 1;
            }
            if (itemType == "pants")
            {
                cbItemType.SelectedIndex = 2;
            }
            if (itemType == "boots")
            {
                cbItemType.SelectedIndex = 3;
            }
        }

        private void dataGridInv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridViewRow row = dataGridInv.Rows[e.RowIndex];
            if (ReturnReplace == 1 || ReturnReplace == 0)
            {
                string message = "Are you sure you want to assign this item to " + labelProfileName.Text;
                if (!HelperFunctions.YesNoMessageBox(message, "Rent")) { return; }


                if (DateTime.Today == DatepickerDue.Value.Date && cbItemType.Text != "boots")
                {
                    MessageBox.Show("Please select a due date");
                    return;
                }
                bool isUpdated = false;
                string itemId = row.Cells["ItemIdInv"].Value.ToString();
                if (cbItemType.Text == "boots")
                {
                    isUpdated = HelperSql.ItemUpdateBoots(connection, itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                }
                else
                {
                    isUpdated = HelperSql.ItemUpdate(connection, itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                }
                if (!isUpdated)
                {
                    MessageBox.Show("Failed to update item.");
                    return;
                }
                isUpdated = HelperSql.HistoryInsert(connection, itemId, ClientId);
                MessageBox.Show("assignment has been successfully completed");
                LoadClient();
                LoadInventory();
                RefreshClientActivity();
            }
            else if (ReturnReplace == 2)
            {
                ReplacmentSerial = row.Cells["Serial"].Value.ToString();
                labelReplacmentItem.Text = ReplacmentSerial;
                ItemIdInventory = row.Cells["ItemIdInv"].Value.ToString();

                HelperSql.ItemUpdate(connection, ItemIdClient, "Fire-Tec");
                HelperSql.HistoryUpdate(connection, ItemIdClient, ClientId);
                HelperSql.ItemUpdate(connection, ItemIdInventory, ClientId.ToString(), dueDate);
                HelperSql.HistoryInsert(connection, ItemIdInventory, ClientId);

                LoadClient();
                LoadInventory();
                ReturnReplace = 0;
                cbItemType.Enabled = true;
                dataGridViewClient.Enabled = true;
                MessageBox.Show("Item Replaced!");

            }
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            NewItemForm ModForm = new NewItemForm();
            ModForm.ShowDialog();
            LoadInventory();
        }

        private void NewRentalModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            panelProfileRentalInfo.Visible = false;
            panelProfileMeasurments.Visible = false;
            flowLayoutPanelProfile.Visible = true;
            license = labelProfileName.Text;

            panelButtons.Visible = true;
            panelButtons.AutoScroll = false;
            flowLayoutPanelProfile.Visible = true;
            flowLayoutPanelProfile.AutoScroll = false;
            splitContainerInventories.Visible = true;
            panelRentals.Visible = true;
            AssignStudentForm dockedForm = panel2.Controls.OfType<AssignStudentForm>().FirstOrDefault();
            if (dockedForm != null)
            {
                dockedForm.Dispose();
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            flowLayoutPanelProfile.Visible = false;

            AssignStudentForm AssignForm = new AssignStudentForm(null);
            HelperFunctions.OpenChildFormToPanel(panel2, AssignForm);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flowLayoutPanelProfile.Visible = false;
            NewClientForm clientForm = new NewClientForm("Individual", labelProfileName.Text);
            clientForm.txtBoxDriversLicense.Enabled = false;
            cbItemType.Items.Clear();
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
        }

        private void RefreshClientActivity()
        {
            foreach (DataGridViewRow row in dataGridViewClient.Rows)
            {
                if (row.Cells["column_item_type"].Value != null && row.Cells["column_item_type"].Value.ToString() != "boots")
                {
                    // Client Has items other than boots
                    HelperSql.ClientUpdateActivity(connection, ClientId, true);
                    return;
                }
            }
            // Client has boots or nohting
            HelperSql.ClientUpdateActivity(connection, ClientId, false);
        }
    }
}
