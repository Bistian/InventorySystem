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
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        bool isNewItem;
        #endregion SQL_Variables

        public NewBootModuleForm(bool newItem = false)
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
            comboBoxMaterial.SelectedIndex = -1;
            comboBoxSize.SelectedIndex = -1;
            dateTimePickerManufactureDate.Value = DateTime.Today;
        }

        private void CreateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Item?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool exists = CheckIfExists("tbBoots", txtBoxSerialNumber.Text);
                    if (!exists)
                    {
                        cm = new SqlCommand(
                           "INSERT INTO tbBoots(SerialNumber,Brand,UsedNew,Material,Size,ManufactureDate)" +
                           "VALUES(@SerialNumber,@Brand,@UsedNew,@Material,@Size,@ManufactureDate)", con);
                        cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                        cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                        cm.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                        cm.Parameters.AddWithValue("@Material", comboBoxMaterial.Text);
                        cm.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                        cm.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Value.Date);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item has been successfully saved");
                        Clear();
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Serial Number already in the system");
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
                    cm = new SqlCommand("UPDATE tbBoots SET SerialNumber = @SerialNum,Brand = @Brand, UsedNew = @UsedNew, Material = @Material, Size = @Size, ManufactureDate = @ManufactureDate WHERE BootID LIKE '" + txtBoxSerialNumber.Text + "' ", con);
                    cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    cm.Parameters.AddWithValue("@UsedNew", comboBoxUsedNew.Text);
                    cm.Parameters.AddWithValue("@Material", comboBoxMaterial.Text);
                    cm.Parameters.AddWithValue("@Size", comboBoxSize.Text);
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxSerialNumber.Text) && 
                !string.IsNullOrEmpty(comboBoxUsedNew.Text) &&
            !string.IsNullOrEmpty(comboBoxBrand.Text) &&
            !string.IsNullOrEmpty(comboBoxMaterial.Text) &&
            !string.IsNullOrEmpty(comboBoxSize.Text))
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
