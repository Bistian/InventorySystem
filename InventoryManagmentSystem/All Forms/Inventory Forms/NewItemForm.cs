using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Rental_Forms
{
    public partial class NewItemForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        private bool isUpdate = false;
        int lastItemTypeIndex = -1;
        private string tableName = "";
        private string itemType = "";

        public NewItemForm(string itemType = "", bool isUpdate = false)
        {
            InitializeComponent();
            this.itemType = itemType;
            this.isUpdate = isUpdate;
            if (isUpdate)
            {
                HelperSql.BrandsFillComboBox(connection, cbItemType.Text.ToLower(), cbBrand);
            }
            ManageFieldsAvailability();
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
            for (int i = 0; i < cbItemType.Items.Count; ++i)
            {
                if (cbItemType.Items[i].ToString() == itemType)
                {
                    cbItemType.SelectedIndex = i;
                    break;
                }
            }
            GetTableName();
        }

        private bool SelectTableAndAddItem(string uuid)
        {
            bool wasAdded = false;
            if (cbItemType.Text.ToLower() == "boots") 
            {
                wasAdded = HelperSql.BootsInsert(connection, 
                    uuid, cbBrand.Text, dtAcquisition.Text, dtManufacture.Text, cbSize.Text, cbMaterial.Text); 
            }
            else if (cbItemType.Text.ToLower() == "helmet") 
            { 
                wasAdded = HelperSql.HelmetInsert(connection,
                    uuid, cbBrand.Text, dtAcquisition.Text, dtManufacture.Text, cbColor.Text); 
            }
            else if (cbItemType.Text.ToLower() == "jacket") 
            { 
                wasAdded = HelperSql.JacketInsert(connection,
                    uuid, cbBrand.Text, dtAcquisition.Text, dtManufacture.Text, cbSize.Text); 
            }
            else if (cbItemType.Text.ToLower() == "mask") 
            {
                wasAdded = HelperSql.MaskInsert(connection,
                    uuid, cbBrand.Text, dtAcquisition.Text, dtManufacture.Text, cbSize.Text);
            }
            else if(cbItemType.Text.ToLower() == "pants")
            {
                wasAdded = HelperSql.PantsInsert(connection,
                    uuid, cbBrand.Text, dtAcquisition.Text, dtManufacture.Text, cbSize.Text);
            }
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

            GetTableName();
            if (tableName == "")
            {
                Console.WriteLine("ERROR: Table not found.");
                return false;
            }

            var item = HelperSql.ItemFindBySerialNumber(connection, itemType, tbSerialNumber.Text);
            if (item != null)
            {
                message = "Item already exists, do you want to update it?";
                title = "Update Item";
                if (!HelperFunctions.YesNoMessageBox(message, title)) { return false; }
                UpdateItem();
                return false;
            }

            string uuid = HelperSql.ItemInsertAndGetUuid(connection, cbItemType.Text, tbSerialNumber.Text, cbCondition.Text, "Rent");
            if (uuid == "")
            {
                Console.WriteLine("ERROR: UUID not found.");
                return false;
            }

            bool wasAdded = SelectTableAndAddItem(uuid);
            if (!wasAdded)
            {
                // If item was not added to the specific table, delete from Items Table.
                HelperSql.ItemDelete(connection, uuid);
                MessageBox.Show("Could not save the item.");
                return false;
            }

            MessageBox.Show("Item has been successfully saved.");
            return true;
        }

        private bool UpdateItem()
        {
            if (!SaveSafetyChecks()) { return false; }

            string message = "Are you sure you want to update this Item?";
            string title = "Update Item";
            if (!HelperFunctions.YesNoMessageBox(message, title)) { return false; }

            var item = HelperSql.ItemFindBySerialNumber(connection, cbItemType.Text, tbSerialNumber.Text);
            bool isUpdated = false;
            if (itemType == "boots") 
            {
                isUpdated = HelperSql.BootsUpdate(connection,
                    item.GetColumnValue("Id"),
                    cbBrand.Text,
                    cbSize.Text,
                    cbMaterial.Text,
                    dtManufacture.Value.Date.ToString());
            }
            else if (itemType == "helmet") 
            {
                isUpdated = HelperSql.HelmetUpdate(connection,
                    item.GetColumnValue("Id"),
                    cbBrand.Text, 
                    dtManufacture.Value.Date.ToString(), 
                    cbColor.Text); 
            }
            else if (itemType == "jacket") 
            {
                isUpdate = HelperSql.JacketUpdate(connection,
                    item.GetColumnValue("Id"),
                    cbBrand.Text,
                    dtManufacture.Value.Date.ToString(),
                    cbSize.Text);
            }
            else if (itemType == "mask")
            {
                isUpdate = HelperSql.MaskUpdate(connection,
                    item.GetColumnValue("Id"),
                    cbBrand.Text,
                    dtManufacture.Value.Date.ToString(),
                    cbSize.Text);
            }
            else if (itemType == "pants")
            {
                isUpdate = HelperSql.PantsUpdate(connection,
                    item.GetColumnValue("Id"),
                    cbBrand.Text,
                    dtManufacture.Value.Date.ToString(),
                    cbSize.Text);
            }

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
            if (isUpdate)
            {
                labelTitle.Text = $"Update {cbItemType.Text}";
            }
            else
            {
                labelTitle.Text = $"Add new {cbItemType.Text}";
            }

            string itemType = cbItemType.Text.ToLower();
            if (itemType == "pants" || itemType == "jacket")
            {
                cbSize.Enabled = true;
                cbMaterial.Enabled = false;
                cbColor.Enabled = false;
            }

            else if (itemType == "boots")
            {
                cbSize.Enabled = true;
                cbMaterial.Enabled = true;
                cbColor.Enabled = false;
            }

            else if (itemType == "helmet")
            {
                cbColor.Enabled = true;
                cbSize.Enabled = false;
                cbMaterial.Enabled = false;
            }

            else if (itemType == "mask")
            {
                cbSize.Enabled = true;
                cbMaterial.Enabled = false;
                cbColor.Enabled = false;
            }
        }

        private void ManageFieldsAvailability()
        {
            if (isUpdate)
            {
                cbItemType.Enabled = false;
            }

            if (cbItemType.SelectedIndex == -1)
            {
                labelTitle.Text = "Please select an item type";
                tbSerialNumber.Enabled = false;
                dtManufacture.Enabled = false;
                cbBrand.Enabled = false;
                btnAddBrand.Enabled = false;
                cbMaterial.Enabled = false;
                cbSize.Enabled = false;
                cbCondition.Enabled = false;
                cbColor.Enabled = false;
                return;
            }
            if (lastItemTypeIndex == -1)
            {
                tbSerialNumber.Enabled = true;
                dtManufacture.Enabled = true;
                cbBrand.Enabled = true;
                btnAddBrand.Enabled = true;
                cbCondition.Enabled = true;
            }
            lastItemTypeIndex = cbItemType.SelectedIndex;
            InitializeItemTypeSpecifics();
        }

        /// <summary>
        /// Clear fields.
        /// </summary>
        public void Clear()
        {
            tbSerialNumber.Clear();
            cbBrand.SelectedIndex = -1;
            cbCondition.SelectedIndex = -1;
            cbMaterial.SelectedIndex = -1;
            cbSize.SelectedIndex = -1;
            cbColor.SelectedIndex = -1;
            dtManufacture.Value = DateTime.Today;
        }

        private void GetTableName()
        {
            if (cbItemType.Text.ToLower() == "boots") { tableName = "tbBoots"; itemType = "boots"; }
            else if (cbItemType.Text.ToLower() == "helmet") { tableName = "tbHelmets"; itemType = "helmet"; }
            else if (cbItemType.Text.ToLower() == "jacket") { tableName = "tbJackets"; itemType = "jacket"; }
            else if (cbItemType.Text.ToLower() == "mask") { tableName = "tbMasks"; itemType = "mask"; }
            else if (cbItemType.Text.ToLower() == "pants") { tableName = "tbPants"; itemType = "pants"; }
        }

        /// <summary>
        /// Does not allow item to be saved if it is not safe.
        /// </summary>
        /// <returns>false if item is unsafe to be added.</returns>
        private bool SaveSafetyChecks()
        {
            // Regardless of item type, all items must have these fields filled.
            if (string.IsNullOrEmpty(tbSerialNumber.Text) ||
                string.IsNullOrEmpty(cbBrand.Text) ||
                string.IsNullOrEmpty(cbCondition.Text) ||
                string.IsNullOrEmpty(dtManufacture.Text))
            {
                MessageBox.Show("Please fill the required fields");
                return false;
            }
            // These fields vary depending on item type.
            if ((cbSize.Enabled && string.IsNullOrEmpty(cbSize.Text)) ||
                (cbColor.Enabled && string.IsNullOrEmpty(cbColor.Text)) ||
                (cbMaterial.Enabled && string.IsNullOrEmpty(cbMaterial.Text)))
            {
                MessageBox.Show("Please fill the required fields");
                return false;
            }

            return true;
        }

        private void LoadSizes()
        {
            string itemType = cbItemType.Text.ToLower();
            cbSize.Items.Clear();
            if (itemType == "boots")
            {
                cbSize.Items.Add("5");
                cbSize.Items.Add("5.5");
                cbSize.Items.Add("6");
                cbSize.Items.Add("6.5");
                cbSize.Items.Add("7");
                cbSize.Items.Add("7.5");
                cbSize.Items.Add("8");
                cbSize.Items.Add("8.5");
                cbSize.Items.Add("9");
                cbSize.Items.Add("10");
                cbSize.Items.Add("10.5");
                cbSize.Items.Add("11");
                cbSize.Items.Add("11.5");
                cbSize.Items.Add("12");
                cbSize.Items.Add("12.5");
                cbSize.Items.Add("13");
                cbSize.Items.Add("13.5");
                cbSize.Items.Add("14");
                cbSize.Items.Add("14.5");
                cbSize.Items.Add("15");
                cbSize.Items.Add("15.5");
                cbSize.Items.Add("16");
            }
            else if (itemType == "pants" || itemType == "jacket" || itemType == "mask")
            {
                cbSize.Items.Add("S");
                cbSize.Items.Add("M");
                cbSize.Items.Add("L");
                cbSize.Items.Add("XL");
            }
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
            form.cbItemType.Text = cbItemType.Text;
            form.close = true;
            form.ShowDialog();
            HelperSql.BrandsFillComboBox(connection, cbItemType.Text.ToLower(), cbBrand);
            cbBrand.SelectedIndex = cbBrand.Items.Count - 1;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelperSql.BrandsFillComboBox(connection, cbItemType.Text.ToLower(), cbBrand);
            LoadSizes();
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

