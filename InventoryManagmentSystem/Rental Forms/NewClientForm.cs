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

namespace InventoryManagmentSystem.Rental_Forms
{
    public partial class NewClientForm : Form
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

        //NewRentalModuleForm parentForm;
        public NewClientForm()
        {
            InitializeComponent();

             
        }

        private void comboBoxRentalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RentalTypeSelector(comboBoxRentalType.Text);
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

                Point point = new Point(panelAddress.Location.X, panelAddress.Location.Y + panelAddress.Size.Height);
                panelRentalInfo.Location = point;

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

                Point point = new Point(panelAddress.Location.X, panelAddress.Location.Y + panelAddress.Size.Height);
                panelRentalInfo.Location = point;
            }
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

        private void ButtonContinue_Click_1(object sender, EventArgs e)
        {
            NewRentalModuleForm DockedIn = this.Parent.Parent as NewRentalModuleForm;
            if (IsBoxEmpty())
            {

                DockedIn.currentUser = txtBoxCustomerName.Text;
                DockedIn.license = txtBoxDriversLicense.Text;
                panelRentalType.Visible = false;

                if (DockedIn.ExistingUser == false)
                {
                    if (SaveClient())
                    {
                        //individual
                        if (comboBoxRentalType.SelectedIndex == 0)
                        {
                            DockedIn.LoadProfile(false, DockedIn.license);
                        }
                        //department
                        else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                        {
                            DockedIn.LoadProfile(true, DockedIn.license);
                        }
                    }
                }
                else
                {
                    //individual
                    if (comboBoxRentalType.SelectedIndex == 0)
                    {
                        UpdateClient();
                        DockedIn.LoadProfile(false, DockedIn.license);
                    }
                    //department
                    else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                    {
                        UpdateClient();
                        DockedIn.LoadProfile(true, DockedIn.license);
                    }
                    panelContactInfo.Visible = false;
                    panelAddress.Visible = false;
                    panelMeasurments.Visible = false;
                    panelRentalInfo.Visible = false;
                    DockedIn.ExistingUser = false;
                }
            }
            else
            {
                MessageBox.Show("Please fill the required fields");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
