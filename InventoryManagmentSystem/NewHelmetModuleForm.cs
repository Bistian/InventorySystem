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

namespace InventoryManagmentSystem
{
    public partial class NewHelmetModuleForm : Form
    {
        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
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
            cm = new SqlCommand("Select Count (*) FROM " + tableName + " WHERE SerialNumber = " + SerialNumber, con);
            con.Open();
            int count = (int)cm.ExecuteScalar();
            con.Close();
            if (count != 0)
            {
                Exists = true;
            }
            return Exists;
        }

        public void Clear()
        {
            txtBoxSerialNumber.Clear();
            comboBoxBrand.SelectedIndex = -1;
            comboBoxUsedNew.SelectedIndex = -1;
            comboBoxColor.SelectedIndex = -1;
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
                        cm = new SqlCommand("IF NOT EXISTS (SELECT * FROM tbHelmets WHERE SerialNumber = " + txtBoxSerialNumber.Text + ")"
                        + "BEGIN " +
                        "INSERT INTO tbHelmets(SerialNumber,Brand,Color,ManufactureDate,UsedNew)VALUES(@SerialNumber,@Brand,@Color,@ManufactureDate,@UsedNew)" +
                        " END", con);

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
