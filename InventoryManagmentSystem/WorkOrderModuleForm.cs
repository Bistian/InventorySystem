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
    public partial class WorkOrderModuleForm : Form
    {
        public WorkOrderModuleForm(string currClient, string DayNight, string RentalOption)
        {
            InitializeComponent();

            LableClientName.Text = currClient;
            lableRentalOption.Text = RentalOption;

            if(RentalOption == "Full Set")
            {
                if(DayNight == "Day")
                {
                labelamount.Text = "$708";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$801";
                }

                Item1.Text = "Helmet";
                Item2.Text = "Jacket";
                Item3.Text = "Pants";
                Item4.Text = "Boots";
            }
            else if(RentalOption == "Set Helmet Only")
            {
                if (DayNight == "Day")
                {
                    labelamount.Text = "$595";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$687";
                }

                Item1.Text = "Helmet";
                Item2.Text = "Jacket";
                Item3.Text = "Pants";
                Item4.Visible = false;
            }
            else if (RentalOption == "Set Boots Only")
            {
                if (DayNight == "Day")
                {
                    labelamount.Text = "$636";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$729";
                }

                Item1.Text = "Jacket";
                Item2.Text = "Pants";
                Item3.Text = "Boots";
                Item4.Visible = false;
            }
            else if (RentalOption == "Pants & Jacket")
            {
                if (DayNight == "Day")
                {
                    labelamount.Text = "$518";
                }
                else if (DayNight == "Night")
                {
                    labelamount.Text = "$610";
                }

                Item1.Text = "Jacket";
                Item2.Text = "Pants";
                Item3.Visible = false;
                Item4.Visible = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
