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

        #region SQL_Variables
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        public CreateAcademyForm()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbAcademyName.Text.Length == 0 )
                {
                    throw new Exception("Need a name.");
                }

                if(cbState.SelectedIndex == -1 )
                {
                    throw new Exception("Need a brand.");
                }

                if(ItemExists())
                {
                    throw new Exception("This academy already exists.");
                }

                AddAcademy();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
