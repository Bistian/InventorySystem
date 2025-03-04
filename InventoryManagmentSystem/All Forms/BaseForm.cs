using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagmentSystem.All_Forms
{
    public partial class BaseForm : Form
    {
        private int defaul_font = 12;
        protected int font_size_1; 
        protected int font_size_2;
        protected int font_size_3;

        public BaseForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoScroll = true;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(800, 600);
            if (!IsInDesignMode())
            {
                Program.SettingsManager.SettingsChanged += OnSettingsChanged;
                ApplySettings();
            }
        }

        protected void ApplySettings()
        {
            // Ensure settings are non-null before applying
            int newFontSize = Program.SettingsManager.GetSetting("SettingsUser.Font.Size", font_size_3);
            AutoScroll = true;
            float scaleFactor = newFontSize / defaul_font;

            SettingsData.Instance.fontSize = font_size_3;

            font_size_3 = newFontSize;
            font_size_2 = (int)(newFontSize * 1.5);
            font_size_1 = newFontSize * 2;

            Font = new Font("Arial", newFontSize);
            SuspendLayout();
            Size = new Size((int)(Width * scaleFactor), (int)(Height * scaleFactor));
            ResumeLayout(true);

        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
        }

        // In BaseForm, or in your settings changed event handler:
        private void ResizeWindowFromSettings()
        {
            // Baseline design-time values
            float designReferenceFontSize = 12.0f; // For example, the design-time value of font_size_1
            Size designClientSize = new Size(800, 600); // The design-time client size of your form

            // Get the new font size from your settings JSON.
            // This is font_size_1 loaded from your JSON.
            float newFontSize = Program.SettingsManager.GetSetting("SettingsUser.Font.size", 12);

            // Calculate the scale factor based on the reference font size
            float scaleFactor = newFontSize / designReferenceFontSize;

            // Compute new dimensions based on the scale factor
            int newWidth = (int)(designClientSize.Width * scaleFactor);
            int newHeight = (int)(designClientSize.Height * scaleFactor);

            // Enforce the minimum size if necessary
            newWidth = Math.Max(newWidth, MinimumSize.Width);
            newHeight = Math.Max(newHeight, MinimumSize.Height);

            // Set the form's client size and update auto-scroll area.
            // Note: Changing ClientSize here means the inner area of the window will adjust.
            this.ClientSize = new Size(newWidth, newHeight);
            this.AutoScrollMinSize = this.DisplayRectangle.Size;

            // Force a layout update if needed.
            this.PerformLayout();
        }

        protected void SetFontButton(Button target, int size, FontStyle style)
        {
            target.Font = new Font("Arial", size, style);
        }

        protected void SetFontLabel(Label target, int size, FontStyle style)
        {
            target.Font = new Font("Arial", size, style);
        }

        protected void SetFontPanel(Panel target, int size, FontStyle style)
        {
            target.Font = new Font("Arial", size, style);
        }

        protected void SetFontFlowLayoutPanel(FlowLayoutPanel target, int size, FontStyle style)
        {
            target.Font = new Font("Arial", size, style);
        }

        protected float ScaleFactor(float newFont)
        {
            return newFont / font_size_1;
        }

        protected void ScaleAllControls(Control control, float scaleFactor)
        {
            control.SuspendLayout();

            // Scale the control itself
            control.Scale(new SizeF(scaleFactor, scaleFactor));
            foreach (Control child in control.Controls)
            {
                ScaleAllControls(child, scaleFactor);
            }
            control.ResumeLayout();
        }

        protected void SetFontGrid(DataGridView target)
        {
            // Update the column headers if needed.
            target.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", font_size_2, FontStyle.Regular);

            foreach (DataGridViewRow row in target.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder, if present
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Font = new Font("Arial", font_size_3, FontStyle.Regular);
                }
            }
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            ApplySettings();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!IsInDesignMode())
            {
                Program.SettingsManager.SettingsChanged -= OnSettingsChanged; // Avoid memory leaks
            }
        }
    }
}
