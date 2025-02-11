using InventoryManagmentSystem.Academy;
using System;
using System.Drawing;
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

        //Initialize
        public MainForm(Form databaseCreation = null)
        {

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized; // Maximizes the form to full screen

            offColor = Color.Transparent;
            onColor = Color.DarkGray;
            if (databaseCreation != null)
            {
                databaseCreation.Dispose();
            }
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

        private void btnTools_Click(object sender, EventArgs e)
        {
            OpenNavBar("Tools");
            ColorTabSwitch("Tools");
            openChildForm(new ToolsForm());
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
                panelTools.BackColor = offColor;
                panelSettings.BackColor = offColor;

                // Pick one tab and set it to the clicked color.
                if (tab == "Home") { panelHome.BackColor = onColor; }
                else if (tab == "Rentals") { panelRentals.BackColor = onColor; }
                else if (tab == "Users") { panelUsers.BackColor = onColor; }
                else if (tab == "Tools") { panelTools.BackColor = onColor; }
                else if (tab == "Settings") { panelSettings.BackColor = onColor; }
            }

            //Secondary Nav Bar
            else
            {
                //Set colors back to normal
                PanelRentalHome.BackColor = offColor;
                panelActiveRentals.BackColor = offColor;
                panelRentalInv.BackColor = offColor;
                panelRentalAcademies.BackColor = offColor;

                //Pick one tab and set it to the clicked color
                if (tab == "RentalHome") { PanelRentalHome.BackColor = onColor; }
                else if (tab == "ActiveRentals") { panelActiveRentals.BackColor = onColor; }
                else if (tab == "RentalsInv") { panelRentalInv.BackColor = onColor; }
                else if (tab == "RentalsAcademy") { panelRentalAcademies.BackColor = onColor; }
            }
        }

        public void OpenNavBar(string tab)
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

        private void customButton1_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("RentalsAcademy", false);
            openChildForm(new AcademyForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenNavBar("Settings");
            ColorTabSwitch("Settings");
            openChildForm(new SettingsForm());
        }
    }
}
