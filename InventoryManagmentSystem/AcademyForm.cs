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
    public partial class AcademyForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public AcademyForm()
        {
            InitializeComponent();
            LoadBrands();
            LoadAcademies();
        }

        private void LoadBrands()
        {
            string query = HelperQuery.BrandsLoad();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbBrand.Items.Add(reader[2]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void LoadAcademies()
        {
            dataGridAcademies.Rows.Clear();
            string query = "SELECT * FROM tbAcademies";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while(reader.Read())
                {
                    dataGridAcademies.Rows.Add(
                        i++, reader[0], reader[1], reader[2]
                    );
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine (ex.Message);
            }
            connection.Close();

        }

        private bool ItemExists()
        {
            string query = @"
                SELECT *
                FROM tbAcademies
                WHERE Name = @Name AND
                    Brand = @Brand
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool exists = false;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                command.Parameters.AddWithValue("@Brand", cbBrand.SelectedItem.ToString());
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
                (Name, Brand)
                VALUES (@Name, @Brand)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isAdded = false;

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", tbAcademyName.Text);
                command.Parameters.AddWithValue("@Brand", cbBrand.SelectedItem.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                isAdded = true;
                LoadAcademies();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

                if(cbBrand.SelectedIndex == -1 )
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
