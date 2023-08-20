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
        AcademyForm parent;

        public AcademyList(AcademyForm parent)
        {
            InitializeComponent();
            this.parent = parent;
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

        private void UpdateAcademy(DataGridViewRow row)
        {
            dataGridAcademies.Visible = false;
            AcademyForm.Academy academy = new AcademyForm.Academy();
            academy.uuid = (Guid)row.Cells["column_id"].Value;
            academy.name = row.Cells["column_name"].Value.ToString();
            academy.email = row.Cells["column_email"].Value.ToString();
            academy.phone = row.Cells["column_phone"].Value.ToString();
            academy.street = row.Cells["column_street"].Value.ToString();
            academy.city = row.Cells["column_city"].Value.ToString();
            academy.state = row.Cells["column_state"].Value.ToString();
            academy.zip = row.Cells["column_zip"].Value.ToString();
            HelperFunctions.openChildFormToPanel(parent.panelDocker, new CreateAcademyForm(parent, academy));
            this.Close();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadAcademies(); }

            // SQL
            int i = 0;
            dataGridAcademies.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT * FROM tbAcademies WHERE Name LIKE '%{searchTerm}%'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                i++;
                dataGridAcademies.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[5].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void dataGridAcademies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridAcademies.Rows[e.RowIndex];
            string column = dataGridAcademies.Columns[e.ColumnIndex].Name;

            if (column == "column_update")
            {
                UpdateAcademy(row);
                return;
            }

            var parentForm = this.ParentForm as AcademyForm;

            ClassList ClassList = new ClassList();
            HelperFunctions.openChildFormToPanel(parentForm.panelDocker, ClassList, this);
        }
    }
}
