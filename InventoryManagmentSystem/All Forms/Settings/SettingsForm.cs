using InventoryManagmentSystem.All_Forms;
using System;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class SettingsForm : BaseForm
    {
        private readonly SettingsManager _settingsManager = Program.SettingsManager;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettingsIntoUI();
        }

        private void LoadSettingsIntoUI()
        {
            numeric_font_text.Text = _settingsManager.GetSetting("SettingsUser.Font.Size", 12).ToString();
        }

        private void btn_save(object sender, EventArgs e)
        {
            decimal value = numeric_font_text.Value;
            ScaleAllControls(this, (float)value);
            _settingsManager.SetSetting("SettingsUser.Font.Size", numeric_font_text.Value);
            _settingsManager.SaveSettings(); // This triggers the SettingsChanged event
            MessageBox.Show("Settings saved! All forms updated.");
        }
    }
}
