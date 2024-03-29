﻿using System;
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
    public partial class DeptModuleForm : Form
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

        //Initialize
        public DeptModuleForm(bool newItem = false)
        {
            InitializeComponent();
            isNewItem = newItem;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(isNewItem == true)
            {
                CreateItem();
            }
            else
            {
                UpdateItem();
            }
        }

        // Helper function: adds new item to database.
        private void CreateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this department?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbDepartment(DeptName,ContactName,Phone,Email,Address,City,State,Zip)VALUES(@DeptName,@ContactName,@Phone,@Email,@Address,@City,@State,@Zip)", con);
                    cm.Parameters.AddWithValue("@DeptName", DeptNameTxtBox.Text);
                    cm.Parameters.AddWithValue("@ContactName", DeptContactTxtBox.Text);
                    cm.Parameters.AddWithValue("@Phone", DeptPhoneTxtBox.Text);
                    cm.Parameters.AddWithValue("@Email", DeptEmailTxtBox.Text);
                    cm.Parameters.AddWithValue("@Address", DeptAddressTxtBox.Text);
                    cm.Parameters.AddWithValue("@City", DeptCityTxtBox.Text);
                    cm.Parameters.AddWithValue("@State", DeptStateTxtBox.Text);
                    cm.Parameters.AddWithValue("@Zip", DeptZipTxtBox.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Department has been successfully saved");
                    Clear();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Helper function: updates existing item in the database.
        private void UpdateItem()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Department?", "Update Department", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbDepartment SET ContactName = @ContactName,Phone = @Phone, Email = @Email, Address = @Address, City = @City, State = @State, Zip = @Zip WHERE DeptID LIKE '" + DeptNameTxtBox.Text + "' ", con);
                    cm.Parameters.AddWithValue("@ContactName", DeptContactTxtBox.Text);
                    cm.Parameters.AddWithValue("@Phone", DeptPhoneTxtBox.Text);
                    cm.Parameters.AddWithValue("@Email", DeptEmailTxtBox.Text);
                    cm.Parameters.AddWithValue("@Address", DeptAddressTxtBox.Text);
                    cm.Parameters.AddWithValue("@City", DeptCityTxtBox.Text);
                    cm.Parameters.AddWithValue("@State", DeptStateTxtBox.Text);
                    cm.Parameters.AddWithValue("@Zip", DeptZipTxtBox.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Department has been successfully updated");
                    this.Dispose();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            DeptNameTxtBox.Clear();
            DeptContactTxtBox.Clear();
            DeptPhoneTxtBox.Clear();
            DeptEmailTxtBox.Clear();
            DeptAddressTxtBox.Clear();
            DeptCityTxtBox.Clear();
            DeptStateTxtBox.Clear();
            DeptZipTxtBox.Clear();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
            SaveButton.Enabled = true;
        }

        private void CloseUserModuel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

    }
}
