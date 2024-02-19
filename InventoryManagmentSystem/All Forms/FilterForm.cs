using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class FilterForm : Form
    {
        List<TextBox> fieldList = new List<TextBox>();
        Action<List<string[]>> callbackFunction;
        List<string> nameList = new List<string>();

        public FilterForm(Form parent, List<string> columnNames, Action<List<string[]>> callback)
        {
            InitializeComponent();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            BackColor = parent.BackColor;
            ForeColor = parent.ForeColor;
            Font = parent.Font;

            callbackFunction = callback;
            nameList = columnNames;

            // Create and add checkboxes dynamically.
            int Y = 0;
            foreach (var name in columnNames)
            {
                var label = new Label();
                label.Name = $"label_{name}";
                label.Text = name;
                label.Font = Font;
                label.ForeColor = ForeColor;
                int X = label.Width;
                label.Location = new Point(10, Y);
                Controls.Add(label);

                var box = new TextBox();
                box.Name = $"box_{name}";
                fieldList.Add(box);
                box.Location = new Point(X + 10, Y);
                Controls.Add(box);
                Y += Font.Height * 2;
            }

            // Set up an event handler for the OK button.
            Button btnOk = new Button();
            btnOk.Name = "btnOk";
            btnOk.Text = "OK";
            btnOk.Location = new Point(10, Y);
            btnOk.Click += btnOk_Click;
            Controls.Add(btnOk);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Collect imput values and return to the parent form.
            List<string[]> values = new List<string[]>();
            foreach (Control control in this.Controls)
            {
                if (!(control is Label)) { continue; }

                string textBoxName = "box_" + control.Name.Substring(6);
                Control textBox = this.Controls.Find(textBoxName, true).FirstOrDefault();
                if (textBox != null && textBox is TextBox)
                {
                    string[] v = { control.Text, textBox.Text };
                    values.Add(v);
                }
            }

            // Invoke the callback function with the checked items.
            callbackFunction?.Invoke(values);
        }
    }
}
