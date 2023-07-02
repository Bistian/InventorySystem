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
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        #endregion SQL_Variables

        private string itemType = "";
        private bool isUpdate = false;

        public NewItemForm(string itemType, bool isUpdate = false)
        {
            InitializeComponent();
            this.itemType = itemType.ToLower();
            this.isUpdate = isUpdate;
            InitializeItemTypeSpecifics();
            LoadBrands();
        }

        #region Create

        /// <summary>
        /// Add an item to Items table.
        /// </summary>
        /// <returns>Created item's uuid or empty if it failed.</returns>
        private Guid AddItem()
        {
            string query = HelperQuery.ItemInsertAndReturnUuid();
            Guid uuid = Guid.Empty;
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", itemType);
                connection.Open();
                uuid = (Guid)command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"ERROR adding item: {ex.Message}");
                MessageBox.Show("Could not add item.");
            }
            return uuid;
        }

        /// <summary>
        /// Deletes an item from item table.
        /// </summary>
        /// <param name="uuid"></param>
        private void DeleteItem(Guid uuid)
        {
            string query = HelperQuery.ItemDelete();
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
            string query = HelperQuery.BootsInsert();
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
            catch (Exception ex)
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
            string query = HelperQuery.HelmetInsert();
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
            string query = HelperQuery.JacketInsert();
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
            string query = HelperQuery.PantsInsert();
            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", uuid);
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
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

        private bool SelectTableAndAddItem(Guid uuid)
        {
            bool wasAdded = false;
            if (itemType == "boots") { wasAdded = AddBoots(uuid); }
            else if (itemType == "helmet") { wasAdded = AddHelmet(uuid); }
            else if (itemType == "jacket") { wasAdded = AddJacket(uuid); }
            else if (itemType == "pants") { wasAdded = AddPants(uuid); }
            return wasAdded;
        }

        /// <summary>
        /// Creates a new item on items table.
        /// </summary>
        private bool CreateItem()
        {
            if (!SaveSafetyChecks()) { return false; }

            string message = "Are you sure you want to save this Item?";
            string title = "Save Item";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return false; }

            string table = GetTableName();
            if (table == "")
            {
                Console.WriteLine("ERROR: Table not found.");
                return false;
            }

            if (CheckIfExists(table))
            {
                message = "Item already exists, do you want to update it?";
                title = "Update Item";
                if (!HelperFunctions.YesNoMessageBox(message, title)) { return false; }
                UpdateItem();
                return false;
            }

            Guid uuid = AddItem();
            if (uuid.Equals(Guid.Empty))
            {
                Console.WriteLine("ERROR: UUID not found.");
                return false;
            }

            bool wasAdded = SelectTableAndAddItem(uuid);
            if (!wasAdded)
            {
                // If item was not added to the specific table, delete from Items Table.
                DeleteItem(uuid);
                MessageBox.Show("Could not save the item.");
                return false;
            }

            MessageBox.Show("Item has been successfully saved.");
            return true;
        }
        #endregion

        #region Update

        private bool UpdateBoots()
        {
            Guid uuid = GetUuidFromItem("tbBoots");
            if (uuid.Equals(Guid.Empty)) { return false; }

            string query = $"UPDATE tbBoots " +
                $"SET SerialNumber = @SerialNumber, " +
                $"Brand = @Brand, " +
                $"UsedNew = @UsedNew," +
                $"ManufactureDate = @ManufactureDate," +
                $"Size = @Size, " +
                $"Material = @Material " +
                $"WHERE ItemId = '{uuid}';";

            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value.Date);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                command.Parameters.AddWithValue("@Material", comboBoxMaterial.Text);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool UpdateHelmet()
        {
            Guid uuid = GetUuidFromItem("tbHelmets");
            if (uuid.Equals(Guid.Empty)) { return false; }

            string query = $"UPDATE tbHelmets " +
                $"SET SerialNumber = @SerialNumber, " +
                $"Brand = @Brand, " +
                $"UsedNew = @UsedNew," +
                $"ManufactureDate = @ManufactureDate," +
                $"Color = @Color " +
                $"WHERE ItemId = '{uuid}';";

            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value.Date);
                command.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool UpdateJacketOrHelmet()
        {
            string table = "tbJackets";
            if (itemType == "pants") { table = "tbPants"; }

            Guid uuid = GetUuidFromItem(table);
            if (uuid.Equals(Guid.Empty)) { return false; }

            string query = $"UPDATE {table} " +
                $"SET SerialNumber = @SerialNumber, " +
                $"Brand = @Brand, " +
                $"UsedNew = @UsedNew," +
                $"ManufactureDate = @ManufactureDate," +
                $"Size = @Size " +
                $"WHERE ItemId = '{uuid}';";

            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                command.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                command.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value.Date);
                command.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool UpdateItem()
        {
            if (!SaveSafetyChecks()) { return false; }

            string message = "Are you sure you want to update this Item?";
            string title = "Update Item";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return false; }

            bool isUpdated = false;
            if (itemType == "boots") { isUpdated = UpdateBoots(); }
            else if (itemType == "helmet") { isUpdated = UpdateHelmet(); }
            else if (itemType == "jacket" || itemType == "pants") { isUpdated = UpdateJacketOrHelmet(); }

            if (isUpdated)
            {
                MessageBox.Show("Item has been successfully updated.");
                return true;
            }
            else
            {
                MessageBox.Show("Item cound not be updated.");
                return false;
            }
        }
        #endregion

        #region Helper Functions

        /// <summary>
        /// Account for differences between item types.
        /// Disables fields that do not apply.
        /// </summary>
        private void InitializeItemTypeSpecifics()
        {
            labelTitle.Text = $"Add new {itemType}";

            if (isUpdate)
            {
                labelTitle.Text = $"Update {itemType}";
            }

            if (itemType != "pants" &&
                itemType != "jacket" &&
                itemType != "helmet" &&
                itemType != "boots")
            {
                MessageBox.Show($"Type \"{itemType}\" does not exist.");
                this.Close();
                return;
            }

            if (itemType == "pants" || itemType == "jacket")
            {
                comboBoxMaterial.Enabled = false;
                comboBoxColor.Enabled = false;
            }

            else if (itemType == "helmet")
            {
                comboBoxSize.Enabled = false;
                comboBoxMaterial.Enabled = false;
            }

            else if (itemType == "boots")
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

        private string GetTableName()
        {
            string table = "";
            if (itemType == "boots") { table = "tbBoots"; }
            else if (itemType == "helmet") { table = "tbHelmets"; }
            else if (itemType == "jacket") { table = "tbJackets"; }
            else if (itemType == "pants") { table = "tbPants"; }

            return table;
        }

        /// <summary>
        /// Does not allow item to be saved if it is not safe.
        /// </summary>
        /// <returns>false if item is unsafe to be added.</returns>
        private bool SaveSafetyChecks()
        {
            string table = GetTableName();
            if (table == "")
            {
                Console.WriteLine("ERROR: Table not found.");
                return false;
            }

            // Regardless of item type, all items must have these fields filled.
            if (string.IsNullOrEmpty(txtBoxSerialNumber.Text) ||
                string.IsNullOrEmpty(comboBoxBrand.Text) ||
                string.IsNullOrEmpty(comboBoxUsedNew.Text) ||
                string.IsNullOrEmpty(dateTimePickerManufactureDate.Text))
            {
                MessageBox.Show("Please fill the required fields");
                return false;
            }
            // These fields vary depending on item type.
            if ((comboBoxSize.Enabled && string.IsNullOrEmpty(comboBoxSize.Text)) ||
                (comboBoxColor.Enabled && string.IsNullOrEmpty(comboBoxColor.Text)) ||
                (comboBoxMaterial.Enabled && string.IsNullOrEmpty(comboBoxMaterial.Text)))
            {
                MessageBox.Show("Please fill the required fields");
                return false;
            }

            return true;
        }

        private Guid GetUuidFromItem(string table)
        {
            Guid uuid = Guid.Empty;
            string query = $"SELECT ItemId FROM {table} WHERE SerialNumber = @SerialNumber";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                uuid = (Guid)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            connection.Close();
            return uuid;
        }

        /// <summary>
        /// Check if an item already exists on one of the item types tables.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        private bool CheckIfExists(string tableName)
        {
            string SerialNumber = txtBoxSerialNumber.Text;
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
        #endregion

        #region Buttons
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if (!UpdateItem()) { return; }
            }
            else
            {
                if (!CreateItem()) { return; }
            }
            this.Close();
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
        #endregion

    }
}

