using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class BrandForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        #endregion SQL_Variables

        public bool close = false;
        List<Item> brands = new List<Item>();

        public BrandForm()
        {
            InitializeComponent();
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
        }

        public void FillDataTable()
        {
            if(cbItemType.Text.Length < 1) { return; }
            dataGrid.Rows.Clear();
            string query = $"SELECT * FROM tbBrands WHERE ItemType = '{cbItemType.Text.ToLower()}'";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    dataGrid.Rows.Add( reader[0], reader[1], reader[2]);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 2) { return; }

            string message = "Do you want to delete this brand?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return; }

            string query = "DELETE FROM tbBrands WHERE ItemType=@ItemType AND Brand=@Brand";
            string provider = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", cbItemType.Text);
                command.Parameters.AddWithValue("@Brand", provider);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            FillDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            if (tbBrands.Text.Length == 0) { return; }

            HelperSql.BrandsInsert(connection, cbItemType.Text, tbBrands.Text);
            brands = HelperSql.BrandsFindAll(connection);
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
