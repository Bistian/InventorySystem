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
        Color offColor = Color.Transparent;
        Color onColor = Color.White;

        //Initialize
        public MainForm()
        {
            InitializeComponent();
            offColor = Color.Transparent;
            onColor = Color.DarkGray;
        }
        //keeping track of current tab
        string currTab = "";
        //to show subform in mainform
        private Form activeForm = null;

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
            OpenNavBar("Home");
            ColorTabSwitch("Home", true);
            openChildForm(new HomeForm());
        }

        private void DepatmensButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Dept");
            ColorTabSwitch("Dept", true);
            openChildForm(new DepartmentForm());
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Inv");
            ColorTabSwitch("Inv", true);
            openChildForm(new InventoryForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenNavBar("Import");
            ColorTabSwitch("Import", true);
            openChildForm(new ExcelImportForm());
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Home");
            ColorTabSwitch("Home", true);
            openChildForm(new HomeForm());
        }

        private void RentalButton_Click(object sender, EventArgs e)
        {
            OpenNavBar("Rentals");
            ColorTabSwitch("Rentals", true);
            openChildForm(new HomeForm());
        }

        private void ColorTabSwitch(string tab, bool isPrimary)
        {
            //check to see which nav bar is being clicked on
            if (isPrimary)
            {
                 // Set all colors to normal.
                panelHome.BackColor = offColor;
                panelRentals.BackColor = offColor;
                panelDept.BackColor = offColor;
                panelUsers.BackColor = offColor;
                panelImport.BackColor = offColor;

                // Pick one tab and set it to the clicked color.
                if (tab == "Home") { panelHome.BackColor = onColor; }
                else if (tab == "Rentals") { panelRentals.BackColor = onColor; }
                else if (tab == "Dept") { panelDept.BackColor = onColor; }
                else if (tab == "Users") { panelUsers.BackColor = onColor; }
                else if (tab == "Import") { panelImport.BackColor = onColor; }
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
