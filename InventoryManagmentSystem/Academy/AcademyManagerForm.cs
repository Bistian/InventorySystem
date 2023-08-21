using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AcademyManagerForm : Form
    {
        private Form activeForm = null;

        public AcademyManagerForm()
        {
            InitializeComponent();
        }

        private void btnCreateAcademy_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            //activeForm = new CreateAcademyForm();

            HelperFunctions.OpenChildForm(activeForm, ref panelDocker);
        }
    }
}
