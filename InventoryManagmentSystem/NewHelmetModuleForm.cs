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

        public void Clear()
        {
            txtBoxSerialNumber.Clear();
            comboBoxBrand.SelectedIndex = -1;
            textBoxModel.Clear();
            comboBoxColor.SelectedIndex = -1;
            comboBoxSize.SelectedIndex = -1;
        }

        private void CloseUserModuel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
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

        //helper functions
        private void CreateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Item?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbHelmets(SerialNumber,Brand,Model,Color,Size,ManufactureDate)VALUES(@SerialNumber,@Brand,@Model,@Color,@Size,@ManufactureDate)", con);
                    cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    cm.Parameters.AddWithValue("@Model", textBoxModel.Text);
                    cm.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                    cm.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                    cm.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item has been successfully saved");
                    Clear();
                    this.Dispose();
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
                    cm = new SqlCommand("UPDATE tbHelmets SET SerialNumber = @SerialNumber,Brand = @Brand, Model = @Model, Color = @Color, Size = @Size, ManufactureDate = @ManufactureDate WHERE HelmetID LIKE '" + txtBoxSerialNumber.Text + "' ", con);
                    cm.Parameters.AddWithValue("@SerialNumber", txtBoxSerialNumber.Text);
                    cm.Parameters.AddWithValue("@Brand", comboBoxBrand.Text);
                    cm.Parameters.AddWithValue("@Model", textBoxModel.Text);
                    cm.Parameters.AddWithValue("@Color", comboBoxColor.Text);
                    cm.Parameters.AddWithValue("@Size", comboBoxSize.Text);
                    cm.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufactureDate.Text);
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
