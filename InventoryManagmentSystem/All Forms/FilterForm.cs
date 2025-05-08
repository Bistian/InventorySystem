using InventoryManagmentSystem.C__Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class FilterForm : BaseForm
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

            // Add and add checkboxes dynamically.
            int Y = 10;
            foreach (var name in columnNames)
            {
                var label = new Label();
                label.Name = $"label_{name}";
                label.Text = name;
                label.ForeColor = ForeColor;
                label.Location = new Point(10, Y);
                Controls.Add(label);

                var box = new TextBox();
                box.Width = parent.Width / 2;
                box.Name = $"box_{name}";
                fieldList.Add(box);
                box.KeyDown += TextBox_KeyDown;
                int X = label.Width;
                box.Location = new Point(X + 10, Y);
                Controls.Add(box);
                Y += box.Height;
            }

            float scale = 1.5f;

            // Event handler for the OK button.
            Button btnOk = new Button();
            btnOk.Name = "btnOk";
            btnOk.Text = "OK";
            btnOk.Location = new Point(10, Y);
            HelperButton.ScaleFont(btnOk, scale);
            HelperButton.ScaleSize(btnOk, scale, scale);
            btnOk.Click += btnOk_Click;
            Controls.Add(btnOk);
            Y += btnOk.Height;

            // Event handler for Clear button
            Button btnClear = new Button();
            btnClear.Name = "btnClear";
            btnClear.Text = "Clear";
            btnClear.Location = new Point(10, Y);
            HelperButton.ScaleFont(btnClear, scale);
            HelperButton.ScaleSize(btnClear, scale, scale);
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);
            Y += btnOk.Height;

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null)
                {
                    textBox.Clear();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(var field in fieldList)
            {
                field.Clear();
            }
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
