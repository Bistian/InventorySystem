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
using Microsoft.Win32.SafeHandles;
using System.Configuration;

namespace InventoryManagmentSystem
{
    public partial class UserModuleForm : Form
    {
        #region SQL_Variables
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection con = new SqlConnection(connectionString);
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Flag to switch between adding new user or updating.
        bool isNewUser;

        #endregion SQL_Variables

        //Initialize
        public UserModuleForm(bool newUser = false)
        {
            InitializeComponent();
            PasswordTxt.UseSystemPasswordChar = true;
            PasswordConfTxt.UseSystemPasswordChar = true;
            isNewUser = newUser;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(isNewUser)
            {
                CreateNewUser();
            }
            else
            {
                UpdateUser();
            }
        }

        // Creates a new user in the database.
        private void CreateNewUser()
        {
            try
            {
                if (PasswordTxt.Text != PasswordConfTxt.Text)
                {
                    MessageBox.Show("Passwords did not Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to save this user?", "Saving User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbUser(username,password,fullname)VALUES(@username,@password,@fullname)", con);
                    cm.Parameters.AddWithValue("@username", UserNameTxt.Text);
                    cm.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    cm.Parameters.AddWithValue("@fullname", NameTxtBox.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully saved");
                    Clear();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Update an existing user in the database.
        private void UpdateUser()
        {
            try
            {
                if (PasswordTxt.Text != PasswordConfTxt.Text)
                {
                    MessageBox.Show("Passwords did not Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Update User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUser SET password = @password,fullname = @fullname WHERE username LIKE '" + UserNameTxt.Text + "' ", con);
                    cm.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    cm.Parameters.AddWithValue("@fullname", NameTxtBox.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully updated");
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

        public void Clear()
        {
            if (isNewUser == true)
            {
                UserNameTxt.Clear();
            }

            PasswordTxt.Clear();
            PasswordConfTxt.Clear();
            NameTxtBox.Clear();
        }

        // Hide password.
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == false)
            {
                PasswordTxt.UseSystemPasswordChar = true;
                PasswordConfTxt.UseSystemPasswordChar = true;
            }
            else
            {
                PasswordTxt.UseSystemPasswordChar = false;
                PasswordConfTxt.UseSystemPasswordChar = false;
            }
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
