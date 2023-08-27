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
    public partial class ClassList : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<Guid, string> academyMap = new Dictionary<Guid, string>();
        Guid AcademyId;
        AcademyForm parent;
        public ClassList(AcademyForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            parent.labelAcademies.Text = "Classes";
            AcademyId = parent.AcademyId;
            dataGridClasses.Columns["column_start_date"].DefaultCellStyle.Format = "d";
            dataGridClasses.Columns["column_end_date"].DefaultCellStyle.Format = "d";


            LoadClasses();
        }

        public void LoadClasses()
        {
            dataGridClasses.Rows.Clear();
            string query;
            if (AcademyId != Guid.Empty)
            {
                query = "SELECT * FROM tbClasses WHERE AcademyId ='" + AcademyId + "' ";
            }
            else
            {
                query = "SELECT * FROM tbClasses";
            }
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    dataGridClasses.Rows.Add(
                        i++, reader[1], reader[2], reader[3], reader[4], reader[5]
                    );
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
