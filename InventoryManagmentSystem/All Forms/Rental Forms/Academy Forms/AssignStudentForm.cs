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
    public partial class AssignStudentForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<Guid, string> academyMap = new Dictionary<Guid, string>();
        List<Dictionary<string, string>> classList;
        AcademyForm parent = null;

        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            academyMap = HelperSql.AcademyListNames(connection);
            classList = new List<Dictionary<string, string>>();
            foreach (var value in academyMap.Values)
            {
                cbAcademy.Items.Add(value);
            }
            if (parent != null)
            {
                this.parent = parent;
            }
        }

        private bool UpdateClient()
        {
            NewRentalModuleForm parent = this.Parent.Parent as NewRentalModuleForm;
            string query = @"
                UPDATE tbClients
                SET IdClass=@IdClass, Academy=@Academy
                WHERE DriversLicenseNumber=@DriversLicenseNumber
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            Guid Id = Guid.Empty;
            foreach (var item in classList)
            {
                if (item["Name"] == cbClasses.Text)
                {
                    Id = Guid.Parse(item["Id"]);
                    break;
                }
            }
            if (Id == Guid.Empty)
            {
                return false;
            }

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@DriversLicenseNumber", parent.drivers);
                command.Parameters.AddWithValue("@IdClass", Id);
                command.Parameters.AddWithValue("@Academy", cbAcademy.Text);
                command.ExecuteNonQuery();
                connection.Close();

                parent.LoadProfile(false, parent.drivers);
                this.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connection.Close();
                return false;
            }
        }

        private void cbAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid academyId = Guid.Empty;
            foreach (var key in academyMap.Keys)
            {
                if (academyMap[key] == cbAcademy.Text)
                {
                    academyId = key;
                }
            }

            if (academyId == Guid.Empty)
            {
                return;
            }

            classList.Clear();
            classList = HelperSql.ClassListByAcademy(connection, academyId);
            cbClasses.Items.Clear();
            foreach (var item in classList)
            {
                cbClasses.Items.Add(item["Name"]);
            }

            if (cbClasses.Items.Count > 0)
            {
                cbClasses.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAcademy.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                if (cbClasses.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                UpdateClient();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
