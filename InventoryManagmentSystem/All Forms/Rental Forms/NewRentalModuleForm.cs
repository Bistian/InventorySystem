using InventoryManagmentSystem.Database.Types;
using InventoryManagmentSystem.Rental_Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class NewRentalModuleForm : Form
    {
        private Guid ItemIdGridClient = Guid.Empty;
        private Guid ItemIdGridInventory = Guid.Empty;

        private string ReplacementSerial = "";
        private string DueDate = "";
        private Guid? ClassId = null;

        public Guid ClientId = Guid.Empty;
        public int ReturnReplace = 0;
        public string Drivers = string.Empty;
        public bool ExistingUser = false;
        public string CurrentUser = "";

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
                Program.ItemService.LoadComboBoxWithItemTypes(cbItemType);
                HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
            }

            Program.ItemService.LoadComboBoxWithItemTypes(cbItemType);

            dataGridInv.Columns["column_mfd_inv"].DefaultCellStyle.Format = "d";
            FillGrid();
        }

        private void FillGrid()
        {
            var items = Program.ItemService.FindWhere(i => i.Condition != ItemConditions.Retired);
            int index = 0;
            foreach(var i in items)
            {
                dataGridInv.Rows.Add(
                    ++index,
                    i.Id,
                    i.Size,
                    i.Material,
                    i.Color,
                    i.Brand,
                    i.Condition,
                    i.SerialNumber,
                    "Acquisition Date",
                    i.ManufacturedAt,
                    i.IdClient,
                    i.Type,
                    "Client Name"
                );
            }
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["column_due_date"].DefaultCellStyle.Format = "d";
            dataGridViewClient.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";

            var items = Program.ItemService.FindByClientId(ClientId);
            if (items == null) { return; }

            dataGridViewClient.Rows.Clear();
            foreach (var item in items)
            {
                dataGridViewClient.Rows.Add(
                    item.Type,
                    item.DueDate,
                    item.Brand,
                    item.SerialNumber,
                    item.Size,
                    item.ManufacturedAt,
                    item.Id
                );
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

            List<ItemFull> items = new List<ItemFull>();
            if (selection == "boots")
            {
                if(textBoxSearchBar.Text.Length > 0)
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Boots && 
                        i.SerialNumber.Contains(textBoxSearchBar.Text)
                    );
                }
                else
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Boots
                    );
                }
            }
            else if (selection == "helmet")
            {
                if (textBoxSearchBar.Text.Length > 0)
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Helmet &&
                        i.SerialNumber.Contains(textBoxSearchBar.Text)
                    );
                }
                else
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Helmet
                    );
                }
            }
            else if (selection == "jacket")
            {
                if (textBoxSearchBar.Text.Length > 0)
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Jacket &&
                        i.SerialNumber.Contains(textBoxSearchBar.Text)
                    );
                }
                else
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Jacket
                    );
                }
            }
            else if (selection == "mask")
            {
                if (textBoxSearchBar.Text.Length > 0)
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Mask &&
                        i.SerialNumber.Contains(textBoxSearchBar.Text)
                    );
                }
                else
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Mask
                    );
                }
            }
            else if (selection == "pants")
            {
                if (textBoxSearchBar.Text.Length > 0)
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Pants &&
                        i.SerialNumber.Contains(textBoxSearchBar.Text)
                    );
                }
                else
                {
                    items = Program.ItemService.FindWhere(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired &&
                        i.Type == ItemTypes.Pants
                    );
                }
            }

            int index = 0;
            foreach (var i in items)
            {
                dataGridInv.Rows.Add(
                    ++index,
                    i.Id,
                    i.Type,
                    i.Brand,
                    i.SerialNumber,
                    i.Size,
                    i.ManufacturedAt,
                    i.Condition,
                    i.IdClient,
                    i.Material
                );
            }
        }

        public void LoadProfile(string clientId, string name)
        {
            // TODO: This is legacy, driver License was used as id before.
            Guid id = Guid.Parse(clientId);
            var client = Program.ClientService.FindById(id);

            if (client == null)
            {
                // This is legacy, from when driver License was used as id
                client = Program.ClientService.FindByDriverLicense(clientId, name);
                if (client == null)
                {
                    Console.WriteLine("Client not found.");
                    return;
                }
            }
            ClientId = client.Id;
            Drivers = client.DriverLicense;

            labelProfileName.Text = client.Name;
            labelClientPhone.Text = client.PhoneNumber;
            labelClientEmail.Text = client.Email;
            labelClientDrivers.Text = client.DriverLicense;

            var student = Program.StudentService.FindByIdClient(id);
            var classEntity = Program.ClassService.FindById(student.IdClass);
            var academy = Program.AcademyService.FindById(classEntity.IdAcademy);
            lableRentalInfo.Text = academy.Name;

            
            labelClientAddress.Text = Program.AddressService.Location(client.IdAddress);

            var measurement = Program.MeasurementService.FindById(client.IdMeasurement);
            labelClientChest.Text = measurement.Chest;
            labelClientSleeve.Text = measurement.Sleeve;
            labelClientWaist.Text = measurement.Waist;
            labelClientInseam.Text = measurement.Inseam;
            labelClientHips.Text = measurement.Hips;
            labelClientHeight.Text = measurement.Height;
            labelClientWeight.Text = measurement.Weight;

            //textBoxNotes.Text = client.GetColumnValue("Notes");


            if (classEntity != null)
            {
                string startDate = classEntity.StartAt.Date.ToString();
                string startFormatted = DateTime.Parse(startDate).ToString("yyyy/MM/dd");
                startFormatted = HelperFunctions.DateCrop(startFormatted, "mm/dd/yyyy");

                string endDate = classEntity.EndAt.Date.ToString();
                string endFormatted = DateTime.Parse(endDate).ToString("yyyy/MM/dd");
                endFormatted = HelperFunctions.DateCrop(endFormatted, "mm/dd/yyyy");

                labelClientClass.Text = classEntity.Name +
                    "\n Start Date " + startFormatted +
                    "\n End Date " + endFormatted;
            }

            labelProfileDrivers.Text = "License Number:";

            panelProfileRentalInfo.Visible = true;
            panelProfileMeasurments.Visible = true;
            flowLayoutPanelProfile.Visible = true;

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
                    Program.ClientService.Activity(ClientId, true);
                    return;
                }
            }
            // Client has boots or nohting
            Program.ClientService.Activity(ClientId, false);
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

                var itemId = Guid.Parse(row.Cells["column_id_inv"].Value.ToString());
                var item = Program.ItemService.FindById(itemId);
                var rental = Program.RentalService.FindActiveByIdItem(itemId);
                item.IdClient = ClientId;
                item.DueDate = DatepickerDue.Value.Date;
                bool isUpdated = Program.ItemService.Update(item);
                if (!isUpdated)
                {
                    MessageBox.Show("Failed to update item.");
                    return;
                }

                Program.RentalService.Return(rental);

                MessageBox.Show("Rental completed!");
                Program.ClientService.Activity(ClientId, true);
                LoadClient();
                LoadInventory();
                RefreshClientActivity();
            }
            else if (ReturnReplace == 2)
            {
                labelReplacmentItem.Text = row.Cells["column_serial_inv"].Value.ToString();
                ItemIdGridInventory = Guid.Parse(row.Cells["column_id_inv"].Value.ToString());

                // Return what I rented by mistake
                Program.ItemService.Return(ItemIdGridClient);
                var returning = Program.RentalService.FindActiveByIdItem(ItemIdGridClient);
                returning.ReturnedAt = DateTime.Now.Date;
                Program.RentalService.Update(returning);

                // Rent the right thing
                Program.ItemService.Rent(ItemIdGridInventory, ClientId, DateTime.Parse(DueDate));
                Program.RentalService.Add(ClientId, ItemIdGridInventory, "Notes", DateTime.Now.Date, DateTime.Parse(DueDate));

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
            //Return Item2
            if (ReturnReplace == 1)
            {
                var itemId = Guid.Parse(row.Cells["column_item_id"].Value.ToString());
                
                Program.ItemService.Return(itemId);
                var returning = Program.RentalService.FindActiveByIdItem(itemId);
                if(returning == null)
                {
                    Console.WriteLine("This item was not rented or does not exist.");
                    return;
                }

                Program.RentalService.Return(returning);

                // Check if client still has items rented
                var items = Program.ItemService.FindByClientId(ClientId);
                if (items.Count < 1)
                {
                    Program.ClientService.Activity(ClientId, false);
                }

                MessageBox.Show("Item Returned");

                LoadClient();
                LoadInventory();
            }
            //Replace Item2
            else if (ReturnReplace == 2)
            {
                //lock the item type that is shown when a replacment is being done to match the item type of the item being replaced
                string itemType = row.Cells["column_item_type"].Value.ToString().ToLower();
                SetItemType(itemType);

                dataGridViewClient.Enabled = false;

                DueDate = row.Cells["column_due_date"].Value.ToString();
                string SelectedSerial = row.Cells["column_serial_number"].Value.ToString();
                ItemIdGridClient = Guid.Parse(row.Cells["column_item_id"].Value.ToString());
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
            LoadProfile(ClientId.ToString(), CurrentUser);
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
            clientForm.clientId = ClientId.ToString();
            cbItemType.Items.Clear();
            Program.ItemService.LoadComboBoxWithItemTypes(cbItemType);
            HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
        }
    }
}
