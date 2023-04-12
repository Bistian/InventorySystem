using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class NewJacketModuleForm : Form
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

        public NewJacketModuleForm(bool newItem = false)
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
            textBoxModel.Clear();
            comboBoxSize.SelectedIndex = -1;
        }

        private void CreateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Item?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool exists = CheckIfExists("tbJackets", txtBoxSerialNumber.Text);
                    if (!exists)
                    {
                        cm = new SqlCommand("INSERT INTO tbJackets(SerialNumber,Brand,Model,Size,ManufactureDate)VALUES(@SerialNumber,@Brand,@Model,@Size,@ManufactureDate)", con);
                        cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                        cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                        cm.Parameters.AddWithValue("@Model", textBoxModel.Text);
                        cm.Parameters.AddWithValue("@Size", comboBoxSize.Text);
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
                    cm = new SqlCommand("UPDATE tbJackets SET SerialNumber = @SerialNumber,Brand = @Brand, Model = @Model, Size = @Size, ManufactureDate = @ManufactureDate WHERE JacketID LIKE '" + txtBoxSerialNumber.Text + "' ", con);
                    cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    cm.Parameters.AddWithValue("@Model", textBoxModel.Text);
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxSerialNumber.Text) && !string.IsNullOrEmpty(textBoxModel.Text) &&
           !string.IsNullOrEmpty(comboBoxBrand.Text) &&
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
    }
}
