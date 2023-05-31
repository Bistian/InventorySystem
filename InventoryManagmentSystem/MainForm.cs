using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class MainForm : Form
    {
        //colors
        Color offColor = Color.Transparent;
        Color onColor = Color.White;

        //to show subform in mainform
        private Form activeForm = null;

        //Track previous form
       private Form previousForm = null;

        //Initialize
        public MainForm(Form databaseCreation = null)
        {

            InitializeComponent();
            offColor = Color.Transparent;
            onColor = Color.DarkGray;
            if (databaseCreation != null)
            {
                //Gage likes minors
                databaseCreation.Dispose();
            }
        }

        public void SetPrevForm(Form curr)
        {
            previousForm = curr;
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Users", true);
            openChildForm(new UserForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenNavBar("Rentals");
            ColorTabSwitch("Rentals", true);
            openChildForm(new HomeForm());
        }

        private void DepatmensButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Dept");
            ColorTabSwitch("Dept");
            openChildForm(new DepartmentForm());
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Inv");
            ColorTabSwitch("Inv");
            openChildForm(new InventoryForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenNavBar("Settings");
            ColorTabSwitch("Settings");
            openChildForm(new SettingsForm());
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Home");
            ColorTabSwitch("Home");
            openChildForm(new Dashboard());
        }

        private void RentalButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Rentals");
            ColorTabSwitch("Rentals");
            ColorTabSwitch("RentalHome", false);
            openChildForm(new HomeForm());
        }

        public void ColorTabSwitch(string tab, bool isPrimary = true)
        {
            //check to see which nav bar is being clicked on
            if (isPrimary)
            {
                 // Set all colors to normal.
                panelHome.BackColor = offColor;
                panelRentals.BackColor = offColor;
                panelUsers.BackColor = offColor;
                panelImport.BackColor = offColor;

                // Pick one tab and set it to the clicked color.
                if (tab == "Home") { panelHome.BackColor = onColor; }
                else if (tab == "Rentals") { panelRentals.BackColor = onColor; }
                else if (tab == "Users") { panelUsers.BackColor = onColor; }
                else if (tab == "Settings") { panelImport.BackColor = onColor; }
            }

            //Secondary Nav Bar
            else
            {
                //Set colors back to normal
                PanelRentalHome.BackColor = offColor;
                panelActiveRentals.BackColor = offColor;
                panelRentalInv.BackColor = offColor;


                //Pick one tab and set it to the clicked color
                if (tab == "RentalHome") { PanelRentalHome.BackColor = onColor; }
                else if (tab == "ActiveRentals") { panelActiveRentals.BackColor = onColor; }
                else if (tab == "RentalsInv") { panelRentalInv.BackColor = onColor; }
            }
        }

        private void OpenNavBar(string tab)
        {
            //set all secondary nav bars visability to false before opening the needed one
            RentalsNavBar.Visible = false;


            if(tab == "Rentals") 
            {
                RentalsNavBar.Visible = true;
            }
            else if (tab == "Service Center")
            {

            }
        }

        private void ButtonRentalHome_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("RentalHome", false);
            openChildForm(new HomeForm());
        }

        private void ButtonActiveRentals_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("ActiveRentals", false);
            openChildForm(new ExistingCustomerModuleForm());
        }

        private void ButtonRentalInv_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("RentalsInv", false);
            openChildForm(new InventoryForm());
        }
    }
}
