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
    public partial class SettingsForm : Form
    {
        //to show subform in mainform
        private Form activeForm = null;

        public SettingsForm()
        {
            InitializeComponent();
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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openChildForm(new ExcelImportForm());
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            openChildForm(new DatabaseCreationModule(false));
        }
    }
}
