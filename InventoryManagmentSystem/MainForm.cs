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
        Color offColor = Color.White;
        Color onColor = Color.White;

        //Initialize
        public MainForm()
        {
            InitializeComponent();
            offColor = panelHome.BackColor;
            onColor = Color.DarkGray;
        }

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
            ColorTabSwitch("Users");
            openChildForm(new UserForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ColorTabSwitch("Home");
            openChildForm(new HomeForm());
        }

        private void DepatmensButton_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Dept");
            openChildForm(new DepartmentForm());
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Inv");
            openChildForm(new InventoryForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Import");
            openChildForm(new ExcelImportForm());
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Home");
            openChildForm(new HomeForm());
        }

        private void RentalButton_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Rentals");
            openChildForm(new RentalForm());
        }

        private void ColorTabSwitch(string tab)
        {
            // Set all colors to normal.
            panelHome.BackColor = offColor;
            panelRentals.BackColor = offColor;
            panelInv.BackColor = offColor;
            panelDept.BackColor = offColor;
            panelUsers.BackColor = offColor;
            panelImport.BackColor = offColor;

            // Pick one tab and set it to the clicked color.
            if(tab == "Home") { panelHome.BackColor = onColor; }
            else if (tab == "Rentals") { panelRentals.BackColor = onColor; }
            else if (tab == "Inv") { panelInv.BackColor = onColor; }
            else if (tab == "Dept") { panelDept.BackColor = onColor; }
            else if (tab == "Users") { panelUsers.BackColor = onColor; }
            else if (tab == "Import") { panelImport.BackColor = onColor; }
        }
    }
}
