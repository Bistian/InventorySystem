using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class PricesForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        #endregion SQL_Variables

        public PricesForm()
        {
            InitializeComponent();
            LoadTable();
            ResetFields();
        }

        private void LoadTable()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            string query = "SELECT * FROM tbPrices";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add(i++,
                        dataReader[0].ToString(),
                        dataReader[1].ToString(),
                        dataReader[2].ToString(),
                        dataReader[3].ToString(),
                        dataReader[4].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void ResetFields()
        {
            tbName.Text = "";
            tbBoots.Text = "0";
            tbHelmet.Text = "0";
            tbJacket.Text = "0";
            tbPants.Text = "0";
        }

        private void OnlyAllawNumbersTyped(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control characters, and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the input character
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true; // Ignore the input character
            }

            // Allow up to two decimal places
            if (char.IsDigit(e.KeyChar) && ((TextBox)sender).Text.Contains('.'))
            {
                string textBoxText = ((TextBox)sender).Text;
                int decimalIndex = textBoxText.IndexOf('.');

                // Check if there are already two decimal places
                if (textBoxText.Length - decimalIndex > 2)
                {
                    e.Handled = true; // Ignore the input character
                }
            }
        }

        private bool NameAddedExists()
        {
            bool found = false;
            string query = "SELECT * FROM tbPrices WHERE name=@name";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", tbName.Text);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Length < 1) { return; }
            if(NameAddedExists()) 
            {
                string message = "Name already exists, please choose a different one.";
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return; 
            }
            if(tbBoots.Text.Length < 1) { tbBoots.Text = "0"; }
            if (tbHelmet.Text.Length < 1) { tbHelmet.Text = "0"; }
            if (tbJacket.Text.Length < 1) { tbJacket.Text = "0"; }
            if (tbPants.Text.Length < 1) { tbPants.Text = "0"; }

            string query = "INSERT INTO tbPrices (name, boots, helmets, jackets, pants) " +
                           "VALUES (@name, @boots, @helmets, @jackets, @pants)";

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", tbName.Text);
                command.Parameters.AddWithValue("@boots", tbBoots.Text);
                command.Parameters.AddWithValue("@helmets", tbHelmet.Text);
                command.Parameters.AddWithValue("@jackets", tbJacket.Text);
                command.Parameters.AddWithValue("@pants", tbPants.Text);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
            ResetFields();
        }

        private void tbBoots_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyAllawNumbersTyped(sender, e);
        }

        private void tbHelmet_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyAllawNumbersTyped(sender, e);
        }

        private void tbJacket_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyAllawNumbersTyped(sender, e);
        }

        private void tbPants_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyAllawNumbersTyped(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6) { return; }

            string message = "Do you want to delete this price?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) { return; }

            string query = "DELETE FROM tbPrices WHERE name=@name";
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadTable();
        }
    }
}
