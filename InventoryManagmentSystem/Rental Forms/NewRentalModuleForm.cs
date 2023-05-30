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

namespace InventoryManagmentSystem
{
    public partial class NewRentalModuleForm : Form
    {
        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;

        //Used for counting rentals
        int total = 0;

        #endregion SQL_Variables

        public bool ExistingUser = false;
        public string currentUser = "";
        string license = "";
        string DayNight = "";
        bool academy = true;

        public NewRentalModuleForm()
        {
            InitializeComponent();
            panelAddress.Visible = false;
            panelContactInfo.Visible = false;
            panelMeasurments.Visible = false;
            panelRentalInfo.Visible = false;

        }

        private bool CheckIfExists(string tableName, string SerialNumber)
        {
            try
            {
                bool Exists = false;
                cm = new SqlCommand($"Select Count (*) FROM {tableName} WHERE DriversLicenseNumber = @SerialNumber", con);
                cm.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                con.Open();
                object result = cm.ExecuteScalar();
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
                con.Close();
                return Exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR NewRentalModuleForm.cs --> CheckIfExists(): {ex.Message}");
                con.Close();
                // If there was an error, pretend you found something just so you don't add it.
                return true;
            }
        }

        public void Clear()
        {
            txtBoxCustomerName.Clear();
            txtBoxPhone.Clear();
            txtBoxEmail.Clear();
            txtBoxStreet.Clear();
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
            if (!isDepartment)
            {
                try
                {

                    cm = new SqlCommand("SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address," +
                        "Chest,Sleeve,Waist,Inseam,Hips,Height,Weight " +
                        "FROM tbClients WHERE DriversLicenseNumber = @DriversLicenseNumber", con);
                    cm.Parameters.AddWithValue("@DriversLicenseNumber", ClientDrivers);
                    con.Open();
                    dr = cm.ExecuteReader();
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
                    }
                    dr.Close();
                    con.Close();
                    flowLayoutPanelProfile.Visible = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (isDepartment)
            {
                try
                {

                    cm = new SqlCommand("SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address," +
                           "Chest,Sleeve,Waist,Inseam,Hips,Height,Weight " +
                           "FROM tbClients WHERE DriversLicenseNumber = @DriversLicenseNumber", con);
                    cm.Parameters.AddWithValue("@DriversLicenseNumber", ClientDrivers);
                    con.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        labelProfileName.Text = dr[4].ToString();
                        labelClientPhone.Text = dr[1].ToString();
                        labelClientEmail.Text = dr[2].ToString();

                        //point of contact
                        labelProfileDrivers.Text = "Point of contact";
                        labelClientDrivers.Text = dr[0].ToString();
                        labelClientAddress.Text = dr[5].ToString();
                    }
                    dr.Close();
                    con.Close();
                    flowLayoutPanelProfile.Visible = true;
                    panelProfileRentalInfo.Visible = false;
                    panelProfileMeasurments.Visible = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private bool SaveClient()
        {
            try
            {
                    string address = txtBoxStreet.Text + " " + textBoxCity.Text + " " + textBoxState.Text + " " + textBoxZip.Text;
                    bool exists = CheckIfExists("tbClients", txtBoxDriversLicense.Text);
                    if (!exists)
                    {
                        cm = new SqlCommand("INSERT INTO tbClients(Name,Phone,Email,Academy,DayNight,DriversLicenseNumber,Address,Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,FireTecRepresentative)" +
                        "VALUES(@Name,@Phone,@Email,@Academy,@DayNight,@DriversLicenseNumber,@Address,@Chest,@Sleeve,@Waist,@Inseam,@Hips,@Height,@Weight,@FireTecRepresentative)", con);
                        cm.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                        cm.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                        cm.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                        cm.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                        cm.Parameters.AddWithValue("@DayNight", comboBoxRentalType.Text);
                        cm.Parameters.AddWithValue("@Address", address);
                        cm.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                        cm.Parameters.AddWithValue("@Academy", txtBoxDriversLicense.Text);
                        cm.Parameters.AddWithValue("@Chest", textBoxChest.Text);
                        cm.Parameters.AddWithValue("@Sleeve", textBoxSleeve.Text);
                        cm.Parameters.AddWithValue("@Waist", textBoxWaist.Text);
                        cm.Parameters.AddWithValue("@Inseam", textBoxInseam.Text);
                        cm.Parameters.AddWithValue("@Hips", textBoxHips.Text);
                        cm.Parameters.AddWithValue("@Height", textBoxHeight.Text);
                        cm.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Info has been successfully saved");
                        Clear();

                        //hiding input panels
                        panelAddress.Visible = false;
                        panelContactInfo.Visible = false;
                        panelMeasurments.Visible = false;
                        panelRentalInfo.Visible = false;
                        panelFinalize.Visible = false;

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
            return false;
        }

        public void DisableLicense()
        {
            txtBoxDriversLicense.Enabled = false;
            txtBoxDriversLicense.BackColor = SystemColors.Control;
        }

        public void UpdateClient()
        {
            try
            {
                if (MessageBox.Show(
                    "Are you sure you want to update this Client?",
                    "Update Client",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand(
                        "UPDATE tbClients " +
                        "SET Name = @Name,Phone = @Phone,Email = " +
                        "@Email,Academy = @Academy,DayNight = " +
                        "@DayNight,DriversLicenseNumber = @DriversLicenseNumber," +
                        "Address = @Address,FireTecRepresentative = @FireTecRepresentative " +
                        "WHERE DriversLicenseNumber LIKE @DriversLicenseNumber", con);

                    cm.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                    cm.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                    cm.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                    cm.Parameters.AddWithValue("@Academy", comboBoxAcademy.Text);
                    cm.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                    cm.Parameters.AddWithValue("@Address", txtBoxStreet.Text);
                    cm.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Client has been successfully updated");
                    this.Dispose();
                    ExistingUser = false;
                    SetSelectionModuleForm ModForm = new SetSelectionModuleForm(currentUser, license, DayNight);
                    this.Dispose();
                    ModForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxStreet.Text) &&
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
                !string.IsNullOrEmpty(comboBoxAcademy.Text))
            {
                currentUser = txtBoxCustomerName.Text;
                license = txtBoxDriversLicense.Text;
                if (ExistingUser == false)
                {
                   
                    panelRentalType.Visible = false;
                    if (SaveClient())
                    {
                        //individual
                        if (comboBoxRentalType.SelectedIndex == 0)
                        {
                            LoadProfile(false, license);
                        }
                        //department
                        else if (comboBoxRentalType.SelectedIndex == 1)
                        {
                            LoadProfile(true, license);
                        }
                    }
                }
                else
                {
                    UpdateClient();
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

        private void comboBoxRentalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nothing seleced
            if (comboBoxRentalType.SelectedIndex == -1)
            {
                panelAddress.Visible = false;
                panelContactInfo.Visible = false;
                panelMeasurments.Visible = false;
                panelRentalInfo.Visible = false;
            }
            //Individual
            else if (comboBoxRentalType.SelectedIndex == 0)
            {
                //Change fields
                LableCustomerName.Text = "Customer Name";
                labelDriversLicense.Text = "Drivers Licence #";

                //show panels
                panelAddress.Visible = true;
                panelContactInfo.Visible = true;
                panelMeasurments.Visible = true;
                panelRentalInfo.Visible = true;
                panelAcademy.Visible = true;

                //default values
                textBoxChest.Text = "";
                textBoxSleeve.Text = "";
                textBoxInseam.Text = "";
                textBoxHips.Text = "";
                textBoxWaist.Text = "";
                textBoxWeight.Text = "";
                textBoxHeight.Text = "";
                comboBoxAcademy.SelectedIndex = -1;

            }
            //department
            else if (comboBoxRentalType.SelectedIndex == 1)
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
                comboBoxAcademy.Text = "N/A";


                //show pannels
                panelAddress.Visible = true;
                panelContactInfo.Visible = true;
                panelRentalInfo.Visible = true;

            }
            //academy
            else if (comboBoxRentalType.SelectedIndex == 2)
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
                panelAddress.Visible = true;
                panelRentalInfo.Visible = true;
                panelContactInfo.Visible = true;
            }
        }
    }
}
