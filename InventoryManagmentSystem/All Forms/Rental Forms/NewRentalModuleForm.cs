using InventoryManagmentSystem.Academy;
using InventoryManagmentSystem.Rental_Forms;
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

        //Used for query this is a secret to see if frey will ever notice it but i doubt it since he is kind of an idiot lol that guy is the leader of the club and will never figure out a riddle as difficult as this one so i basically bodied him into reading an entire long line probably at like 150% zoom cause he cant even see lol get fucked......je
        string ItemIdClient = string.Empty;
        string ItemIdInventory = string.Empty;

        public bool ExistingUser = false;
        public string currentUser = "";
        public string license = "";
        public int ReturnReplace = 0;
        string ReplacmentSerial = "";
        string dueDate = "";
        string ClientId = string.Empty;
        string ClassId = string.Empty;
        public string drivers;


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
            if (items == null) { return; }

            dataGridViewClient.Rows.Clear();
            foreach ( var item in items )
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
            if(items == null ) { return; }

            foreach(var item in items )
            {
                if(item.GetColumnValue("ItemType") != cbItemType.Text ) { continue; }

                string materialOrColor = item.GetColumnValue("Material");
                if( materialOrColor == "" )
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

        public void LoadProfile(string driverLicense)
        {
            var client = HelperSql.ClientFindByDriversLicense(connection, driverLicense);
            if(client.Count() == 0) 
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
            license = labelClientDrivers.Text;

            var item = HelperSql.ClassFindByClassId(connection, ClassId);
            if(item != null )
            {
                labelClientClass.Text = item.GetColumnValue("Name");
            }

            //point of contact
            labelProfileDrivers.Text = "Point of contact:";

            flowLayoutPanelProfile.Visible = true;
            panelProfileRentalInfo.Visible = false;
            panelProfileMeasurments.Visible = false;
            license = labelProfileName.Text;

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
                string itemId = row.Cells["ItemId"].Value.ToString();
                bool isUpdated = HelperSql.ItemUpdate(connection, itemId, "Fire-Tec");
                if(isUpdated)
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
                string itemType = row.Cells["Item"].Value.ToString().ToLower();
                SetItemType(itemType);

                dataGridViewClient.Enabled = false;

                dueDate = row.Cells["DDate"].Value.ToString();
                string SelectedSerial = row.Cells["SerialNum"].Value.ToString();
                ItemIdClient = row.Cells["ItemId"].Value.ToString();
                labelOldItem.Text = SelectedSerial;
                labelTypeOfItem.Text = row.Cells["Item"].Value.ToString();

            }
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
                string message = "Are you sure you want to rent this item to " + labelProfileName.Text;
                if (!HelperFunctions.YesNoMessageBox(message, "Rent")) { return; }


                if (DateTime.Today == DatepickerDue.Value.Date)
                {
                    MessageBox.Show("Please select a due date");
                    return;
                }
                
                string itemId = row.Cells["ItemIdInv"].Value.ToString();
                bool isUpdated = HelperSql.ItemUpdate(connection, itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                if(!isUpdated) 
                {
                    MessageBox.Show("Failed to update item.");
                    return; 
                }
                isUpdated = HelperSql.HistoryInsert(connection, itemId, ClientId);
                MessageBox.Show("Rental has been successfully completed");
                LoadClient();
                LoadInventory();
                
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
            flowLayoutPanelProfile.Visible = true;
            AssignStudentForm dockedForm = panel2.Controls.OfType<AssignStudentForm>().FirstOrDefault();
            if (dockedForm != null)
            {
                dockedForm.Dispose();
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            flowLayoutPanelProfile.Visible = false ;

            AssignStudentForm AssignForm = new AssignStudentForm(null);
            HelperFunctions.OpenChildFormToPanel(panel2, AssignForm);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flowLayoutPanelProfile.Visible = false;
            NewClientForm clientForm = new NewClientForm("Individual", labelProfileName.Text);
            clientForm.txtBoxDriversLicense.Enabled = false;
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
        }
    }
}
