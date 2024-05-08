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
        public SettingsForm()
        {
            InitializeComponent();
            //ChangeFormFontSize(SettingsData.Instance.fontSize);
            //ChangeControlFontSize(this.Controls, SettingsData.Instance.fontSize);
            InitializeFields();
        }

        private void InitializeFields()
        {
            tbFontSize.Text = SettingsData.Instance.fontSize.ToString();
            tbDueDays.Text = SettingsData.Instance.dueDaysFromToday.ToString();
        }

        private void ChangeFormFontSize(float newSize)
        {
            foreach (Control control in this.Controls)
            {
                ChangeControlFontSize(control, newSize);
            }
            this.PerformLayout();
        }

        private void ChangeControlFontSize(Control control, float newSize)
        {
            control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
            foreach (Control childControl in control.Controls)
            {
                ChangeControlFontSize(childControl, newSize);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Are you sure you want to save this Setting?";
                string title = "Save Setting";
                if (!HelperFunctions.YesNoMessageBox(message, title)) { return; }
                if (int.TryParse(tbDueDays.Text, out int newDueDays))
                {
                    SettingsData.Instance.dueDaysFromToday = newDueDays;
                }
                if(float.TryParse(tbFontSize.Text, out float newSize))
                {
                    SettingsData.Instance.fontSize = newSize;
                }
                SettingsData.Instance.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
