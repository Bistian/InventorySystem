using InventoryManagmentSystem.Academy;
using System;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagmentSystem.All_Forms;

namespace InventoryManagmentSystem
{
    public partial class MainForm : BaseForm
    {
        //colors
        Color offColor = Color.Transparent;
        Color onColor = Color.White;

        //to show subform in mainform
        private Form activeForm = null;

        //Initialize
        public MainForm(Form databaseCreation = null)
        {

            this.AutoScaleMode = AutoScaleMode.Font;
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized; // Maximizes the form to full screen

            offColor = Color.Transparent;
            onColor = Color.DarkGray;
            databaseCreation?.Dispose();

            panel_main.Dock = DockStyle.Fill;
            panel_main.AutoScroll = true;
            panel_main.AutoScrollMinSize = panel_main.DisplayRectangle.Size;
            FormBorderStyle = FormBorderStyle.Sizable;
            AutoScroll = true;

            float scale = ScaleFactor(font_size_1);
            ScaleAllControls(this, scale);
            Scaling();
            button_rentals.BackColor = offColor;
        }

        private void Scaling()
        {
            SetFontLabel(label_academy, font_size_1, FontStyle.Regular);
            SetFontLabel(label_clients, font_size_1, FontStyle.Regular);
            SetFontLabel(label_dashboard, font_size_1, FontStyle.Regular);
            SetFontLabel(label_home, font_size_1, FontStyle.Regular);
            SetFontLabel(label_inv, font_size_1, FontStyle.Regular);
            SetFontLabel(label_rentals, font_size_1, FontStyle.Regular);
            SetFontLabel(label_settings, font_size_1, FontStyle.Regular);
            SetFontLabel(label_tools, font_size_1, FontStyle.Regular);
            SetFontLabel(label_users, font_size_1, FontStyle.Regular);

            SetFontPanel(panel_button_dash, font_size_1,FontStyle.Regular);
            SetFontFlowLayoutPanel(flow_layout_panel_top, font_size_1, FontStyle.Regular);
        }

        public void ColorTabSwitch(string tab)
        {
            //check to see which nav bar is being clicked on
            switch(tab.ToLower())
            {
                case "dash": { panel_button_dash.BackColor = onColor; break; }
                case "rentals": { panel_button_rentals.BackColor = onColor; break; }
                case "users": { panel_button_users.BackColor = onColor; break; }
                case "tools": { panel_button_tools.BackColor = onColor; break; }
                case "settings": { panel_button_settings.BackColor = onColor; break; }
                case "home": { panel_button_home.BackColor = onColor; break; }
                case "clients": { panel_button_clients.BackColor = onColor; break; }
                case "inv": { panel_button_inv.BackColor = onColor; break; }
                case "academy": { panel_button_academies.BackColor = onColor; break; }
                default: { Console.WriteLine("Failed to change color"); break; }
            }
        }

        public void OpenNavBar(string tab)
        {
            //set all secondary nav bars visability to false before opening the needed one
            flow_layout_panel_left.Visible = false;


            if (tab == "Rentals")
            {
                flow_layout_panel_left.Visible = true;
            }
            else if (tab == "Service Center")
            {

            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_center.Controls.Add(childForm);
            panel_center.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            OpenNavBar("Rentals");
            ColorTabSwitch("Rentals");
            OpenChildForm(new HomeForm());
        }

        private void Button_Users_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Users");
            ColorTabSwitch("Users");
            OpenChildForm(new UserForm());
        }

        private void Button_Depatmens_Click(object sender, EventArgs e)
        {
            OpenNavBar("Dept");
            ColorTabSwitch("Dept");
            OpenChildForm(new DepartmentForm());
        }

        private void Button_Tools_Click(object sender, EventArgs e)
        {
            OpenNavBar("Tools");
            ColorTabSwitch("Tools");
            OpenChildForm(new ToolsForm());
        }

        private void Button_Dash_Click(object sender, EventArgs e)
        {
            OpenNavBar("Dash");
            ColorTabSwitch("Dash");
            OpenChildForm(new Dashboard());
        }

        private void Button_Rental_Click(object sender, EventArgs e)
        {
            OpenNavBar("Rentals");
            ColorTabSwitch("Rentals");
            ColorTabSwitch("RentalHome");
            OpenChildForm(new HomeForm());
        }

        private void Button_Home_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Home");
            OpenChildForm(new HomeForm());
        }

        private void Button_Clients_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Clients");
            OpenChildForm(new ExistingCustomerModuleForm());
        }

        private void Button_Inv_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Inv");
            OpenChildForm(new InventoryForm());
        }

        private void Button_Academy_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Academy");
            OpenChildForm(new AcademyForm());
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            OpenNavBar("Settings");
            ColorTabSwitch("Settings");
            OpenChildForm(new SettingsForm());
        }
    }
}
