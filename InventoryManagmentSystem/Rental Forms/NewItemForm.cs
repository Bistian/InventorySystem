using Microsoft.Office.Interop.Excel;
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

namespace InventoryManagmentSystem.Rental_Forms
{
    public partial class NewItemForm : Form
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

        private string itemType = "";

        public NewItemForm(string itemType)
        {
            InitializeComponent();
            this.itemType = itemType.ToLower();
            SetItemTypeSpecifics();
            LoadBrands();
        }

        /// <summary>
        /// Account for differences between item types.
        /// Disables fields that do not apply.
        /// </summary>
        private void SetItemTypeSpecifics()
        {
            if (itemType != "pants" &&
                itemType != "jacket" &&
                itemType != "helmet" &&
                itemType != "boots")
            {
                MessageBox.Show($"Type \"{itemType}\" does not exist.");
                this.Close();
                return;
            }

            labelTitle.Text = $"Add new {itemType}";

            if (itemType == "pants" || itemType == "jacket")
            {
                comboBoxColor.Enabled = false;
            }

            else if (itemType == "helmet")
            {
                comboBoxSize.Enabled = false;
            }

            else if(itemType == "boots")
            {
                comboBoxColor.Enabled = false;
            }
        }

        /// <summary>
        /// Clear fields.
        /// </summary>
        public void Clear()
        {
            txtBoxSerialNumber.Clear();
            comboBoxBrand.SelectedIndex = -1;
            comboBoxUsedNew.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            comboBoxSize.SelectedIndex = -1;
            comboBoxColor.SelectedIndex = -1;
            dateTimePickerManufactureDate.Value = DateTime.Today;
        }

        /// <summary>
        /// Add existing brands to brand selection.
        /// </summary>
        private void LoadBrands()
        {
            string query = $"SELECT * FROM tbProviders WHERE itemType='{itemType}'";
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

        /// <summary>
        /// Creates a new item on items table.
        /// </summary>
        private void CreateItem()
        {
            try
            {
                string message = "Are you sure you want to save this Item?";
                DialogResult result = MessageBox.Show(message, "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) { return; }

                bool exists = CheckIfExists("tbBoots", txtBoxSerialNumber.Text);
                if (exists)
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
                command.Parameters.AddWithValue("@ItemType", itemType);
                connection.Open();
                // Execute the query and retrieve the generated UUID
                Guid uuid = (Guid)command.ExecuteScalar();
                connection.Close();

                bool wasAdded = false;
                if(itemType == "boots") { wasAdded = AddBoots(uuid); }
                else if(itemType == "helmet") { wasAdded = AddHelmet(uuid); }
                else if(itemType == "jacket") { wasAdded = AddJacket(uuid); }
                else if(itemType == "pants") { wasAdded = AddPants(uuid); }

                if(!wasAdded)
                {
                    DeleteItem(uuid);
                    MessageBox.Show("Could not save the item.");
                    return;
                }
                MessageBox.Show("Item has been successfully saved.");
                Clear();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item from item table.
        /// </summary>
        /// <param name="uuid"></param>
        private void DeleteItem(Guid uuid)
        {
            string query = "DELETE FROM tbItems WHERE Id=@Id";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", uuid);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        /// <summary>
        /// Adds boots to boots table.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private bool AddBoots(Guid uuid)
        {
            string query =
                "INSERT INTO tbBoots(ItemId,SerialNumber,Brand,UsedNew,Material,Size,ManufactureDate)" +
                "VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Material,@Size,@ManufactureDate)";
            try
            {
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
                return true;
            }
            catch(Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Adds a helmet to helmets table.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private bool AddHelmet(Guid uuid)
        {
            string query =
                "INSERT INTO tbHelmets(ItemId,SerialNumber,Brand,UsedNew,Color,ManufactureDate)" +
                "VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Color,@ManufactureDate)";

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Adds a jacket to jackets table.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private bool AddJacket(Guid uuid)
        {
            string query =
                "INSERT INTO tbJackets(ItemId,SerialNumber,Brand,UsedNew,Size,ManufactureDate)" +
                "VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Add pants to pants table.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private bool AddPants(Guid uuid)
        {
            string query =
                "INSERT INTO tbPants(ItemId,SerialNumber,Brand,UsedNew,Size,ManufactureDate)" +
                "VALUES(@ItemId,@SerialNumber,@Brand,@UsedNew,@Size,@ManufactureDate)";
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex) 
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Check if an item already exists on one of the item types tables.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Regardless of item type, all items must have these fields filled.
            if (string.IsNullOrEmpty(txtBoxSerialNumber.Text) ||
                string.IsNullOrEmpty(comboBoxUsedNew.Text) ||
                string.IsNullOrEmpty(comboBoxBrand.Text) ||
                string.IsNullOrEmpty(comboBoxMaterial.Text))
            {
                MessageBox.Show("Please fill the required fields");
                return;
            }
            // These fields vary depending on item type.
            if ((comboBoxSize.Enabled && string.IsNullOrEmpty(comboBoxSize.Text)) ||
                (comboBoxColor.Enabled && string.IsNullOrEmpty(comboBoxColor.Text)) ||
                (comboBoxSize.Enabled && string.IsNullOrEmpty(comboBoxSize.Text)))
            {
                MessageBox.Show("Please fill the required fields");
                return;
            }

            CreateItem();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items.Add(itemType);
            ProviderForm form = new ProviderForm(items);
            form.cbItemType.SelectedIndex = 0;
            form.close = true;
            form.ShowDialog();
            LoadBrands();
            comboBoxBrand.SelectedIndex = comboBoxBrand.Items.Count - 1;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}

