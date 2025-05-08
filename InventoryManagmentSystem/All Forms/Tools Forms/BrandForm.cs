using System;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class BrandForm : Form
    {
        public bool close = false;

        public BrandForm()
        {
            InitializeComponent();
            Program.ItemService.LoadComboBoxWithItemTypes(cbItemType);
        }

        public void FillDataTable()
        {
            if(cbItemType.Text.Length < 1) { return; }
            dataGrid.Rows.Clear();
            var brands = Program.BrandService.FindAll();
            int index = 0;
            foreach (var b in brands)
            {
                dataGrid.Rows.Add(++index, b.Name);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 2) { return; }

            string message = "Do you want to delete this brand?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return; }

            string name = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            Program.BrandService.Delete(name, cbItemType.Text);
            FillDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            if (tbBrands.Text.Length == 0) { return; }

            Program.BrandService.Add(cbItemType.Text, tbBrands.Text);
            FillDataTable();
            tbBrands.Text = "";
            if (close) { this.Close(); }
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataTable();
        }
    }
}
