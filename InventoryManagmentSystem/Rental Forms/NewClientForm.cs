using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Rental_Forms
{
    public partial class NewClientForm : Form
    {

        NewRentalModuleForm parentForm;
        public NewClientForm()
        {
            InitializeComponent();

             parentForm = this.ParentForm as NewRentalModuleForm;
        }

        private void comboBoxRentalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RentalTypeSelector(comboBoxRentalType.Text);
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

        //private void ButtonContinue_Click(object sender, EventArgs e)
        //{
        //    if (IsBoxEmpty())
        //    {

        //        parentForm.currentUser = txtBoxCustomerName.Text;
        //        parentForm.license = txtBoxDriversLicense.Text;
        //        panelRentalType.Visible = false;

        //        if (ExistingUser == false)
        //        {
        //            if (SaveClient())
        //            {
        //                //individual
        //                if (comboBoxRentalType.SelectedIndex == 0)
        //                {
        //                    LoadProfile(false, license);
        //                }
        //                //department
        //                else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
        //                {
        //                    LoadProfile(true, license);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //individual
        //            if (comboBoxRentalType.SelectedIndex == 0)
        //            {
        //                UpdateClient();
        //                LoadProfile(false, license);
        //            }
        //            //department
        //            else if (comboBoxRentalType.SelectedIndex == 1 || comboBoxRentalType.SelectedIndex == 2)
        //            {
        //                UpdateClient();
        //                LoadProfile(true, license);
        //            }
        //            panelContactInfo.Visible = false;
        //            panelAddress.Visible = false;
        //            panelMeasurments.Visible = false;
        //            panelRentalInfo.Visible = false;
        //            ExistingUser = false;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please fill the required fields");
        //    }
        //}

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
    }
}
