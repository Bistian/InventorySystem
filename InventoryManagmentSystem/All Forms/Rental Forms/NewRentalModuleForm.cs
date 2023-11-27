using InventoryManagmentSystem.Academy;
using InventoryManagmentSystem.Rental_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace InventoryManagmentSystem
{
    public partial class NewRentalModuleForm : Form
    {
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection connection = new SqlConnection(connectionString);

        //Used for query
        Guid ItemIdClient = Guid.Empty;
        Guid ItemIdInventory = Guid.Empty;

        public bool ExistingUser = false;
        public string currentUser = "";
        public string license = "";
        public int ReturnReplace = 0;
        string ReplacmentSerial = "";
        String dueDate = "";
        Guid ClientId = Guid.Empty;
        Guid ClassId = Guid.Empty;
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
                HelperDatabaseCall.ItemTypeLoadComboBox(connection, comboBoxItemType);
                HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
            }
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["column_due_date"].DefaultCellStyle.Format = "d";
            dataGridViewClient.Columns["column_manufacture_date"].DefaultCellStyle.Format = "d";

            var items = HelperDatabaseCall.ItemFindByClientId(connection, ClientId);
            if (items != null) { return; }

            dataGridViewClient.Rows.Clear();
            foreach ( var item in items )
            {
                string brand = "";
                string size = "";
                string manufacture = "";
                if(item.ItemType == "boots") 
                {
                    var boots = (Boots)item.Specifications;
                    brand = boots.Brand;
                    size = boots.Size;
                    manufacture = boots.ManufactureDate;
                }
                else if(item.ItemType == "helmet") 
                {
                    var helmet = (Helmet)item.Specifications;
                    brand = helmet.Brand;
                    manufacture = helmet.ManufactureDate;
                }
                else if (item.ItemType == "jacket")
                {
                    var jacket = (Jacket)item.Specifications;
                    brand = jacket.Brand;
                    size = jacket.Size;
                    manufacture = jacket.ManufactureDate;
                }
                else if (item.ItemType == "mask")
                {
                    var mask = (Mask)item.Specifications;
                    brand = mask.Brand;
                    size = mask.Size;
                    manufacture = mask.ManufactureDate;
                }
                else if (item.ItemType == "pants")
                {
                    var pants = (Pants)item.Specifications;
                    brand = pants.Brand;
                    size = pants.Size;
                    manufacture = pants.ManufactureDate;
                }

                dataGridViewClient.Rows.Add(
                    item.ItemType, item.DueDate, brand, item.SerialNumber, size, manufacture, item.Id);
            }
        }

        private void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            dataGridInv.Rows.Clear();
            var items = HelperDatabaseCall.ItemFindBySearchBar(connection, textBoxSearchBar.Text);
            if(items == null ) { return; }

            int i = 1;
            foreach(var item in items )
            {
                string brand = "";
                string size = "";
                string manufacture = "";
                string material = "";
                if (item.ItemType == "boots")
                {
                    var boots = (Boots)item.Specifications;
                    brand = boots.Brand;
                    size = boots.Size;
                    manufacture = boots.ManufactureDate;
                    material = boots.Material;
                }
                else if (item.ItemType == "helmet")
                {
                    var helmet = (Helmet)item.Specifications;
                    brand = helmet.Brand;
                    manufacture = helmet.ManufactureDate;
                }
                else if (item.ItemType == "jacket")
                {
                    var jacket = (Jacket)item.Specifications;
                    brand = jacket.Brand;
                    size = jacket.Size;
                    manufacture = jacket.ManufactureDate;
                }
                else if (item.ItemType == "mask")
                {
                    var mask = (Mask)item.Specifications;
                    brand = mask.Brand;
                    size = mask.Size;
                    manufacture = mask.ManufactureDate;
                }
                else if (item.ItemType == "pants")
                {
                    var pants = (Pants)item.Specifications;
                    brand = pants.Brand;
                    size = pants.Size;
                    manufacture = pants.ManufactureDate;
                }

                dataGridInv.Rows.Add(i++,
                    brand, item.SerialNumber, size, manufacture, item.Condition, material, item.Id
                );
            }
        }

        public void LoadProfile(bool isDepartment, string clientId)
        {
            var client = HelperDatabaseCall.ClientFindById(connection, Guid.Parse(clientId));
            if(client == null) 
            {
                Console.WriteLine("Client not found.");
                return; 
            }

            if (!isDepartment)
            {
                labelProfileName.Text = client["Name"];
                labelClientPhone.Text = client["Phone"];
                labelClientEmail.Text = client["Email"];
                lableRentalInfo.Text = client["Academy"];
                labelClientDrivers.Text = client["DriversLicenseNumber"];
                labelClientAddress.Text = client["Address"];
                labelClientChest.Text = client["Chest"];
                labelClientSleeve.Text = client["Sleeve"];
                labelClientWaist.Text = client["Waist"];
                labelClientInseam.Text = client["Inseam"];
                labelClientHips.Text = client["Hips"];
                labelClientHeight.Text = client["Height"];
                labelClientWeight.Text = client["Weight"];
                textBoxNotes.Text = client["Notes"];
                ClientId = Guid.Parse(client["Id"]);
                ClassId = Guid.Parse(client["IdClass"]);
                license = labelClientDrivers.Text;

                var dict = HelperDatabaseCall.ClassFindByClassId(connection, ClassId);
                if(dict != null)
                {
                    labelClientClass.Text = dict["Name"];
                }
            }
            else if (isDepartment)
            {
                labelProfileName.Text = client["Name"];
                labelClientPhone.Text = client["Phone"];
                labelClientEmail.Text = client["Email"];

                //point of contact
                labelProfileDrivers.Text = "Point of contact:";
                labelClientDrivers.Text = client["DriversLicenseNumber"];
                labelClientAddress.Text = client["Address"];
                textBoxNotes.Text = client["Notes"];
                ClientId = Guid.Parse(client["Id"]);

                flowLayoutPanelProfile.Visible = true;
                panelProfileRentalInfo.Visible = false;
                panelProfileMeasurments.Visible = false;
                license = labelProfileName.Text;
            }

            flowLayoutPanelProfile.Visible = true;
            flowLayoutPanelProfile.AutoScroll = false;
            splitContainerInventories.Visible = true;
            panelRentals.Visible = true;

            LoadClient();
            panelButtons.Dock = DockStyle.Top;
            flowLayoutPanelProfile.Dock = DockStyle.Bottom;
        }

        public void UpdateProfile(bool isDepartment, String ClientDrivers)
        {
            ExistingUser = true;
            if (isDepartment)
            {
                flowLayoutPanelProfile.Visible = true;
                panelProfileRentalInfo.Visible = false;
                panelProfileMeasurments.Visible = false;
                license = labelProfileName.Text;
            }
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
            if (ReturnReplace == 1)
            {
                Guid itemId = (Guid)row.Cells["ItemId"].Value;
                bool isUpdated = HelperDatabaseCall.ItemUpdate(connection, itemId, "Fire-Tec");
                if(isUpdated)
                {
                    HelperDatabaseCall.HistoryUpdate(connection, itemId, ClientId);
                    MessageBox.Show("Item Returned");
                }
                else { MessageBox.Show("Failed to return the item."); }
                LoadClient();
                LoadInventory();
            }

            else if (ReturnReplace == 2)
            {
                //lock the item type that is shown when a replacment is being done to match the item type of the item being replaced
                string itemType = row.Cells["Item"].Value.ToString().ToLower();
                SetItemType(itemType);

                dataGridViewClient.Enabled = false;

                dueDate = row.Cells["DDate"].Value.ToString();
                string SelectedSerial = row.Cells["SerialNum"].Value.ToString();
                ItemIdClient = (Guid)row.Cells["ItemId"].Value;
                labelOldItem.Text = SelectedSerial;
                labelTypeOfItem.Text = row.Cells["Item"].Value.ToString();

            }
        }

        private void SetItemType(string itemType)
        {
            if (itemType == "helmet")
            {
                comboBoxItemType.SelectedIndex = 0;
            }
            if (itemType == "jacket")
            {
                comboBoxItemType.SelectedIndex = 1;
            }
            if (itemType == "pants")
            {
                comboBoxItemType.SelectedIndex = 2;
            }
            if (itemType == "boots")
            {
                comboBoxItemType.SelectedIndex = 3;
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
                
                Guid itemId = (Guid)row.Cells["ItemIdInv"].Value;
                bool isUpdated = HelperDatabaseCall.ItemUpdate(connection, itemId, ClientId.ToString(), DatepickerDue.Value.ToString());
                if(!isUpdated) 
                {
                    MessageBox.Show("Failed to update item.");
                    return; 
                }
                isUpdated = HelperDatabaseCall.HistoryInsert(connection, itemId, ClientId);
                MessageBox.Show("Rental has been successfully completed");
                LoadClient();
                LoadInventory();
                
            }
            else if (ReturnReplace == 2)
            {
                ReplacmentSerial = row.Cells["Serial"].Value.ToString();
                labelReplacmentItem.Text = ReplacmentSerial;
                ItemIdInventory = (Guid)row.Cells["ItemIdInv"].Value;

                HelperDatabaseCall.ItemUpdate(connection, ItemIdClient, "Fire-Tec");
                HelperDatabaseCall.HistoryUpdate(connection, ItemIdClient, ClientId);
                HelperDatabaseCall.ItemUpdate(connection, ItemIdInventory, ClientId.ToString(), dueDate);
                HelperDatabaseCall.HistoryInsert(connection, ItemIdInventory, ClientId);

                LoadClient();
                LoadInventory();
                ReturnReplace = 0;
                comboBoxItemType.Enabled = true;
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
            HelperDatabaseCall.ItemTypeLoadComboBox(connection, comboBoxItemType);
            HelperFunctions.OpenChildFormToPanel(panel2, clientForm);
        }
    }
}
