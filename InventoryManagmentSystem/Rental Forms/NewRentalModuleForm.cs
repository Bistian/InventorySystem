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
        bool Measure = true;

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


        public NewRentalModuleForm(string rentalType = null, string clientName = null)
        {
            InitializeComponent();

     
            NewClientForm clientForm = new NewClientForm();
           
            HelperFunctions.openChildFormToPanel(panel2, clientForm);

            if (clientName != null)
            {
                labelProfileName.Text = clientName;
            }
            panelRentalInfo.Visible = false;
            panelMeasurments.Visible = false;
            panelAddress.Visible = false;
            panelContactInfo.Visible = false;
            PopulateAcademyList();
            if (clientName != null)
            {
                comboBoxRentalType.Text = rentalType;
                AutoFillFields(rentalType, clientName);

            }

            HelperFunctions.LoadItemTypes(connection, ref comboBoxItemType);
        }

        private bool CheckIfExists(string tableName, string SerialNumber)
        {
            try
            {
                bool Exists = false;
                command = new SqlCommand($"Select Count (*) FROM {tableName} WHERE DriversLicenseNumber = @SerialNumber", connection);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int r = (int)result;
                    Exists = r > 0 ? true : false;
                }
                else
                {
                    // Null is an error!! don't add plz
                    Exists = true;
                }
                connection.Close();
                return Exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR NewRentalModuleForm.cs --> CheckIfExists(): {ex.Message}");
                connection.Close();
                // If there was an error, pretend you found something just so you don't add it.
                return true;
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

        public void Clear()
        {
            txtBoxCustomerName.Clear();
            txtBoxPhone.Clear();
            txtBoxEmail.Clear();
            txtBoxStreet.Clear();
            txtBoxDriversLicense.Clear();
            textBoxChest.Clear();
            textBoxCity.Clear();
            textBoxHeight.Clear();
            textBoxHips.Clear();
            textBoxInseam.Clear();
            textBoxSleeve.Clear();
            textBoxState.Clear();
            textBoxWaist.Clear();
            textBoxWeight.Clear();
            textBoxZip.Clear();
            txtBoxRep.SelectedIndex = -1;
            comboBoxAcademy.SelectedIndex = -1;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void LoadProfile(bool isDepartment, String ClientDrivers)
        {
            panelRentalType.Visible = false;
            if (!isDepartment)
            {
                string query = @"
                    SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address,
                    Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,Notes,Id 
                    FROM tbClients WHERE DriversLicenseNumber = @DriversLicenseNumber
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
                try
                {
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DriversLicenseNumber", ClientDrivers);
                    connection.Open();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        labelProfileName.Text = dr[0].ToString();
                        labelClientPhone.Text = dr[1].ToString();
                        labelClientEmail.Text = dr[2].ToString();
                        labelClientAcademy.Text = dr[3].ToString();
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
            flowLayoutPanelProfile.Dock = DockStyle.Top;
        }

        public void UpdateProfile(bool isDepartment, String ClientDrivers)
        {
            txtBoxDriversLicense.Enabled = false;
            panelRentalType.Visible = false;
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

        private bool SaveClient()
        {
            try
            {
                string address = txtBoxStreet.Text + " " + textBoxCity.Text + " " + textBoxState.Text + " " + textBoxZip.Text;
                bool exists = CheckIfExists("tbClients", txtBoxDriversLicense.Text);
                if (!exists)
                {
                    command = new SqlCommand("INSERT INTO tbClients(Name,Phone,Email,Academy,Type,DriversLicenseNumber,Address,Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,FireTecRepresentative)" +
                    "VALUES(@Name,@Phone,@Email,@Academy,@Type,@DriversLicenseNumber,@Address,@Chest,@Sleeve,@Waist,@Inseam,@Hips,@Height,@Weight,@FireTecRepresentative)", connection);
                    command.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                    command.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                    command.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                    command.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                    command.Parameters.AddWithValue("@Type", comboBoxRentalType.Text);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                    if (comboBoxRentalType.SelectedIndex == 0)
                    {
                        command.Parameters.AddWithValue("@Academy", comboBoxAcademy.Text);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Academy", txtBoxDriversLicense.Text);
                    }
                        command.Parameters.AddWithValue("@Chest", textBoxChest.Text);
                        command.Parameters.AddWithValue("@Sleeve", textBoxSleeve.Text);
                        command.Parameters.AddWithValue("@Waist", textBoxWaist.Text);
                        command.Parameters.AddWithValue("@Inseam", textBoxInseam.Text);
                        command.Parameters.AddWithValue("@Hips", textBoxHips.Text);
                        command.Parameters.AddWithValue("@Height", textBoxHeight.Text);
                        command.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
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
                    MessageBox.Show("Info has been successfully saved");
                    Clear();

                    //hiding input panels
                    panelFinalize.Visible = false;
                    panelRentalInfo.Visible = false;
                    panelMeasurments.Visible = false;
                    panelAddress.Visible = false;
                    panelContactInfo.Visible = false;

                    return true;
                }
                else
                {
                    MessageBox.Show("License Number already in use");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void DisableLicense()
        {
            txtBoxDriversLicense.Enabled = false;
            txtBoxDriversLicense.BackColor = SystemColors.Control;
        }

        public void AutoFillFields(string type, string clientName)
        {
            RentalTypeSelector(type);

            string query = "SELECT * FROM tbClients WHERE Name = '" + clientName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    txtBoxCustomerName.Text = dataReader[1].ToString();
                    txtBoxPhone.Text = dataReader[2].ToString();
                    txtBoxEmail.Text = dataReader[3].ToString();
                    comboBoxAcademy.Text = dataReader[4].ToString();
                    txtBoxDriversLicense.Text = dataReader[6].ToString();
                    txtBoxStreet.Text = dataReader[7].ToString();
                    textBoxChest.Text = dataReader[8].ToString();
                    textBoxSleeve.Text = dataReader[9].ToString();
                    textBoxWaist.Text = dataReader[10].ToString();
                    textBoxInseam.Text = dataReader[11].ToString();
                    textBoxHips.Text = dataReader[12].ToString();
                    textBoxHeight.Text = dataReader[13].ToString();
                    textBoxWeight.Text = dataReader[14].ToString();
                    textBoxNotes.Text = dataReader[15].ToString();
                    txtBoxRep.Text = dataReader[16].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        public void UpdateClient()
        {
            string message = "Are you sure you want to update this Client?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return; }

            string query = "UPDATE tbClients " +
                    "SET Name = @Name,Phone = @Phone,Email = " +
                    "@Email,Academy = @Academy,DriversLicenseNumber = @DriversLicenseNumber," +
                    "Address = @Address,FireTecRepresentative = @FireTecRepresentative, " +
                    "Chest=@Chest, Sleeve=@Sleeve, Waist=@Waist, Inseam=@Inseam, Hips=@Hips, Weight=@Weight, Height=@Height " +
                    "WHERE DriversLicenseNumber LIKE @DriversLicenseNumber";

            string address = txtBoxStreet.Text + " " + textBoxCity.Text + " " + textBoxState.Text + " " + textBoxZip.Text;
            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();
                command.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                command.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                command.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                if (comboBoxRentalType.SelectedIndex == 0)
                {
                    command.Parameters.AddWithValue("@Academy", comboBoxAcademy.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@Academy", txtBoxDriversLicense.Text);
                }
                command.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                command.Parameters.AddWithValue("@Chest", textBoxChest.Text);
                command.Parameters.AddWithValue("@Sleeve", textBoxSleeve.Text);
                command.Parameters.AddWithValue("@Waist", textBoxWaist.Text);
                command.Parameters.AddWithValue("@Inseam", textBoxInseam.Text);
                command.Parameters.AddWithValue("@Hips", textBoxHips.Text);
                command.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
                command.Parameters.AddWithValue("@Height", textBoxHeight.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Client has been successfully updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void PopulateAcademyList()
        {
            string query = "SELECT * FROM tbBrands WHERE ItemType = 'Academies'";
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxAcademy.Items.Add(dr[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private int ClientExists(string driversLicense)
        {
            string query = "SELECT COUNT(*) FROM tbClients WHERE DriversLicenseNumber = @license";
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                command.Parameters.AddWithValue("@license", driversLicense);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0) { return 1; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            connection.Close();
            return 0;
        }

        private bool IsBoxEmpty()
        {
            return (!string.IsNullOrEmpty(txtBoxStreet.Text) &&
                !string.IsNullOrEmpty(textBoxState.Text) &&
                !string.IsNullOrEmpty(textBoxZip.Text) &&
                !string.IsNullOrEmpty(txtBoxCustomerName.Text) &&
                !string.IsNullOrEmpty(txtBoxDriversLicense.Text) &&
                !string.IsNullOrEmpty(txtBoxEmail.Text) &&
                !string.IsNullOrEmpty(txtBoxPhone.Text) &&
                !string.IsNullOrEmpty(txtBoxRep.Text) &&
                !string.IsNullOrEmpty(comboBoxAcademy.Text) &&
                !string.IsNullOrEmpty(textBoxCity.Text) &&
                !string.IsNullOrEmpty(textBoxChest.Text) &&
                !string.IsNullOrEmpty(textBoxSleeve.Text) &&
                !string.IsNullOrEmpty(textBoxWaist.Text) &&
                !string.IsNullOrEmpty(textBoxInseam.Text) &&
                !string.IsNullOrEmpty(textBoxHips.Text) &&
                !string.IsNullOrEmpty(textBoxHeight.Text) &&
                !string.IsNullOrEmpty(textBoxWeight.Text) &&
                !string.IsNullOrEmpty(comboBoxAcademy.Text));
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            if (IsBoxEmpty())
            {
                currentUser = txtBoxCustomerName.Text;
                license = txtBoxDriversLicense.Text;
                panelRentalType.Visible = false;
                if (ExistingUser == false)
                {
                    if (SaveClient())
                    {
                        //individual
                        if (comboBoxRentalType.SelectedIndex == 0)
                        {
                            LoadProfile(false, license);
                        }
                        //department
                        else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                        {
                            LoadProfile(true, license);
                        }
                    }
                }
                else
                {
                    //individual
                    if (comboBoxRentalType.SelectedIndex == 0)
                    {
                        UpdateClient();
                        LoadProfile(false, license);
                    }
                    //department
                    else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                    {
                        UpdateClient();
                        LoadProfile(true, license);
                    }
                    panelContactInfo.Visible = false;
                    panelAddress.Visible = false;
                    panelMeasurments.Visible = false;
                    panelRentalInfo.Visible = false;
                    ExistingUser = false;
                }
            }
            else
            {
                MessageBox.Show("Please fill the required fields");
            }
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGender.SelectedIndex == 0)
            {
                textBoxHips.Text = "N/A";
                panelHips.Visible = false;
            }
            else
            {
                textBoxHips.Text = "";
                panelHips.Visible = true;
            }
        }

        private void RentalTypeSelector(string type)
        {
            //nothing seleced
            if (type == "")
            {
                panelContactInfo.Visible = false;
                panelAddress.Visible = false;
                panelMeasurments.Visible = false;
                panelRentalInfo.Visible = false;
            }
            //Individual
            else if (type == "Individuals")
            {
                //Change fields
                LableCustomerName.Text = "Customer Name";
                labelDriversLicense.Text = "Drivers Licence #";

                //show panels
                panelContactInfo.Visible = true;
                panelAddress.Visible = true;
                panelMeasurments.Visible = true;
                panelAcademy.Visible = true;
                panelRentalInfo.Visible = true;

                //default values
                textBoxChest.Text = "";
                textBoxSleeve.Text = "";
                textBoxInseam.Text = "";
                textBoxHips.Text = "";
                textBoxWaist.Text = "";
                textBoxWeight.Text = "";
                textBoxHeight.Text = "";
                comboBoxAcademy.SelectedIndex = -1;

                panelRentalInfo.Dock = DockStyle.Bottom;

            }
            //Department
            else if (type == "Departments")
            {
                //change fields
                panelMeasurments.Visible = false;
                panelAcademy.Visible = false;
                labelRentalInfo.Visible = false;
                LableCustomerName.Text = "Point Of Contact";
                labelDriversLicense.Text = "Department Name";

                //default values
                textBoxChest.Text = "N/A";
                textBoxSleeve.Text = "N/A";
                textBoxInseam.Text = "N/A";
                textBoxHips.Text = "N/A";
                textBoxWaist.Text = "N/A";
                textBoxWeight.Text = "N/A";
                textBoxHeight.Text = "N/A";
                comboBoxAcademy.SelectedIndex = 0;

                //show pannels
                panelRentalInfo.Visible = true;

                panelAddress.Visible = true;

                panelContactInfo.Visible = true;

                panelRentalInfo.Dock = DockStyle.Top;

            }
            //Academy
            else if (type == "Academies")
            {
                //hide pannels
                panelMeasurments.Visible = false;
                panelAcademy.Visible = false;
                labelRentalInfo.Visible = false;
                LableCustomerName.Text = "Point Of Contact";
                labelDriversLicense.Text = "Academy Name";


                //default values
                textBoxChest.Text = "N/A";
                textBoxSleeve.Text = "N/A";
                textBoxInseam.Text = "N/A";
                textBoxHips.Text = "N/A";
                textBoxWaist.Text = "N/A";
                textBoxWeight.Text = "N/A";
                textBoxHeight.Text = "N/A";
                comboBoxAcademy.Text = "N/A";

                //show pannels
                panelRentalInfo.Visible = true;

                panelAddress.Visible = true;

                panelContactInfo.Visible = true;

                panelRentalInfo.Dock = DockStyle.Top;
            }
        }

        private void comboBoxRentalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RentalTypeSelector(comboBoxRentalType.Text);
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

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            BrandForm form = new BrandForm();
            form.cbItemType.SelectedIndex = 0;
            form.close = true;
            form.ShowDialog();
            LoadBrands();
            comboBoxAcademy.SelectedIndex = comboBoxAcademy.Items.Count - 1;
        }

        private void LoadBrands()
        {
            string query = "SELECT * FROM tbAcademies WHERE AcademyName='academies'";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxAcademy.Items.Add(dataReader[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
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

        private void checkBoxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            Measure = !Measure;
            if (Measure == false)
            {
                panel1.Visible = false;

                textBoxChest.Text = "N/A";
                panelChest.Visible = false;

                textBoxSleeve.Text = "N/A";
                panelSleeve.Visible = false;

                textBoxWaist.Text = "N/A";
                panelWaist.Visible = false;

                textBoxInseam.Text = "N/A";
                panelInseam.Visible = false;

                textBoxHips.Text = "N/A";
                panelHips.Visible = false;

                textBoxHeight.Text = "N/A";
                panelHeight.Visible = false;

                textBoxWeight.Text = "N/A";
                panel8.Visible = false;

            }
            else
            {
                panel1.Visible = true;

                textBoxChest.Text = "";
                panelChest.Visible = true;

                textBoxSleeve.Text = "";
                panelSleeve.Visible = true;

                textBoxWaist.Text = "";
                panelWaist.Visible = true;

                textBoxInseam.Text = "";
                panelInseam.Visible = true;

                textBoxHips.Text = "";
                panelHips.Visible = true;

                textBoxHeight.Text = "";
                panelHeight.Visible = true;

                textBoxWeight.Text = "";
                panel8.Visible = true;
            }
        }

        private void NewRentalModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
