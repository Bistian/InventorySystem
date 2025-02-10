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
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            if (!IsInDesignMode())
            {
                Program.SettingsManager.SettingsChanged += OnSettingsChanged;
                ApplySettings();
            }
        }

        protected void ApplySettings()
        {
            // Ensure settings are non-null before applying
            int newFontSize = Program.SettingsManager.GetSetting("SettingsUser.Font.Size", defaul_font);
            AutoScroll = true;
            float scaleFactor = newFontSize / defaul_font;

            font_size_3 = newFontSize;
            font_size_2 = (int)(newFontSize * 1.5);
            font_size_1 = (int)(newFontSize * 2);

            Font = new Font("Arial", newFontSize);
            SuspendLayout();
            Size = new Size((int)(Width * scaleFactor), (int)(Height * scaleFactor));
            ResumeLayout(true);

        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
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
