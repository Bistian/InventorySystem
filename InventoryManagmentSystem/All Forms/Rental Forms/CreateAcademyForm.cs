using InventoryManagmentSystem.Database.Entities;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class CreateAcademyForm : Form
    {
        AcademyForm parent;
        Academy academy;
        Address address;
        Contact contact;
        bool isUpdate = false;

        public CreateAcademyForm(AcademyForm parent) 
        {
            InitializeComponent();
            this.parent = parent;

        }
        public CreateAcademyForm(AcademyForm parent, Guid academyId)
        {
            InitializeComponent();
            isUpdate = true;
            this.parent = parent;
            academy = Program.AcademyService.FindById(academyId);
            address = Program.AddressService.FindById(academy.IdAddress);
            contact = Program.ContactService.FindById(academy.IdContact);
            InitUpdate();
        }

        private void InitUpdate()
        {
            labelTitle.Text = "Update Academy";
            btnAdd.Text = "Update";
            tbAcademyName.Text = academy.Name;
            tbContactName.Text = "contact";
            tbEmail.Text = "email";
            tbPhone.Text = "phone";
            tbStreet.Text = "street";
            tbCity.Text = "city";
            cbState.Text = "state";
            tbZip.Text = "zip";

            btnResetName.Visible = true;
            btnResetName.Enabled = true;

            btnResetContactName.Visible = true;
            btnResetContactName.Enabled = true;

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
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                    command.Parameters.AddWithValue("@State", cbState.SelectedItem.ToString());
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) { exists = true; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
            return exists;
        }

        private bool AddAcademy()
        {
            string query = @"
                INSERT INTO tbAcademies
                (Name, Email, Phone, Street, City, State, Zip, ContactName)
                VALUES (@Name, @Email, @Phone, @Street, @City, @State, @Zip, @ContactName)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isAdded = false;

            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                    command.Parameters.AddWithValue("@ContactName", tbContactName.Text);
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                    command.Parameters.AddWithValue("@Street", tbStreet.Text);
                    command.Parameters.AddWithValue("@City", tbCity.Text);
                    command.Parameters.AddWithValue("@State", cbState.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Zip", tbZip.Text);
                    command.ExecuteNonQuery();
                    isAdded = true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AddErrorCheck()) { return; }

            if (isUpdate)
            {
                Program.AcademyService.Update(academy);
                HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new AcademyList(parent));
                this.Close();
            }
            else
            {
                if (AddAcademy()) 
                {
                    HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new AcademyList(parent));
                    this.Close(); 
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new AcademyList(parent));
            this.Close();
        }

        private void btnResetName_Click(object sender, EventArgs e)
        {
            tbAcademyName.Text = academy.Name;
        }

        private void btnResetEmail_Click(object sender, EventArgs e)
        {
            tbEmail.Text = contact.Email;
        }

        private void btnResetPhone_Click(object sender, EventArgs e)
        {
            tbPhone.Text = contact.PhoneNumber;
        }

        private void btnResetStreet_Click(object sender, EventArgs e)
        {
            tbStreet.Text = address.Street;
        }

        private void btnResetCity_Click(object sender, EventArgs e)
        {
            tbCity.Text = address.City;
        }

        private void btnResetZip_Click(object sender, EventArgs e)
        {
            tbZip.Text = address.Zip;
            cbState.Text = address.State;
        }

        private void btnResetContactName_Click(object sender, EventArgs e)
        {
            tbContactName.Text = contact.Name;
        }
    }
}
