using InventoryManagmentSystem.Rental_Forms;
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
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Helmet_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewItemForm form = new NewItemForm("helmet");
            form.ShowDialog();
        }

        private void Jacket_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewItemForm form = new NewItemForm("jacket");
            form.ShowDialog();
        }

        private void Pants_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewItemForm form = new NewItemForm("pants");
            form.ShowDialog();
        }

        private void Boots_Click(object sender, EventArgs e)
        {
            this.Dispose();
            NewItemForm form = new NewItemForm("boots");
            form.ShowDialog();
        }
    }
}
