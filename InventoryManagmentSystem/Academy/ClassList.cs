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
        AcademyForm.Class selectedClass;

        public ClassList(AcademyForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            parent.labelAcademies.Text = "Classes";
            AcademyId = parent.AcademyId;
            dataGridClasses.Columns["column_start_date"].DefaultCellStyle.Format = "d";
            dataGridClasses.Columns["column_end_date"].DefaultCellStyle.Format = "d";


            LoadClasses();
            this.parent = parent;
        }

        public void LoadClasses()
        {
            dataGridClasses.Rows.Clear();
            string query;
            if (AcademyId != Guid.Empty)
            {
                query = $@"
                    SELECT c.id, a.Name, c.Name, c.StartDate, c.EndDate, c.IsFinished
                    FROM tbClasses as c 
                    Join tbAcademies as a ON c.AcademyId = a.Id
                    WHERE c.AcademyId ='{AcademyId}'
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
            }
            else
            {
                query = $@"
                    SELECT c.id, a.Name, c.Name, c.StartDate, c.EndDate, c.IsFinished
                    FROM tbClasses as c 
                    Join tbAcademies as a ON c.AcademyId = a.Id
                ";
                HelperFunctions.RemoveLineBreaksFromString(ref query);
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
                        i++,reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void UpdateClass(DataGridViewRow row)
        {
            selectedClass.uuid = (Guid)row.Cells["column_id"].Value;
            selectedClass.academyName = row.Cells["column_academy"].Value.ToString();
            selectedClass.name = row.Cells["column_name"].Value.ToString();
            selectedClass.start = (DateTime)row.Cells["column_start_date"].Value;
            selectedClass.end = (DateTime)row.Cells["column_end_date"].Value;
            HelperFunctions.openChildFormToPanel(parent.panelDocker, new CreateClassForm(parent, selectedClass));
            this.Close();
        }

        public void ChangeClassStatus(DataGridViewRow row)
        {
            bool isFinished = (bool)row.Cells["column_finished"].Value;
            Guid uuid = (Guid)row.Cells["column_id"].Value;
            string query = $@"
                UPDATE tbClasses
                SET IsFinished='{!isFinished}'
                WHERE Id='{uuid}'
            ";
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            LoadClasses();
        }

        private void dataGridClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridClasses.Rows[e.RowIndex];
            string column = dataGridClasses.Columns[e.ColumnIndex].Name;
            Guid ClassId = (Guid)row.Cells["column_id"].Value;

            if (column == "column_finished")
            {
                ChangeClassStatus(row);
            }
            else if(column == "column_update")
            {
                UpdateClass(row);
            }
            else if(column == "column_finished")
            {

            }
            else
            {
                parent.ClassId = ClassId;
                ClassRosterForm roster = new ClassRosterForm(parent);
                HelperFunctions.openChildFormToPanel(parent.panelDocker, roster, this);
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }
    }  
}
