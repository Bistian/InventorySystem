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
        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection connection = new SqlConnection(connectionString);
        //Creating command
        SqlCommand command = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;

        //Used for query
        Guid ItemIdClient = Guid.Empty;
        Guid ItemIdInventory = Guid.Empty;

        //Used for counting rentals
        int total = 0;

        #endregion SQL_Variables

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
                HelperFunctions.LoadItemTypes(connection, ref comboBoxItemType);
                HelperFunctions.openChildFormToPanel(panel2, clientForm);
            }
        }

        private string QueryClient()
        {
            //return ("SELECT Type, DueDate, SerialNumber FROM tbBoots WHERE Location='Client1'");
            return ("SELECT 'Pants', DueDate,Brand,SerialNumber,Size,ManufactureDate,ItemId FROM tbPants " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT 'Boots',DueDate,Brand,SerialNumber,Size,ManufactureDate,ItemId FROM tbBoots " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT 'Helmet',DueDate,Brand,SerialNumber,'NA',ManufactureDate,ItemId FROM tbHelmets " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT 'Jacket',DueDate,Brand,SerialNumber,Size,ManufactureDate,ItemId FROM tbJackets " +
                "WHERE Location='" + license + "' " +
                 "UNION SELECT 'Mask',DueDate,Brand,SerialNumber,Size,ManufactureDate,ItemId FROM tbMasks " +
                "WHERE Location='" + license + "' " +
                "ORDER BY DueDate");
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["DDate"].DefaultCellStyle.Format = "d";
            dataGridViewClient.Columns["ClientMFD"].DefaultCellStyle.Format = "d";

            dataGridViewClient.Rows.Clear();
            command = new SqlCommand(QueryClient(), connection);
            connection.Open();
            try
            {
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    dataGridViewClient.Rows.Add(
                        dr[0].ToString(),
                        dr[1],
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5],
                        dr[6]
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            dr.Close();
            connection.Close();
        }

        /// <summary>
        /// Load item types on combo box to select type.
        /// </summary>

        private string QueryItems()
        {
            string CurrTable = "";
            string FinalColumn = "";
            string Sizes = "";

            if (comboBoxItemType.Text == "helmet")
            {
                FinalColumn = ", Color";
                CurrTable = "tbHelmets";
            }
            else if (comboBoxItemType.Text == "jacket")
            {
                Sizes = " Size,";
                CurrTable = "tbJackets";
            }
            else if (comboBoxItemType.Text == "pants")
            {
                Sizes = " Size,";
                CurrTable = "tbPants";
            }
            else if (comboBoxItemType.Text == "boots")
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
                CurrTable = "tbBoots";
            }
            else if (comboBoxItemType.Text == "mask")
            {
                Sizes = " Size,";
                CurrTable = "tbMasks";
            }

            if(CurrTable == "") 
            {
                Console.Error.WriteLine("ERROR: No table was set for query.");
                return ""; 
            }

            string searchTerm = textBoxSearchBar.Text;
            string query = $@"
                    SELECT ItemId,Brand,SerialNumber,{Sizes} ManufactureDate,Condition {FinalColumn}
                    FROM {CurrTable}
                    WHERE Location='Fire-Tec' AND 
                        SerialNumber LIKE '%{searchTerm}%' AND
                        Condition != 'Retired'
                ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            return query;
        }

        private void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            int i = 0;
            dataGridInv.Rows.Clear();
            command = new SqlCommand(QueryItems(), connection);
            connection.Open();

            try
            {
                dr = command.ExecuteReader();

                if (comboBoxItemType.SelectedIndex == 0)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[0]);
                    }
                }
                else if (comboBoxItemType.SelectedIndex == 1 || comboBoxItemType.SelectedIndex == 2 || comboBoxItemType.SelectedIndex == 4)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), "N/A", dr[0]);
                    }
                }
                else if (comboBoxItemType.SelectedIndex == 3)
                {
                    while (dr.Read())
                    {
                        i++;
                        dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], dr[6], dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            dr.Close();
            connection.Close();
        }

        private void GetClassName()
        {
            string query = $@"
                    SELECT Name FROM tbClasses WHERE Id = '{ClassId}'
                    ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    labelClientClass.Text = dr[0].ToString();
                }
                dr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                dr.Close();
                connection.Close();
            }
        }

        public void LoadProfile(bool isDepartment, String ClientDrivers)
        {
            if (!isDepartment)
            {
                string query = @"
                    SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address,
                    Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,Notes,Id,IdClass
                    FROM tbClients WHERE DriversLicenseNumber = @DriversLicenseNumber
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
                try
                {
                    drivers = ClientDrivers;
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DriversLicenseNumber", ClientDrivers);
                    connection.Open();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        labelProfileName.Text = dr[0].ToString();
                        labelClientPhone.Text = dr[1].ToString();
                        labelClientEmail.Text = dr[2].ToString();
                        lableRentalInfo.Text = dr[3].ToString();
                        labelClientDrivers.Text = dr[4].ToString();
                        labelClientAddress.Text = dr[5].ToString();
                        labelClientChest.Text = dr[6].ToString();
                        labelClientSleeve.Text = dr[7].ToString();
                        labelClientWaist.Text = dr[8].ToString();
                        labelClientInseam.Text = dr[9].ToString();
                        labelClientHips.Text = dr[10].ToString();
                        labelClientHeight.Text = dr[11].ToString();
                        labelClientWeight.Text = dr[12].ToString();
                        textBoxNotes.Text = dr[13].ToString();
                        ClientId = (Guid)dr[14];
                        ClassId = (Guid)dr[15];
                    }
                    dr.Close();
                    connection.Close();
                    license = labelClientDrivers.Text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    dr.Close();
                    connection.Close();
                }
                GetClassName();
            }
            else if (isDepartment)
            {
                try
                {

                    command = new SqlCommand("SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address," +
                           "Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,Notes,Id " +
                           "FROM tbClients WHERE DriversLicenseNumber = @DriversLicenseNumber", connection);
                    command.Parameters.AddWithValue("@DriversLicenseNumber", ClientDrivers);
                    connection.Open();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        labelProfileName.Text = dr[4].ToString();
                        labelClientPhone.Text = dr[1].ToString();
                        labelClientEmail.Text = dr[2].ToString();

                        //point of contact
                        labelProfileDrivers.Text = "Point of contact:";
                        labelClientDrivers.Text = dr[0].ToString();
                        labelClientAddress.Text = dr[5].ToString();
                        textBoxNotes.Text = dr[13].ToString();
                        ClientId = (Guid)dr[14];
                    }
                    dr.Close();
                    connection.Close();
                    flowLayoutPanelProfile.Visible = true;
                    panelProfileRentalInfo.Visible = false;
                    panelProfileMeasurments.Visible = false;
                    license = labelProfileName.Text;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    dr.Close();
                    connection.Close();
                }
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
                try
                {
                    flowLayoutPanelProfile.Visible = true;
                    panelProfileRentalInfo.Visible = false;
                    panelProfileMeasurments.Visible = false;
                    license = labelProfileName.Text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
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


            command = new SqlCommand("UPDATE tbClients SET Notes = @Notes " +
                   "WHERE DriversLicenseNumber = @DriversLicenseNumber", connection);
            command.Parameters.AddWithValue("@Notes", textBoxNotes.Text);
            command.Parameters.AddWithValue("@DriversLicenseNumber", license);

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            MessageBox.Show("Note has been successfully saved");
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; };

            ReturnOrReplacecs ModForm = new ReturnOrReplacecs(this);
            ModForm.ShowDialog();

            if (ReturnReplace == 1)
            {
                string SelectedSerial = "";
                // Helmet
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Helmet")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 0;
                        SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        command = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", SelectedSerial);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory((Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value, ClientId);
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                // Jacket
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Jacket")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 1;
                        SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        command = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", SelectedSerial);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory((Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value, ClientId);
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridClient_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                // Pants
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Pants")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 2;
                        SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        command = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", SelectedSerial);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory((Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value, ClientId);
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                //Boots
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Boots")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 3;
                        SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        command = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", SelectedSerial);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory((Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value, ClientId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        connection.Close();
                        return;
                    }
                    MessageBox.Show("Item Returned");
                }

                // Masks
                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Mask")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 1;
                        SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                        command = new SqlCommand("UPDATE tbMasks SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", SelectedSerial);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory((Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value, ClientId);
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }
                LoadClient();
                LoadInventory();
            }

            else if (ReturnReplace == 2)
            {
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Helmet")
                {
                    comboBoxItemType.SelectedIndex = 0;
                }
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Jacket")
                {
                    comboBoxItemType.SelectedIndex = 1;
                }
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Pants")
                {
                    comboBoxItemType.SelectedIndex = 2;
                }
                if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Boots")
                {
                    comboBoxItemType.SelectedIndex = 3;
                }
                dataGridViewClient.Enabled = false;

                dueDate = dataGridViewClient.Rows[e.RowIndex].Cells["DDate"].Value.ToString();
                String SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                ItemIdClient = (Guid)dataGridViewClient.Rows[e.RowIndex].Cells["ItemId"].Value;
                labelOldItem.Text = SelectedSerial;
                labelTypeOfItem.Text = dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString();

            }
        }

        private void UpdateBoots(DataGridViewRow row)
        {
            string SelectedSerial = row.Cells["Serial"].Value.ToString();
            command = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
            command.Parameters.AddWithValue("@location", license);
            command.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
            command.Parameters.AddWithValue("@serial", SelectedSerial);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdateHelmet(DataGridViewRow row)
        {
            if(comboBoxItemType.Text.ToLower() != "helmet") { return; }

            string SelectedSerial = row.Cells["Serial"].Value.ToString();
            command = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
            command.Parameters.AddWithValue("@location", license);
            command.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
            command.Parameters.AddWithValue("@serial", SelectedSerial);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();            
        }

        private void UpdateJacket(DataGridViewRow row)
        {
            if (comboBoxItemType.Text.ToLower() != "jacket") { return; }

            string SelectedSerial = row.Cells["Serial"].Value.ToString();
            command = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
            command.Parameters.AddWithValue("@location", license);
            command.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
            command.Parameters.AddWithValue("@serial", SelectedSerial);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdateMask(DataGridViewRow row)
        {
            if (comboBoxItemType.Text.ToLower() != "mask") { return; }

            string SelectedSerial = row.Cells["Serial"].Value.ToString();
            command = new SqlCommand("UPDATE tbMasks SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
            command.Parameters.AddWithValue("@location", license);
            command.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
            command.Parameters.AddWithValue("@serial", SelectedSerial);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdatePants(DataGridViewRow row)
        {
            if (comboBoxItemType.Text.ToLower() != "pants") { return; }

            string SelectedSerial = row.Cells["Serial"].Value.ToString();
            command = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
            command.Parameters.AddWithValue("@location", license);
            command.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
            command.Parameters.AddWithValue("@serial", SelectedSerial);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
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
                
                var value = row.Cells["ItemIdInv"].Value;
                if (value == null) { return; }

                try
                {
                    UpdateBoots(row);
                    UpdateHelmet(row);
                    UpdateJacket(row);
                    UpdateMask(row);
                    UpdatePants(row);
                    bool historyDone = InsertHistory((Guid)value, ClientId);
                    if (!historyDone)
                    {
                        Console.Error.WriteLine("History failed.");
                    }
                    MessageBox.Show("Rental has been successfully completed");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connection.Close();
                    return;
                }
                
                LoadClient();
                LoadInventory();
                
            }
            else if (ReturnReplace == 2)
            {
                ReplacmentSerial = row.Cells["Serial"].Value.ToString();
                labelReplacmentItem.Text = ReplacmentSerial;
                ItemIdInventory = (Guid)row.Cells["ItemIdInv"].Value;


                // Helmet
                if (labelTypeOfItem.Text == "Helmet")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 0;
                        //return item
                        command = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", labelOldItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory(ItemIdClient, ClientId);

                        //replace item
                        command = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", license);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        InsertHistory(ItemIdInventory, ClientId);

                        MessageBox.Show("Item Replaced");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                // Jacket
                else if (labelTypeOfItem.Text == "Jacket")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 1;

                        //return item
                        command = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", labelOldItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory(ItemIdClient, ClientId);

                        //replace item
                        command = new SqlCommand("UPDATE tbJackets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", license);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        InsertHistory(ItemIdInventory, ClientId);

                        MessageBox.Show("Item Replaced");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                // Pants
                else if (labelTypeOfItem.Text == "Pants")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 2;

                        //return item
                        command = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", labelOldItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory(ItemIdClient, ClientId);

                        //replace item
                        command = new SqlCommand("UPDATE tbPants SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", license);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        InsertHistory(ItemIdInventory, ClientId);
                        MessageBox.Show("Item Replaced");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                else if (labelTypeOfItem.Text == "Boots")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 3;

                        //return item
                        command = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", labelOldItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory(ItemIdClient, ClientId);

                        //replace item
                        command = new SqlCommand("UPDATE tbBoots SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", license);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        InsertHistory(ItemIdInventory, ClientId);
                        MessageBox.Show("Item Replaced");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }

                // Maks
                else if (labelTypeOfItem.Text == "Mask")
                {
                    try
                    {
                        comboBoxItemType.SelectedIndex = 2;

                        //return item
                        command = new SqlCommand("UPDATE tbMasks SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", "Fire-Tec");
                        command.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        command.Parameters.AddWithValue("@serial", labelOldItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateHistory(ItemIdClient, ClientId);

                        //replace item
                        command = new SqlCommand("UPDATE tbMasks SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", connection);
                        command.Parameters.AddWithValue("@location", license);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        InsertHistory(ItemIdInventory, ClientId);
                        MessageBox.Show("Item Replaced");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        connection.Close();
                        return;
                    }
                }
                LoadClient();
                LoadInventory();
                ReturnReplace = 0;
                dataGridViewClient.Enabled = true;

            }
        }

        private bool InsertHistory(Guid ItemId, Guid ClientId)
        {
            string query = HelperQuery.HistoryInsert();
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@ItemId", ItemId);
                command.Parameters.AddWithValue("@ClientId", ClientId);

                command.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.Write(ex.Message);
                return false;
            }
        }

        private bool UpdateHistory(Guid ItemId, Guid ClientId)
        {
            string query = HelperQuery.HistoryUpdate();
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@ItemId", ItemId);
                command.Parameters.AddWithValue("@ClientId", ClientId);

                command.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.Write(ex.Message);
                return false;
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
            HelperFunctions.openChildFormToPanel(panel2, AssignForm);
        }

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
