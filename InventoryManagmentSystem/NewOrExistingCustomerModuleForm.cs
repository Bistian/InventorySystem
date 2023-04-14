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
    public partial class NewOrExistingCustomerModuleForm : Form
    {
        public NewOrExistingCustomerModuleForm()
        {
            InitializeComponent();
        }

        private void ButtonNewCustomer_Click(object sender, EventArgs e)
        {
            NewRentalModuleForm ModForm = new NewRentalModuleForm();
            this.Dispose();
            ModForm.ShowDialog();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void ButtonExistingCustomer_Click(object sender, EventArgs e)
        {
            ExistingCustomerModuleForm ModForm = new ExistingCustomerModuleForm();
            this.Dispose();
            ModForm.ShowDialog();
        }
    }
}
