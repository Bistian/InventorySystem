using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class BrandForm : Form
    {
        public bool close = false;
        List<Item> brands = new List<Item>();

        public BrandForm()
        {
            InitializeComponent();
            HelperSql.ItemTypeLoadComboBox(cbItemType);
        }

        public void FillDataTable()
        {
            if(cbItemType.Text.Length < 1) { return; }
            dataGrid.Rows.Clear();
            string query = $"SELECT Brand FROM tbBrands WHERE ItemType = '{cbItemType.Text.ToLower()}'";
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    int count = 1;
                    while (reader.Read())
                    {
                        dataGrid.Rows.Add(count++, reader[0]);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 2) { return; }

            string message = "Do you want to delete this brand?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return; }

            string query = "DELETE FROM tbBrands WHERE ItemType=@ItemType AND Brand=@Brand";
            string provider = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ItemType", cbItemType.Text);
                    command.Parameters.AddWithValue("@Brand", provider);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
            FillDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            if (tbBrands.Text.Length == 0) { return; }

            HelperSql.BrandsInsert(cbItemType.Text, tbBrands.Text);
            brands = HelperSql.BrandsFindAll();
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
