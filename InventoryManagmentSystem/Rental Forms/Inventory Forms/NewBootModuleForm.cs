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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagmentSystem
{
    public partial class NewBootModuleForm : Form
    {
        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection connection = new SqlConnection(connectionString);
        //Creating command
        SqlCommand command = new SqlCommand();
        bool isNewItem;
        #endregion SQL_Variables

        public NewBootModuleForm(bool newItem = false)
        {
            InitializeComponent();
            isNewItem = newItem;
            LoadBrands();
        }

        private bool CheckIfExists(string tableName, string SerialNumber)
        {
            bool Exists = false;

            command = new SqlCommand($"SELECT Count (*) FROM {tableName} WHERE SerialNumber = @SerialNumber", connection);
            command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null)
            {
                int r = (int)result;
                Exists = r > 0 ? true : false;
            }
            else
            {
                // Null is an error!! don't add plz
                Exists = true;
            }

            connection.Close();

            return Exists;
        }
        public void Clear()
        {
            txtBoxSerialNumber.Clear();
            comboBoxBrand.SelectedIndex = -1;
            comboBoxUsedNew.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            comboBoxSize.SelectedIndex = -1;
            dateTimePickerManufactureDate.Value = DateTime.Today;
        }

        private void CreateItem()
        {
            try
            {
                string message = "Are you sure you want to save this Item?";
                DialogResult result = MessageBox.Show(message, "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.No) { return; }

                bool exists = CheckIfExists("tbBoots", txtBoxSerialNumber.Text);
                if(exists)
                {
                    MessageBox.Show("Serial Number already in the system");
                    return;
                }

                // Add to Items Table.
                string query =
                    "INSERT INTO tbItems(ItemType) " +
                    "OUTPUT inserted.Id " +
                    "VALUES(@ItemType)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", "Boots");
                connection.Open();
                // Execute the query and retrieve the generated UUID
                Guid uuid = (Guid)command.ExecuteScalar();
                connection.Close();

                query = 
                    "INSERT INTO tbBoots(ItemId,SerialNumber,Brand,UsedNew,Material,Size,ManufactureDate)" +
                    "VALUES(@ItemId, @SerialNumber,@Brand,@UsedNew,@Material,@Size,@ManufactureDate)";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@Material", comboBoxMaterial.Text);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value.Date);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item has been successfully saved");
                Clear();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Item?", "Update Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = new SqlCommand("UPDATE tbBoots SET SerialNumber = @SerialNum,Brand = @Brand, UsedNew = @UsedNew, Material = @Material, Size = @Size, ManufactureDate = @ManufactureDate WHERE BootID LIKE '" + txtBoxSerialNumber.Text + "' ", connection);
                    command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                    command.Parameters.AddWithValue("@Material", comboBoxMaterial.Text);
                    command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                    command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Item has been successfully updated");
                    this.Dispose();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxSerialNumber.Text) || 
                string.IsNullOrEmpty(comboBoxUsedNew.Text) ||
                string.IsNullOrEmpty(comboBoxBrand.Text) ||
                string.IsNullOrEmpty(comboBoxMaterial.Text) ||
                string.IsNullOrEmpty(comboBoxSize.Text))
            {
                MessageBox.Show("Please fill the required fields");
                return;
            }
            CreateItem();

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void LoadBrands()
        {
            string query = "SELECT * FROM tbProviders WHERE itemType='boots'";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxBrand.Items.Add(dataReader[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items.Add("Boots");
            ProviderForm form = new ProviderForm(items);
            form.cbItemType.SelectedIndex = 0;
            form.close = true;
            form.ShowDialog();
            LoadBrands();
            comboBoxBrand.SelectedIndex = comboBoxBrand.Items.Count - 1;
        }
    }
}
