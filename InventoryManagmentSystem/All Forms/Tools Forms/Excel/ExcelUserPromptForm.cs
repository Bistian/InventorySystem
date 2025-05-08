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
    public partial class ExcelUserPromptForm : Form
    {
        public event EventHandler<PromptEventArg> userPrompt;

        public ExcelUserPromptForm(List<string> columns, bool isManual)
        {
            InitializeComponent();

            if(isManual == false)
            {
                labelRow.Visible = false;
                numericUpDownRow.Visible = false;
            }

            foreach (string column in columns)
            {
                comboBoxColumns.Items.Add(column);
            }
        }

        private void ExcelUserPromptForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var arguments = new PromptEventArg
            {
                selectedWorksheet = "",
                selectedRow = -1,
            };

            // Raise the userPrompted event and pass the arguments object.
            userPrompt?.Invoke(this, arguments);

            // Close form.
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Add a new PromptEventArgs object with the selected worksheet and row.
            var arguments = new PromptEventArg
            {
                selectedWorksheet = comboBoxColumns.Text,
                selectedRow = (int)numericUpDownRow.Value,
            };

            // Raise the userPrompted event and pass the arguments object.
            userPrompt?.Invoke(this, arguments);

            // Close form.
            this.Close();
        }
    }

    public class PromptEventArg : EventArgs
    {
        //public int selectedWorksheet { get; set; }
        public string selectedWorksheet { get; set; }
        public int selectedRow { get; set; }
    }
}
