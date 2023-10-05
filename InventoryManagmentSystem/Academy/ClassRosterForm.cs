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

namespace InventoryManagmentSystem.Academy
{
    public partial class ClassRosterForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        AcademyForm parent;
        public ClassRosterForm(AcademyForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            LoadStudents();
            initLable();
        }

        private void initLable()
        {
            if (parent.ClassId != Guid.Empty)
            {
                string query = $@"
                    SELECT a.Name, c.Name 
                    FROM tbClasses AS c 
                    JOIN tbAcademies AS a 
                        ON a.Id = c.AcademyId 
                    WHERE c.Id = '{parent.ClassId}'";
                HelperFunctions.RemoveLineBreaksFromString(ref query);

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labelAcademyName.Text = $"{reader[0]} {reader[1]} student list";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
            else
            {
                labelAcademyName.Text = "All students";
            }
        }
        private void LoadStudents()
        {
            string query = $"SELECT DriversLicense, Name, Phone, Email FROM tbClients WHERE IdClass = '{parent.ClassId}'";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    ++index;
                    dataGridStudents.Rows.Add(index, reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }
    }
}
