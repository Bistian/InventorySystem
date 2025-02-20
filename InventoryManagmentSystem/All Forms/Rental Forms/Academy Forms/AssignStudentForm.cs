using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AssignStudentForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<string, string> academyMap = new Dictionary<string, string>();
        List<Item> classList;
        AcademyForm parent = null;

        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            academyMap = HelperSql.AcademyListNames(connection);
            classList = new List<Item>();
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

            // TODO: Move SQL out of this file.
            string query = @"
                UPDATE tbClients
                SET IdClass=@IdClass, Academy=@Academy
                WHERE Id=@Id
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            string Id = string.Empty;
            foreach (var item in classList)
            {
                if (item.GetColumnValue("Name") == cbClasses.Text)
                {
                    Id = item.GetColumnValue("Id");
                    break;
                }
            }
            if (Id == string.Empty)
            {
                return false;
            }

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Id", parent.ClientId);
                command.Parameters.AddWithValue("@IdClass", Id);
                command.Parameters.AddWithValue("@Academy", cbAcademy.Text);
                command.ExecuteNonQuery();
                connection.Close();

                parent.LoadProfile(parent.drivers,parent.currentUser);
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
            string academyId = "";
            foreach (var key in academyMap.Keys)
            {
                if (academyMap[key] == cbAcademy.Text)
                {
                    academyId = key;
                }
            }

            if (academyId == "")
            {
                return;
            }

            classList.Clear();
            classList = HelperSql.ClassFindByAcademy(connection, academyId);
            cbClasses.Items.Clear();
            foreach (var item in classList)
            {
                cbClasses.Items.Add(item.GetColumnValue("Name"));
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
