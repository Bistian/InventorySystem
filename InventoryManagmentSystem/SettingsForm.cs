using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class SettingsForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        // Colors
        Color offColor = Color.Transparent;
        Color onColor = Color.DarkGoldenrod;

        //to show subform in mainform
        private Form activeForm = null;

        public SettingsForm()
        {
            InitializeComponent();
            devInitAddItem();
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ColorTabSwitch(string tab)
        {
            // Set all colors to normal.
            btnDatabase.BackColor = offColor;
            btnImport.BackColor = offColor;
            btnBrands.BackColor = offColor;
            btnPrices.BackColor = offColor;
            btnAcademies.BackColor = offColor;

            // Pick one tab and set it to the clicked color.
            if (tab == "Database") { btnDatabase.BackColor = onColor; }
            else if (tab == "Import") { btnImport.BackColor = onColor; }
            else if (tab == "Brands") { btnBrands.BackColor = onColor; }
            else if (tab == "Prices") { btnPrices.BackColor = onColor; }
            else if (tab == "Academies") { btnAcademies.BackColor = onColor; }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Import");
            openChildForm(new ExcelImportForm());
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Database");
            openChildForm(new DatabaseCreationModule(false));
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Brands");
            openChildForm(new BrandForm());
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Prices");
            openChildForm(new PricesForm());
        }

        private void btnAcademies_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Academies");
            BrandForm form = new BrandForm();
            form.dataGridView1.Columns["Brands"].HeaderText = "Academies";
            form.cbItemType.Visible = false;
            form.labelItemType.Visible = false;
            form.cbItemType.SelectedIndex = 0;
            form.labelBrand.Text = "Academy Name";
            openChildForm(form);
        }

        private void btnHistories_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Histories");
            List<string> comboBoxSelection = new List<string>();
            comboBoxSelection.Add("Histories");
            RentalHistoryForm form = new RentalHistoryForm();
            openChildForm(form);
        }

        private void devInitAddItem()
        {
#if DEBUG
            cbItemType.Enabled = true;
            cbItemType.Visible = true;
            tbUuid.Enabled = true;
            tbUuid.Visible = true;
            btnAddItem.Enabled = true;
            btnAddItem.Visible = true;

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            HelperDatabaseCall.ItemTypeLoadComboBox(connection, cbItemType);
#endif
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if(cbItemType.SelectedIndex < 0) { return; }
            if(!HelperFunctions.YesNoMessageBox("Do you want to add this Item?", "Add Item")) { return; }
            Guid uuid = Guid.Empty;
            if (cbItemType.SelectedIndex == 0)
            {
                uuid = Guid.NewGuid();
            }
            else
            {
                uuid = HelperDatabaseCall.ItemInsertAndGetUuid(connection, cbItemType.Text);
            }
            tbUuid.Text = uuid.ToString();
        }
    }
}
