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

        private bool isUpdate = false;
        int lastItemTypeIndex = -1;

        public NewItemForm(string itemType = "", bool isUpdate = false)
        {
            InitializeComponent();
            this.cbItemType.Text = itemType.ToLower();
            this.isUpdate = isUpdate;
            if(isUpdate)
            {
                LoadBrands();
            }
            ManageFieldsAvailability();
            loadItemTypes();
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

        private bool AddMask(Guid uuid)
        {
            string query = HelperQuery.MaskInsert();
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
            catch(Exception ex)
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
            if (cbItemType.Text == "boots") { wasAdded = AddBoots(uuid); }
            else if (cbItemType.Text == "helmet") { wasAdded = AddHelmet(uuid); }
            else if (cbItemType.Text == "mask") { wasAdded = AddMask(uuid); }
            else if (cbItemType.Text == "jacket") { wasAdded = AddJacket(uuid); }
            else if (cbItemType.Text == "pants") { wasAdded = AddPants(uuid); }
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

            Guid uuid = HelperDatabaseCall.ItemInsertAndGetUuid(connection,cbItemType.Text);
            if (uuid.Equals(Guid.Empty))
            {
                Console.WriteLine("ERROR: UUID not found.");
                return false;
            }

            bool wasAdded = SelectTableAndAddItem(uuid);
            if (!wasAdded)
            {
                // If item was not added to the specific table, delete from Items Table.
                HelperDatabaseCall.DeleteItem(command, connection, uuid);
                MessageBox.Show("Could not save the item.");
                return false;
            }

            MessageBox.Show("Item has been successfully saved.");
            return true;
        }

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
            if (cbItemType.Text == "pants") { table = "tbPants"; }

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
            if (cbItemType.Text == "boots") { isUpdated = UpdateBoots(); }
            else if (cbItemType.Text == "helmet") { isUpdated = UpdateHelmet(); }
            else if (cbItemType.Text == "jacket" || cbItemType.Text == "pants") { isUpdated = UpdateJacketOrHelmet(); }

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

        /// <summary>
        /// Account for differences between item types.
        /// Disables fields that do not apply.
        /// </summary>
        private void InitializeItemTypeSpecifics()
        {
            labelTitle.Text = $"Add new {cbItemType.Text}";

            if (isUpdate)
            {
                labelTitle.Text = $"Update {cbItemType.Text}";
            }

            if (cbItemType.Text == "pants" || cbItemType.Text == "jacket")
            {
                comboBoxSize.Enabled = true;
                comboBoxMaterial.Enabled = false;
                comboBoxColor.Enabled = false;
            }

            else if (cbItemType.Text == "boots")
            {
                comboBoxSize.Enabled = true;
                comboBoxMaterial.Enabled = true;
                comboBoxColor.Enabled = false;
            }
            
            else if (cbItemType.Text == "helmet")
            {
                comboBoxColor.Enabled = true;
                comboBoxSize.Enabled = false;
                comboBoxMaterial.Enabled = false;
            }

            else if(cbItemType.Text == "mask")
            {
                comboBoxSize.Enabled = true;
                comboBoxMaterial.Enabled = false;
                comboBoxColor.Enabled = false;
            }
        }

        private void ManageFieldsAvailability()
        {
            if(isUpdate)
            {
                cbItemType.Enabled = false;
            }

            if(cbItemType.SelectedIndex == -1)
            {
                labelTitle.Text = "Please select an item type";
                txtBoxSerialNumber.Enabled = false;
                dateTimePickerManufactureDate.Enabled = false;
                comboBoxBrand.Enabled = false;
                btnAddBrand.Enabled = false;
                comboBoxMaterial.Enabled = false;
                comboBoxSize.Enabled = false;
                comboBoxUsedNew.Enabled = false;
                comboBoxColor.Enabled = false;
                return;
            }
            if(lastItemTypeIndex == -1)
            {
                txtBoxSerialNumber.Enabled = true;
                dateTimePickerManufactureDate.Enabled = true;
                comboBoxBrand.Enabled = true;
                btnAddBrand.Enabled = true;
                comboBoxUsedNew.Enabled = true;
            }
            lastItemTypeIndex = cbItemType.SelectedIndex;
            InitializeItemTypeSpecifics();
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
            string query = $"SELECT Brand FROM tbBrands WHERE ItemType='{cbItemType.Text}'";
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxBrand.Items.Add(dataReader[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void loadItemTypes()
        {
            string query = HelperQuery.ItemTypeLoad();
            try
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    cbItemType.Items.Add(dataReader[0]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            connection.Close();
        }

        private string GetTableName()
        {
            string table = "";
            if (cbItemType.Text == "boots") { table = "tbBoots"; }
            else if (cbItemType.Text == "helmet") { table = "tbHelmets"; }
            else if (cbItemType.Text == "jacket") { table = "tbJackets"; }
            else if (cbItemType.Text == "mask") { table = "tbMasks"; }
            else if (cbItemType.Text == "pants") { table = "tbPants"; }

            return table;
        }

        /// <summary>
        /// Does not allow item to be saved if it is not safe.
        /// </summary>
        /// <returns>false if item is unsafe to be added.</returns>
        private bool SaveSafetyChecks()
        {
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

            try
            {
                connection.Open();
                command = new SqlCommand($"SELECT Count (*) FROM {tableName} WHERE SerialNumber = @SerialNumber", connection);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
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
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return Exists;
        }

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
            BrandForm form = new BrandForm();
            form.cbItemType.Text= cbItemType.Text;
            form.close = true;
            form.ShowDialog();
            LoadBrands();
            comboBoxBrand.SelectedIndex = comboBoxBrand.Items.Count - 1;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBrands();
            ManageFieldsAvailability();            
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}

