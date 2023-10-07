using InventoryManagmentSystem.Academy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class CreateAcademyForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        AcademyForm parent;
        AcademyForm.Academy academy;
        bool isUpdate = false;

        public CreateAcademyForm(AcademyForm parent) 
        {
            InitializeComponent();
            this.parent = parent;

        }
        public CreateAcademyForm(AcademyForm parent, AcademyForm.Academy academy)
        {
            InitializeComponent();
            isUpdate = true;
            this.parent = parent;
            this.academy = academy;
            InitUpdate();
        }

        private void InitUpdate()
        {
            labelTitle.Text = "Update Academy";
            btnAdd.Text = "Update";
            tbAcademyName.Text = academy.name;
            tbEmail.Text = academy.email;
            tbPhone.Text = academy.phone;
            tbStreet.Text = academy.street;
            tbCity.Text = academy.city;
            cbState.Text = academy.state;
            tbZip.Text = academy.zip;

            btnResetName.Visible = true;
            btnResetName.Enabled = true;

            btnResetEmail.Visible = true;
            btnResetEmail.Enabled = true;

            btnResetPhone.Visible = true;
            btnResetPhone.Enabled = true;

            btnResetStreet.Visible = true;
            btnResetStreet.Enabled = true;

            btnResetCity.Visible = true;
            btnResetCity.Enabled = true;

            btnResetZip.Visible = true;
            btnResetZip.Enabled = true;

            btnCancel.Visible = true;
            btnCancel.Enabled = true;
        }

        private bool ItemExists()
        {
            string query = @"
                SELECT *
                FROM tbAcademies
                WHERE Name = @Name AND
                    State = @State
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool exists = false;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                command.Parameters.AddWithValue("@State", cbState.SelectedItem.ToString());
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { exists = true; }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                exists = true;
            }
            connection.Close();
            return exists;
        }

        private bool AddAcademy()
        {
            string query = @"
                INSERT INTO tbAcademies
                (Name, Email, Phone, Street, City, State, Zip)
                VALUES (@Name, @Email, @Phone, @Street, @City, @State, @Zip)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isAdded = false;

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                command.Parameters.AddWithValue("@Email", tbEmail.Text);
                command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                command.Parameters.AddWithValue("@Street", tbStreet.Text);
                command.Parameters.AddWithValue("@City", tbCity.Text);
                command.Parameters.AddWithValue("@State", cbState.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Zip", tbZip.Text);


                connection.Open();
                command.ExecuteNonQuery();
                isAdded = true;
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connection.Close();
            }
            return isAdded;
        }

        private bool AddErrorCheck() 
        {
            try
            {
                if (tbAcademyName.Text.Length == 0)
                {
                    throw new Exception("Need a name.");
                }

                if (cbState.SelectedIndex == -1)
                {
                    throw new Exception("Select a state.");
                }
                
                if (!isUpdate)
                {
                    if (ItemExists())
                    {
                        throw new Exception("This academy already exists.");
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool UpdateAcademy()
        {
            string query = @"
                Update tbAcademies
                SET Name = @Name, Email = @Email, Phone = @Phone, Street = @Street, City = @City, State = @State, Zip = @Zip
                WHERE Id = @Id
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", academy.uuid);
                command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                command.Parameters.AddWithValue("@Email", tbEmail.Text);
                command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                command.Parameters.AddWithValue("@Street", tbStreet.Text);
                command.Parameters.AddWithValue("@City", tbCity.Text);
                command.Parameters.AddWithValue("@State", cbState.Text);
                command.Parameters.AddWithValue("@Zip", tbZip.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                connection.Close();
                Console.WriteLine($"Could not update {ex.Message}");
                return false;
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AddErrorCheck()) { return; }

            if (isUpdate)
            {
                if(!UpdateAcademy()) { return; }
                HelperFunctions.openChildFormToPanel(parent.panelDocker, new AcademyList(parent));
                this.Close();
            }
            else
            {
                if (AddAcademy()) { this.Close(); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HelperFunctions.openChildFormToPanel(parent.panelDocker, new AcademyList(parent));
            this.Close();
        }

        private void btnResetName_Click(object sender, EventArgs e)
        {
            tbAcademyName.Text = academy.name;
        }

        private void btnResetEmail_Click(object sender, EventArgs e)
        {
            tbEmail.Text = academy.email;
        }

        private void btnResetPhone_Click(object sender, EventArgs e)
        {
            tbPhone.Text = academy.phone;
        }

        private void btnResetStreet_Click(object sender, EventArgs e)
        {
            tbStreet.Text = academy.street;
        }

        private void btnResetCity_Click(object sender, EventArgs e)
        {
            tbCity.Text = academy.city;
        }

        private void btnResetZip_Click(object sender, EventArgs e)
        {
            tbZip.Text = academy.zip;
            cbState.Text = academy.state;
        }
    }
}
