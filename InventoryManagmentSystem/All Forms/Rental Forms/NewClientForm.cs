﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Rental_Forms
{
    public partial class NewClientForm : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
       
        List<Dictionary<string, string>> academyList;
        List<Dictionary<string, string>> classList;
        bool ExistingUser;

        public NewClientForm(string rentalType = null, string clientName = null)
        {
            InitializeComponent();
            PopulateAcademyList();
            classList = new List<Dictionary<string, string>>();
            comboBoxRentalType.SelectedIndex = 0;
            if (clientName != null)
            {
                ExistingUser = true;
                AutoFillFields(rentalType, clientName);
            }
        }

        public void AutoFillFields(string type, string clientName)
        {
            RentalTypeSelector(type);
            var client = HelperSql.ClientFindByName(connection, clientName);
            if(client.Count == 0) { return; }

            txtBoxCustomerName.Text = client["Name"];
            txtBoxDriversLicense.Text = client["DriversLicenseNumber"];
            txtBoxPhone.Text = client["Phone"];
            txtBoxEmail.Text = client["Email"];
            textBoxChest.Text = client["Chest"];
            textBoxSleeve.Text = client["Sleeve"];
            textBoxWaist.Text = client["Waist"];
            textBoxInseam.Text = client["Inseam"];
            textBoxHips.Text = client["Hips"];
            textBoxWeight.Text = client["Weight"];
            textBoxHeight.Text = client["Height"];
            cbAcademy.Text = client["Academy"];
            cbRep.Text = client["FireTecRepresentative"];
            cbClass.Text = client["IdClass"];
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
            cbRep.SelectedIndex = -1;
            cbAcademy.SelectedIndex = -1;
            cbClass.SelectedIndex = -1;

        }

        /// <summary> Safety checks. </summary>
        /// <returns> True if all important fields are filled. </returns>
        private bool AllFieldsValid()
        {
            bool normalChecks = (
                !string.IsNullOrEmpty(txtBoxStreet.Text) &&
                !string.IsNullOrEmpty(textBoxState.Text) &&
                !string.IsNullOrEmpty(textBoxZip.Text) &&
                !string.IsNullOrEmpty(txtBoxCustomerName.Text) &&
                !string.IsNullOrEmpty(txtBoxDriversLicense.Text) &&
                !string.IsNullOrEmpty(txtBoxEmail.Text) &&
                !string.IsNullOrEmpty(txtBoxPhone.Text) &&
                !string.IsNullOrEmpty(cbRep.Text) &&
                !string.IsNullOrEmpty(textBoxCity.Text)
            );
            bool measureChecks;
            if (checkBoxMeasure.Checked)
            {
                measureChecks = true;
            }
            else
            {
                measureChecks = (
                    !string.IsNullOrEmpty(textBoxChest.Text) &&
                    !string.IsNullOrEmpty(textBoxSleeve.Text) &&
                    !string.IsNullOrEmpty(textBoxWaist.Text) &&
                    !string.IsNullOrEmpty(textBoxInseam.Text) &&
                    !string.IsNullOrEmpty(textBoxHips.Text) &&
                    !string.IsNullOrEmpty(textBoxHeight.Text) &&
                    !string.IsNullOrEmpty(textBoxWeight.Text)
                );
            }
            return normalChecks && measureChecks;
        }

        private void PopulateAcademyList()
        {
            academyList = HelperSql.AcademyFindAll(connection);
            foreach(var academy in academyList)
            {
                cbAcademy.Items.Add(academy["Name"]);
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
                cbAcademy.SelectedIndex = -1;

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
                cbAcademy.SelectedIndex = 0;

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
                cbAcademy.Text = "N/A";

                //show pannels
                panelRentalInfo.Visible = true;

                panelAddress.Visible = true;

                panelContactInfo.Visible = true;

                Point point = new Point(panelAddress.Location.X, panelAddress.Location.Y + panelAddress.Size.Height);
                panelRentalInfo.Location = point;
            }
        }

        private bool SaveClient()
        {
            var client = new Dictionary<string, string>();
            Guid classId = Guid.Empty;
            foreach(var item in classList)
            {
                if (item["Name"] == cbClass.Text)
                {
                    classId = Guid.Parse(item["Id"]);
                    break;
                }
            }
            client["IdClass"] = classId == Guid.Empty ? null : classId.ToString();
            client["Address"] = $"{txtBoxStreet.Text} {textBoxCity.Text} {textBoxState.Text} {textBoxZip.Text}";
            client["Name"] = txtBoxCustomerName.Text;
            client["Phone"] = txtBoxPhone.Text;
            client["Email"] = txtBoxEmail.Text;
            client["DriversLicenseNumber"] = txtBoxDriversLicense.Text;
            client["FireTecRepresentative"] = cbRep.Text;
            client["Academy"] = cbAcademy.Text;
            client["Chest"] = textBoxChest.Text;
            client["Sleeve"] = textBoxSleeve.Text;
            client["Waist"] = textBoxWaist.Text;
            client["Inseam"] = textBoxInseam.Text;
            client["Hips"] = textBoxHips.Text;
            client["Height"] = textBoxHeight.Text;
            client["Weight"] = textBoxWeight.Text;

            bool inserted = HelperSql.ClientInsert(connection, client);
            if(inserted == false) { return false; }

            //hiding input panels
            panelFinalize.Visible = false;
            panelRentalInfo.Visible = false;
            panelMeasurments.Visible = false;
            panelAddress.Visible = false;
            panelContactInfo.Visible = false;

            return true;
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
            var command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();
                command.Parameters.AddWithValue("@Name", txtBoxCustomerName.Text);
                command.Parameters.AddWithValue("@Phone", txtBoxPhone.Text);
                command.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                if (comboBoxRentalType.SelectedIndex == 0)
                {
                    command.Parameters.AddWithValue("@Academy", cbAcademy.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@Academy", txtBoxDriversLicense.Text);
                }
                command.Parameters.AddWithValue("@DriversLicenseNumber", txtBoxDriversLicense.Text);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@FireTecRepresentative", cbRep.Text);
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
       
        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            if (!AllFieldsValid())
            {
                MessageBox.Show("Please fill the required fields");
                return;
            }

            NewRentalModuleForm DockedIn = this.Parent.Parent as NewRentalModuleForm;
            DockedIn.currentUser = txtBoxCustomerName.Text;
            DockedIn.license = txtBoxDriversLicense.Text;
            panelRentalType.Visible = false;

            if (ExistingUser == false)
            {
                //TODO: Find this comboBoxRentalType
                if (SaveClient())
                {
                    //individual
                    if (comboBoxRentalType.SelectedIndex == 0)
                    {
                        DockedIn.LoadProfile(DockedIn.license);
                    }
                    //department
                    else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                    {
                        DockedIn.LoadProfile(DockedIn.license);
                    }
                }
            }
            else
            {
                //individual
                if (comboBoxRentalType.SelectedIndex == 0)
                {
                    UpdateClient();
                    DockedIn.LoadProfile(DockedIn.license);
                }
                //department
                else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
                {
                    UpdateClient();
                    DockedIn.LoadProfile(DockedIn.license);
                }
                panelContactInfo.Visible = false;
                panelAddress.Visible = false;
                panelMeasurments.Visible = false;
                panelRentalInfo.Visible = false;
                DockedIn.ExistingUser = false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        
        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGender.Text == "Male")
            {
                panelHips.Visible = false;
                textBoxHips.Text = "N/A";
            } 
            else
            {
                panelHips.Visible = true;
                textBoxHips.Text = "";
            }
        }

        private void comboBoxRentalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RentalTypeSelector(comboBoxRentalType.Text);
        }

        private void checkBoxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxMeasure.Checked)
            {
                panelMeasurments.Visible=false;
            }
            else
            {
                panelMeasurments.Visible = true;
            }
        }

        private void checkAcademy_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAcademy.Checked)
            {
                panelAcademy.Visible = false;
                cbAcademy.Text = "N/A";
            }
            else
            {
                panelAcademy.Visible = true;
                cbAcademy.Text = "";
            }
        }

        private void comboBoxAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAcademy.SelectedIndex;
            if (index == -1) { return; }

            string name = cbAcademy.Text;
            if(classList != null) { classList.Clear(); }
            cbClass.Items.Clear();

            var academyId = Guid.Parse(academyList[index]["Id"]);
            classList = HelperSql.ClassListByAcademy(connection, academyId);
            if(classList == null) { return; }

            foreach(var item in classList)
            {
                cbClass.Items.Add(item["Name"]);
            }
        }
    }
}