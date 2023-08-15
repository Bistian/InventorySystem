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
    public partial class AcademyList : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        #region SQL_Variables
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        public AcademyList()
        {
            InitializeComponent();
            LoadAcademies();
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
                while (reader.Read())
                {
                    dataGridAcademies.Rows.Add(
                        i++, reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();

        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadAcademies(); }

            // SQL
            int i = 0;
            dataGridAcademies.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbAcademies WHERE Name LIKE '%" + searchTerm + "%'", connection);
            connection.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridAcademies.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[5].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
            dr.Close();
            connection.Close();
        }
    }
}
