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
        public MainForm()
        {
            InitializeComponent();
        }

        //to show subform in mainform

        private Form activeForm = null;
        
        private void openChildForm(Form childForm)
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
            openChildForm(new UserForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
