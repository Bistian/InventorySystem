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
    public partial class NewItemModuleForm : Form
    {
        public NewItemModuleForm(bool newItem = false)
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Helmet_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewHelmetModuleForm ModForm = new NewHelmetModuleForm(true);
            ModForm.ShowDialog();
        }

        private void Jacket_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewJacketModuleForm ModForm = new NewJacketModuleForm(true);
            ModForm.ShowDialog();
        }

        private void Pants_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewPantsModuleForm ModForm = new NewPantsModuleForm(true);
            ModForm.ShowDialog();
        }

        private void Boots_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewBootModuleForm ModForm = new NewBootModuleForm(true);
            ModForm.ShowDialog();
        }
    }
}
