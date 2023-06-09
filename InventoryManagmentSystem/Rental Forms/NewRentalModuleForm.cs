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

        //Used for query
        string CurrTable = "";
        string FinalColumn = "";
        string Sizes = "";

        //Used for counting rentals
        int total = 0;

        #endregion SQL_Variables

        public bool ExistingUser = false;
        public string currentUser = "";
        string license = "";
        string DayNight = "";
        public int ReturnReplace = 0;
        string ReplacmentSerial = "";
        String dueDate = "";


        public NewRentalModuleForm()
        {
            InitializeComponent();
            panelAddress.Visible = false;
            panelContactInfo.Visible = false;
            panelMeasurments.Visible = false;
            panelRentalInfo.Visible = false;
            splitContainermain.SplitterDistance = 650;
            PopulateAcademyList();
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

        private string QueryClient()
        {
            //return ("SELECT Type, DueDate, SerialNumber FROM tbBoots WHERE Location='Client1'");
            return ("SELECT ItemType, DueDate, SerialNumber FROM tbPants " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbBoots " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE Location='" + license + "' " +
                "UNION SELECT ItemType, DueDate, SerialNumber FROM tbJackets " +
                "WHERE Location='" + license + "' " +
                "ORDER BY DueDate");
        }

        private void LoadClient()
        {
            // Change the styling for the date column.
            dataGridViewClient.Columns["DueDate"].DefaultCellStyle.Format = "d";

            dataGridViewClient.Rows.Clear();
            cm = new SqlCommand(QueryClient(), con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                dataGridViewClient.Rows.Add(
                    dr[0].ToString(),
                    dr[1],
                    dr[2].ToString()
                );
            }

            dr.Close();
            con.Close();
        }

        private string QueryItems()
        {
            string searchTerm = textBoxSearchBar.Text;

            string firetec = "(Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC')";
            if (comboBoxItemType.SelectedIndex == 0)
            {
                FinalColumn = ", Color";
                Sizes = "";
                CurrTable = "tbHelmets";
            }
            else if (comboBoxItemType.SelectedIndex == 1)
            {
                FinalColumn = "";
                Sizes = " Size,";
                CurrTable = "tbJackets";
            }
            else if (comboBoxItemType.SelectedIndex == 2)
            {
                FinalColumn = "";
                Sizes = " Size,";
                CurrTable = "tbPants";
            }
            else if (comboBoxItemType.SelectedIndex == 3)
            {
                FinalColumn = ", Material";
                Sizes = " Size,";
                CurrTable = "tbBoots";
            }
            else
            {
                return ("SELECT ItemType,Brand,SerialNumber,Size,ManufactureDate,UsedNew FROM tbJackets WHERE " + firetec + "AND SerialNumber LIKE '%" + searchTerm + "%'");
            }

            return ("SELECT ItemType, Brand, SerialNumber," + Sizes + " ManufactureDate, UsedNew "
                + FinalColumn + " FROM " + CurrTable +
                     " WHERE " + firetec + " AND SerialNumber LIKE '%" + searchTerm + "%'");
        }

        private void LoadInventory()
        {
            dataGridInv.Columns["ManufactureDate"].DefaultCellStyle.Format = "d";
            int i = 0;
            dataGridInv.Rows.Clear();
            cm = new SqlCommand(QueryItems(), con);
            con.Open();
            dr = cm.ExecuteReader();

            if (comboBoxItemType.SelectedIndex == 0)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), "NA", dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else if (comboBoxItemType.SelectedIndex == 1 || comboBoxItemType.SelectedIndex == 2)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), "N/A");
                }
            }
            else if (comboBoxItemType.SelectedIndex == 3)
            {
                while (dr.Read())
                {
                    i++;
                    dataGridInv.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5]);
                }
            }
            dr.Close();
            con.Close();
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
            panelRentalType.Visible = false;
            if (!isDepartment)
            {
                try
                {

                    cm = new SqlCommand("SELECT Name,Phone,Email,Academy,DriversLicenseNumber,Address," +
                        "Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,Notes " +
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
                        textBoxNotes.Text = dr[13].ToString();
                    }
                    dr.Close();
                    con.Close();
                    license = labelClientDrivers.Text;
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
                           "Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,Notes " +
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
                        labelProfileDrivers.Text = "Point of contact:";
                        labelClientDrivers.Text = dr[0].ToString();
                        labelClientAddress.Text = dr[5].ToString();
                        textBoxNotes.Text = dr[13].ToString();
                    }
                    dr.Close();
                    con.Close();
                    flowLayoutPanelProfile.Visible = true;
                    panelProfileRentalInfo.Visible = false;
                    panelProfileMeasurments.Visible = false;
                    license = labelProfileName.Text;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            flowLayoutPanelProfile.Visible = true;
            flowLayoutPanelProfile.AutoScroll = false;
            splitContainermain.SplitterDistance = 500;
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
                    cm = new SqlCommand("INSERT INTO tbClients(Name,Phone,Email,Academy,DayNight,DriversLicenseNumber,Address,Chest,Sleeve,Waist,Inseam,Hips,Height,Weight,FireTecRepresentative)" +
                    "VALUES(@Name,@Phone,@Email,@Academy,@DayNight,@DriversLicenseNumber,@Address,@Chest,@Sleeve,@Waist,@Inseam,@Hips,@Height,@Weight,@FireTecRepresentative)", con);
                    cm.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                    cm.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                    cm.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                    cm.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                    cm.Parameters.AddWithValue("@DayNight", comboBoxRentalType.Text);
                    cm.Parameters.AddWithValue("@Address", address);
                    cm.Parameters.AddWithValue("@FireTecRepresentative", txtBoxRep.Text);
                    if (comboBoxRentalType.SelectedIndex == 0)
                    {
                        cm.Parameters.AddWithValue("@Academy", comboBoxAcademy.Text);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@Academy", txtBoxDriversLicense.Text);
                    }
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

        private void PopulateAcademyList()
        {
            string query = "SELECT * FROM tbProviders WHERE itemType = 'Academies'";
            cm = new SqlCommand(query, con);
            con.Open();
            try
            {
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxAcademy.Items.Add(dr[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
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
                        else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
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


            cm = new SqlCommand("UPDATE tbClients SET Notes = @Notes " +
                   "WHERE DriversLicenseNumber = @DriversLicenseNumber", con);
            cm.Parameters.AddWithValue("@Notes", textBoxNotes.Text);
            cm.Parameters.AddWithValue("@DriversLicenseNumber", license);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Note has been successfully saved");
        }


        private void SwapButton_Click_1(object sender, EventArgs e)
        {
            // Helmet
            if (labelTypeOfItem.Text == "Helmet")
            {
                try
                {
                    comboBoxItemType.SelectedIndex = 0;
                    //return item
                    cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", labelOldItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    //replace item
                    cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", license);
                    cm.Parameters.AddWithValue("@DueDate", dueDate);
                    cm.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Item Replaced");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                    con.Close();
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
                    cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", labelOldItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    //replace item
                    cm = new SqlCommand("UPDATE tbJackets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", license);
                    cm.Parameters.AddWithValue("@DueDate", dueDate);
                    cm.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Item Replaced");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                    con.Close();
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
                    cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", labelOldItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    //replace item
                    cm = new SqlCommand("UPDATE tbPants SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", license);
                    cm.Parameters.AddWithValue("@DueDate", dueDate);
                    cm.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Replaced");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                    con.Close();
                    return;
                }
            }

            else if (labelTypeOfItem.Text == "Boots")
            {
                comboBoxItemType.SelectedIndex = 3;

                //return item
                cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                cm.Parameters.AddWithValue("@location", "FIRETEC");
                cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                cm.Parameters.AddWithValue("@serial", labelOldItem.Text);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();

                //replace item
                cm = new SqlCommand("UPDATE tbBoots SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                cm.Parameters.AddWithValue("@location", license);
                cm.Parameters.AddWithValue("@DueDate", dueDate);
                cm.Parameters.AddWithValue("@serial", labelReplacmentItem.Text);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item Replaced");
            }
            LoadClient();
            LoadInventory();
            panelReplace.Visible = false;
            dataGridInv.Enabled = true;
            dataGridViewClient.Enabled = true;
            panelRentals.Visible = true;
            ReturnReplace = 0;

        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                        cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", SelectedSerial);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
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
                        cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", SelectedSerial);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
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
                        cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                        cm.Parameters.AddWithValue("@location", "FIRETEC");
                        cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                        cm.Parameters.AddWithValue("@serial", SelectedSerial);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item Returned");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                        con.Close();
                        return;
                    }
                }

                else if (dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString() == "Boots")
                {
                    comboBoxItemType.SelectedIndex = 3;
                    SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                    cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                    cm.Parameters.AddWithValue("@location", "FIRETEC");
                    cm.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    cm.Parameters.AddWithValue("@serial", SelectedSerial);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Returned");
                }
                LoadClient();
                LoadInventory();
            }

            else if (ReturnReplace == 2)
            {
                panelRentals.Visible = false;
                panelReplace.Visible = true;
                dataGridViewClient.Enabled = false;

                dueDate = dataGridViewClient.Rows[e.RowIndex].Cells["DueDate"].Value.ToString();
                String SelectedSerial = dataGridViewClient.Rows[e.RowIndex].Cells["SerialNum"].Value.ToString();
                labelOldItem.Text = SelectedSerial;
                labelTypeOfItem.Text = dataGridViewClient.Rows[e.RowIndex].Cells["Item"].Value.ToString();

                SwapButton.Enabled = false;

            }
        }

        private void dataGridInv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (ReturnReplace == 1 || ReturnReplace == 0)
            {


                if (MessageBox.Show("Are you sure you want to rent this item to " + labelProfileName.Text, "Rent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string SelectedSerial = "";

                    if (DateTime.Today != DatepickerDue.Value.Date)
                    {
                        // Helmet
                        if (comboBoxItemType.SelectedIndex == 0)
                        {
                            try
                            {
                                SelectedSerial = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                                cm = new SqlCommand("UPDATE tbHelmets SET location = @location ,DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                                cm.Parameters.AddWithValue("@location", license);
                                cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                                cm.Parameters.AddWithValue("@serial", SelectedSerial);
                                con.Open();
                                cm.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Rental has been successfully completed");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                                con.Close();
                                return;
                            }
                        }

                        // Jacket
                        else if (comboBoxItemType.SelectedIndex == 1)
                        {
                            try
                            {
                                SelectedSerial = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                                cm = new SqlCommand("UPDATE tbJackets SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                                cm.Parameters.AddWithValue("@location", license);
                                cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                                cm.Parameters.AddWithValue("@serial", SelectedSerial);
                                con.Open();
                                cm.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Rental has been successfully completed");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                                con.Close();
                                return;
                            }
                        }

                        // Pants
                        else if (comboBoxItemType.SelectedIndex == 2)
                        {
                            try
                            {
                                SelectedSerial = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                                cm = new SqlCommand("UPDATE tbPants SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                                cm.Parameters.AddWithValue("@location", license);
                                cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                                cm.Parameters.AddWithValue("@serial", SelectedSerial);
                                con.Open();
                                cm.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Rental has been successfully completed");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR SetSelectionModuleForm.cs --> dataGridInv_CellContentClick(): {ex.Message}");
                                con.Close();
                                return;
                            }
                        }

                        else if (comboBoxItemType.SelectedIndex == 3)
                        {
                            SelectedSerial = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                            cm = new SqlCommand("UPDATE tbBoots SET location = @location, DueDate = @DueDate WHERE SerialNumber LIKE @serial", con);
                            cm.Parameters.AddWithValue("@location", license);
                            cm.Parameters.AddWithValue("@DueDate", DatepickerDue.Value);
                            cm.Parameters.AddWithValue("@serial", SelectedSerial);
                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Rental has been successfully completed");
                        }
                        LoadClient();
                        LoadInventory();
                    }
                    else
                    {
                        MessageBox.Show("Please select a due date");
                    }
                }
            }
            else if (ReturnReplace == 2)
            {
                ReplacmentSerial = dataGridInv.Rows[e.RowIndex].Cells["Serial"].Value.ToString();
                labelReplacmentItem.Text = ReplacmentSerial;
                SwapButton.Enabled = true;
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items.Add("Academies");
            ProviderForm form = new ProviderForm(items);
            form.cbItemType.SelectedIndex = 0;
            form.close = true;
            form.ShowDialog();
            LoadBrands();
            comboBoxAcademy.SelectedIndex = comboBoxAcademy.Items.Count - 1;
        }

        private void LoadBrands()
        {
            string query = "SELECT * FROM tbProviders WHERE itemType='academies'";
            try
            {
                cm = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxAcademy.Items.Add(dataReader[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            con.Close();
        }
    }
}
