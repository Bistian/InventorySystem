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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;

namespace InventoryManagmentSystem
{
    public partial class ToolsForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        #region SQL_Variables

        //Creating command
        SqlCommand command = new SqlCommand();
        #endregion SQL_Variables
        // Colors
        Color offColor = Color.Transparent;
        Color onColor = Color.DarkGoldenrod;

        //to show subform in mainform
        private Form activeForm = null;

        public ToolsForm()
        {
            InitializeComponent();
            devInitAddItem();
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ColorTabSwitch(string tab)
        {
            // Set all colors to normal.
            btnDatabase.BackColor = offColor;
            btnImport.BackColor = offColor;
            btnBrands.BackColor = offColor;
            btnPrices.BackColor = offColor;

            // Pick one tab and set it to the clicked color.
            if (tab == "Database") { btnDatabase.BackColor = onColor; }
            else if (tab == "Import") { btnImport.BackColor = onColor; }
            else if (tab == "Brands") { btnBrands.BackColor = onColor; }
            else if (tab == "Prices") { btnPrices.BackColor = onColor; }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Import");
            openChildForm(new ExcelImportForm());
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Database");
            openChildForm(new DatabaseCreationModule(false));
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Brands");
            openChildForm(new BrandForm());
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            ColorTabSwitch("Prices");
            openChildForm(new PricesForm());
        }

        private void devInitAddItem()
        {
#if DEBUG
            cbItemType.Enabled = true;
            cbItemType.Visible = true;
            tbUuid.Enabled = true;
            tbUuid.Visible = true;
            btnAddItem.Enabled = true;
            btnAddItem.Visible = true;

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            HelperSql.ItemTypeLoadComboBox(connection, cbItemType);
#endif
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cbItemType.SelectedIndex < 0) { return; }
            if (!HelperFunctions.YesNoMessageBox("Do you want to add this Item?", "Add Item")) { return; }

            string table = "";
            if (cbItemType.Text == "boots") { table = "tbBoots"; }
            else if (cbItemType.Text == "helmet") { table = "tbHelmets"; }
            else if (cbItemType.Text == "jacket") { table = "tbJackets"; }
            else if (cbItemType.Text == "mask") { table = "tbMasks"; }
            else if (cbItemType.Text == "pants") { table = "tbPants"; }
            else { return; }

            // Loop through the table.
            while (true)
            {
                //Guid uuid = HelperSql.ItemInsertAndGetUuid(connection, cbItemType.Text);
                // Add item id to null.
                string query = $@"
                    UPDATE TOP(1) {table}
                    SET ItemId = 'uuid'
                    OUTPUT 1 
                    WHERE ItemId IS NULL;
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); connection.Close();
                    if (rowsAffected < 1)
                    {
                        //HelperSql.ItemDelete(connection, uuid);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //HelperSql.ItemDelete(connection, uuid);
                    Console.WriteLine(ex.Message);
                    connection.Close();
                }
            }
            Console.WriteLine("Gaje likes minors!");
        }

        private bool CopyBootsSerial()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.SerialNumber = tbBoots.SerialNumber " +
                "FROM tbBoots " +
                "WHERE tbItems.Id = tbBoots.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyBootsCondition()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Condition = tbBoots.Condition " +
                "FROM tbBoots " +
                "WHERE tbItems.Id = tbBoots.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyBootsDueDate()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.DueDate = tbBoots.DueDate " +
                "FROM tbBoots " +
                "WHERE tbItems.Id = tbBoots.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyBootsLocation()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Location = tbBoots.Location " +
                "FROM tbBoots " +
                "WHERE tbItems.Id = tbBoots.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyBoots()
        {
            bool next = CopyBootsSerial();
            if (next)
            {
                next = CopyBootsCondition();
            }
            if (next)
            {
                next = CopyBootsDueDate();
            }
            if (next)
            {
                next = CopyBootsLocation();
            }
            return next;
        }

        private bool CopyJacketsSerial()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.SerialNumber = tbJackets.SerialNumber " +
                "FROM tbJackets " +
                "WHERE tbItems.Id = tbJackets.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyJacketsCondition()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Condition = tbJackets.Condition " +
                "FROM tbJackets " +
                "WHERE tbItems.Id = tbJackets.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyJacketsDueDate()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.DueDate = tbJackets.DueDate " +
                "FROM tbJackets " +
                "WHERE tbItems.Id = tbJackets.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyJacketsLocation()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Location = tbJackets.Location " +
                "FROM tbJackets " +
                "WHERE tbItems.Id = tbJackets.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyJackets()
        {
            bool next = CopyJacketsSerial();
            if (next)
            {
                next = CopyJacketsCondition();
            }
            if (next)
            {
                next = CopyJacketsDueDate();
            }
            if (next)
            {
                next = CopyJacketsLocation();
            }
            return next;
        }

        private bool CopyPantsSerial()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.SerialNumber = tbPants.SerialNumber " +
                "FROM tbPants " +
                "WHERE tbItems.Id = tbPants.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyPantsCondition()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Condition = tbPants.Condition " +
                "FROM tbPants " +
                "WHERE tbItems.Id = tbPants.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyPantsDueDate()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.DueDate = tbPants.DueDate " +
                "FROM tbPants " +
                "WHERE tbItems.Id = tbPants.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyPantsLocation()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Location = tbPants.Location " +
                "FROM tbPants " +
                "WHERE tbItems.Id = tbPants.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyPants()
        {
            bool next = CopyPantsSerial();
            if (next)
            {
                next = CopyPantsCondition();
            }
            if (next)
            {
                next = CopyPantsDueDate();
            }
            if (next)
            {
                next = CopyPantsLocation();
            }
            return next;
        }

        private bool CopyMasksSerial()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.SerialNumber = tbMasks.SerialNumber " +
                "FROM tbMasks " +
                "WHERE tbItems.Id = tbMasks.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyMasksCondition()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Condition = tbMasks.Condition " +
                "FROM tbMasks " +
                "WHERE tbItems.Id = tbMasks.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyMasksDueDate()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.DueDate = tbMasks.DueDate " +
                "FROM tbMasks " +
                "WHERE tbItems.Id = tbMasks.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyMasksLocation()
        {
            string message = "Are you sure you want to update cereal?";
            DialogResult messageBox = MessageBox.Show(message, "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.No) { return false; }

            string query = "UPDATE tbItems " +
                "SET tbItems.Location = tbMasks.Location " +
                "FROM tbMasks " +
                "WHERE tbItems.Id = tbMasks.itemId ";


            command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();


                command.ExecuteNonQuery();
                MessageBox.Show("yummy");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return false;
            }
        }

        private bool CopyMasks()
        {
            bool next = CopyMasksSerial();
            if (next)
            {
                next = CopyMasksCondition();
            }
            if (next)
            {
                next = CopyMasksDueDate();
            }
            if (next)
            {
                next = CopyMasksLocation();
            }
            return next;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool next = CopyBoots();
            if (next)
            {
                next = CopyJackets();
            }
            if(next)
            {
                next = CopyPants();
            }
            if(next)
            {
                next = CopyMasks();
            }
        }
    }
}
