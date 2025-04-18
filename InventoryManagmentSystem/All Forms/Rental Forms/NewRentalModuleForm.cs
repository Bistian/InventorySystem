using InventoryManagmentSystem.Academy;
using InventoryManagmentSystem.Rental_Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class NewRentalModuleForm : Form
    {
        private string ItemIdClient = string.Empty;
        private string ItemIdInventory = string.Empty;

        private string ReplacmentSerial = "";
        private string dueDate = "";
        public string ClientId = string.Empty;
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
                HelperSql.ItemTypeLoadComboBox(cbItemType);
                HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
            }

            HelperSql.ItemTypeLoadComboBox(cbItemType);

            dataGridInv.Columns["column_mfd_inv"].DefaultCellStyle.Format = "d";
            HelperSql.ItemLoadDatagrid(dataGridInv, "WHERE i.Condition = 'Active'");
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["column_due_date"].DefaultCellStyle.Format = "d";
            dataGridViewClient.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";

            var items = HelperSql.ItemFindByClientId(ClientId);
            if (items.Count == 0)
            {
                items = HelperSql.ItemFindByClientId(drivers);
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
            dataGridInv.Rows.Clear();
            if (cbItemType.SelectedIndex < 0)
            {
                return;
            }

            string selection = cbItemType.SelectedItem.ToString().ToLower();

            if (selection == "boots")
            {
                dataGridInv.Columns["column_material_inv"].Visible = true;
                dataGridInv.Columns["column_color_inv"].Visible = false;
                dataGridInv.Columns["column_size_inv"].Visible = true;
            }
            else if (selection == "helmet")
            {
                dataGridInv.Columns["column_material_inv"].Visible = false;
                dataGridInv.Columns["column_color_inv"].Visible = true;
                dataGridInv.Columns["column_size_inv"].Visible = true;
            }
            else
            {
                dataGridInv.Columns["column_material_inv"].Visible = false;
                dataGridInv.Columns["column_color_inv"].Visible = false;
                dataGridInv.Columns["column_size_inv"].Visible = true;
            }

            if (selection == "boots")
            {
                HelperSql.BootsFindAllInStock(dataGridInv, textBoxSearchBar.Text);
            }
            else if (selection == "helmet")
            {
                HelperSql.HelmetFindAllInStock(dataGridInv, textBoxSearchBar.Text);
            }
            else if (selection == "jacket")
            {
                HelperSql.JacketFindAllInStock(dataGridInv, textBoxSearchBar.Text);
            }
            else if (selection == "mask")
            {
                HelperSql.MaskFindAllInStock(dataGridInv, textBoxSearchBar.Text);
            }
            else if (selection == "pants")
            {
                HelperSql.PantsFindAllInStock(dataGridInv, textBoxSearchBar.Text);
            }
        }

        public void LoadProfile(string clientId, string Name)
        {
            var client = HelperSql.ClientFindById(clientId);
            if (client.IsEmpty())
            {
                client = HelperSql.ClientFindByDriversLicense(clientId, Name);
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

            var item = HelperSql.ClassFindByClassId(ClassId);
            if (item != null)
            {
                string startDate = item.GetColumnValue("StartDate");
                string startFormatted = DateTime.Parse(startDate).ToString("yyyy/MM/dd");
                startFormatted = HelperFunctions.DateCrop(startFormatted, "mm/dd/yyyy");

                string endDate = item.GetColumnValue("EndDate");
                string endFormatted = DateTime.Parse(endDate).ToString("yyyy/MM/dd");
                endFormatted = HelperFunctions.DateCrop(endFormatted, "mm/dd/yyyy");

                labelClientClass.Text = item.GetColumnValue("Name") +
                    "\n Start Date " + startFormatted +
                    "\n End Date " + endFormatted;
            }

            labelProfileDrivers.Text = "License Number:";

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

        private void RefreshClientActivity()
        {
            foreach (DataGridViewRow row in dataGridViewClient.Rows)
            {
                if (row.Cells["column_item_type"].Value != null && row.Cells["column_item_type"].Value.ToString() != "boots")
                {
                    // Client Has items other than boots
                    HelperSql.ClientUpdateActivity(ClientId, true);
                    return;
                }
            }
            // Client has boots or nohting
            HelperSql.ClientUpdateActivity(ClientId, false);
        }

        private void SetItemType(string itemType)
        {
            if (itemType == "jacket")
            {
                cbItemType.SelectedIndex = 0;
            }
            else if (itemType == "pants")
            {
                cbItemType.SelectedIndex = 1;
            }
            else if (itemType == "boots")
            {
                cbItemType.SelectedIndex = 2;
            }
            else if (itemType == "helmet")
            {
                cbItemType.SelectedIndex = 3;
            }
            else if (itemType == "mask")
            {
                cbItemType.SelectedIndex = 4;
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

        private void dataGridInv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridViewRow row = dataGridInv.Rows[e.RowIndex];
            if (ReturnReplace == 1 || ReturnReplace == 0)
            {
                string message = "Are you sure you want to assign this item to " + labelProfileName.Text;
                if (!HelperFunctions.YesNoMessageBox(message, "Rent")) { return; }

                if (DateTime.Today >= DatepickerDue.Value.Date && cbItemType.Text != "boots")
                {
                    MessageBox.Show("Please select a valid due date");
                    return;
                }
                bool isUpdated = false;
                string itemId = row.Cells["column_id_inv"].Value.ToString();
                if (cbItemType.Text == "boots")
                {
                    isUpdated = HelperSql.ItemUpdateBoots(itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                }
                else
                {
                    isUpdated = HelperSql.ItemUpdate(itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                }
                if (!isUpdated)
                {
                    MessageBox.Show("Failed to update item.");
                    return;
                }
                HelperSql.HistoryInsert(itemId, ClientId);
                MessageBox.Show("assignment has been successfully completed");
                HelperSql.ClientUpdateActivity(ClientId, true);
                LoadClient();
                LoadInventory();
                RefreshClientActivity();
            }
            else if (ReturnReplace == 2)
            {
                ReplacmentSerial = row.Cells["column_serial_inv"].Value.ToString();
                labelReplacmentItem.Text = ReplacmentSerial;
                ItemIdInventory = row.Cells["column_id_inv"].Value.ToString();

                HelperSql.ItemUpdate(ItemIdClient, "Fire-Tec");
                HelperSql.HistoryUpdate(ItemIdClient, ClientId);
                HelperSql.ItemUpdate(ItemIdInventory, ClientId.ToString(), dueDate);
                HelperSql.HistoryInsert(ItemIdInventory, ClientId);

                LoadClient();
                LoadInventory();
                ReturnReplace = 0;
                cbItemType.Enabled = true;
                dataGridViewClient.Enabled = true;
                MessageBox.Show("Item Replaced!");
            }
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
                bool isUpdated = HelperSql.ItemUpdate(itemId, "Fire-Tec");
                if (isUpdated)
                {
                    var items = HelperSql.ClientFindRented(ClientId);
                    if (items.Count < 1)
                    {
                        HelperSql.ClientUpdateActivity(ClientId, false);
                    }
                    HelperSql.HistoryUpdate(itemId, ClientId);
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

        private void comboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void textBoxSearchBar_TextChanged(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void btnEditNotes_Click(object sender, EventArgs e)
        {
            textBoxNotes.ReadOnly = false;
            buttonSaveNotes.Enabled = true;
            textBoxNotes.Focus();
        }

        private void btnSaveNotes_Click(object sender, EventArgs e)
        {
            textBoxNotes.ReadOnly = true;
            buttonSaveNotes.Enabled = false;

            string query = "UPDATE tbClients SET Notes = @Notes WHERE Id = @ClientId";
            
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Notes", textBoxNotes.Text);
                    command.Parameters.AddWithValue("@ClientId", ClientId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Note has been successfully saved");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
        }

        public void btnProfile_Click(object sender, EventArgs e)
        {
            labelProfileDrivers.Text = "License Number:";

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
            AssignStudentForm dockedForm = panel2.Controls.OfType<AssignStudentForm>().FirstOrDefault();
            NewClientForm dockedForm2 = panel2.Controls.OfType<NewClientForm>().FirstOrDefault();
            if (dockedForm != null)
            {
                dockedForm.Dispose();
            }
            if (dockedForm2 != null)
            {
                dockedForm2.Dispose();
            }
            LoadProfile(ClientId, currentUser);
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
            clientForm.clientId = ClientId;
            cbItemType.Items.Clear();
            HelperSql.ItemTypeLoadComboBox(cbItemType);
            HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
        }
    }
}
