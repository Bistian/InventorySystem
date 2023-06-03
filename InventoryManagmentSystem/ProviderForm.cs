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
    public partial class ProviderForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        #endregion SQL_Variables

        public ProviderForm()
        {
            InitializeComponent();
            LoadTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbItemType.SelectedIndex < 0) { return; }
            if(tbProvider.Text.Length == 0 ) { return; }
            if(ItemAddedExists()) { return; }

            string query = "INSERT INTO tbProviders (itemType, provider) VALUES (@itemType, @provider)";

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemType", cbItemType.Text);
                command.Parameters.AddWithValue("@provider", tbProvider.Text);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 3) { return; }

            string query = "DELETE FROM tbProviders WHERE itemType=@itemType AND provider=@provider";
            string item = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string provider = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemType", item);
                command.Parameters.AddWithValue("@provider", provider);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
        }

        /// <summary>
        /// Check if item already exists within the table.
        /// </summary>
        /// <returns>true if it does exists.</returns>
        private bool ItemAddedExists()
        {
            bool found = false;
            string query = "SELECT * FROM tbProviders WHERE itemType=@itemType AND provider=@provider";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemType", cbItemType.Text);
                command.Parameters.AddWithValue("@provider", tbProvider.Text);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { found = true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();

            return found;
        }

        private void LoadTable()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            string query = "SELECT * FROM tbProviders";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add(i++,
                        dataReader[0].ToString(),
                        dataReader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }
    }
}
