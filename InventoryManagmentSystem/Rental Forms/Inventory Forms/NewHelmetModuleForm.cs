using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryManagmentSystem
{
    public partial class NewHelmetModuleForm : Form
    {
        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        bool isNewItem;
        #endregion SQL_Variables

        public NewHelmetModuleForm(bool newItem = false)
        {
            InitializeComponent();
            isNewItem = newItem;
        }

        private bool CheckIfExists(string tableName, string SerialNumber)
        {
            bool Exists = false;

            cm = new SqlCommand($"SELECT Count (*) FROM {tableName} WHERE SerialNumber = @SerialNumber", con);
            cm.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            con.Open();
            object result = cm.ExecuteScalar();

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

            con.Close();

            return Exists;
        }

        public void Clear()
        {
            txtBoxSerialNumber.Clear();
            comboBoxBrand.SelectedIndex = -1;
            comboBoxUsedNew.SelectedIndex = -1;
            comboBoxColor.SelectedIndex = -1;
            dateTimePickerManufactureDate.Value = DateTime.Today;
        }

        //helper functions
        private void CreateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Item?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool exists = CheckIfExists("tbHelmets", txtBoxSerialNumber.Text);
                    if (!exists)
                    {
                        cm = new SqlCommand(
                            "INSERT INTO tbHelmets(SerialNumber,Brand,UsedNew,Color,ManufactureDate)" +
                            "VALUES(@SerialNumber,@Brand,@UsedNew,@Color,@ManufactureDate)", con);

                        cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                        cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                        cm.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                        cm.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                        cm.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Item has been successfully saved");
                        Clear();
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Serial Number already in use");

                }
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
                    cm = new SqlCommand("UPDATE tbHelmets SET SerialNumber = @SerialNumber,Brand = @Brand, Color = @Color, ManufactureDate = @ManufactureDate, UsedNew = @UsedNew WHERE HelmetID LIKE '" + txtBoxSerialNumber.Text + "' ", con);
                    cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    cm.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                    cm.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                    cm.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item has been successfully updated");
                    this.Dispose();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxSerialNumber.Text) &&
       !string.IsNullOrEmpty(comboBoxBrand.Text) &&
        !string.IsNullOrEmpty(comboBoxUsedNew.Text) &&
       !string.IsNullOrEmpty(comboBoxColor.Text))
            {
                //if (isNewItem == true)
                //{
                CreateItem();
                //}
                //else
                //{
                //    UpdateItem();
                //}
            }
            else
            {
                MessageBox.Show("Please fill the required fields");
            }
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
