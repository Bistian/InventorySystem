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
    public partial class ReturnOrReplacecs : Form
    {
        NewRentalModuleForm parentForm;
        public ReturnOrReplacecs(NewRentalModuleForm Parent)
        {
            InitializeComponent();
            this.parentForm = Parent as NewRentalModuleForm;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            parentForm.ReturnReplace = 1;

            this.Dispose();
            
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            parentForm.ReturnReplace = 2;
            parentForm.dataGridViewClient.Enabled = true;
            parentForm.SwapButton.Enabled = false;
            //parentForm.comboBoxItemType.Enabled = false;
            MessageBox.Show("Select a replacment");
            this.Dispose();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            parentForm.ReturnReplace = 0;
            this.Dispose();
        }
    }
}
