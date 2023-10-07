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
        //Creatinng Reader
        SqlDataReader dr2;
        SqlDataReader dr3;
        AcademyForm parent = null;
        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            academyMap = HelperDatabaseCall.AcademyListNames(connection);
            foreach (var value in academyMap.Values)
            {
                cbAcademy.Items.Add(value);
            }
            if(parent != null)
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
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@DriversLicenseNumber", parent.drivers);
                command.Parameters.AddWithValue("@IdClass", GetClassId(cbClasses.Text));
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

        private Guid GetAcademyName(string name)
        {
            SqlConnection connection3 = new SqlConnection(connectionString);
            //Creating command
            //Creating command
            SqlCommand command3 = new SqlCommand();


            Guid AcademyId = Guid.Empty;
            string query = $@"
                    SELECT Id FROM tbAcademies WHERE Name = '{name}'
                    ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                command3 = new SqlCommand(query, connection3);
                connection3.Open();
                dr3 = command3.ExecuteReader();
                while (dr3.Read())
                {
                    AcademyId = (Guid)dr3[0];
                }
                dr3.Close();
                connection3.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                dr3.Close();
                connection3.Close();
            }
            return AcademyId;
        }

        private Guid GetClassId(string name)
        {
            SqlConnection connection2 = new SqlConnection(connectionString);
            //Creating command
            SqlCommand command2 = new SqlCommand();


            Guid ClassId =Guid.Empty;
            string query = $@"
                    SELECT Id FROM tbClasses WHERE Name = '{name}'
                    AND AcademyId = '{GetAcademyName(cbAcademy.Text)}'
                    ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                command2 = new SqlCommand(query, connection2);
                connection2.Open();
                dr2 = command2.ExecuteReader();
                while (dr2.Read())
                {
                    ClassId = (Guid)dr2[0];
                }
                dr2.Close();
                connection2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                dr2.Close();
                connection2.Close();
            }
            return ClassId;
        }

        private void cbAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid academyId = Guid.Empty;
            foreach(var key in academyMap.Keys)
            {
                if (academyMap[key] == cbAcademy.Text)
                {
                    academyId = key;
                }
            }

            if(academyId == Guid.Empty)
            {
                return;
            }

            Dictionary<Guid, string> classMap = HelperDatabaseCall.ClassListNames(connection, academyId);
            cbClasses.Items.Clear();
            foreach(var value in classMap.Values)
            {
                cbClasses.Items.Add(value);
            }

            if(cbClasses.Items.Count > 0)
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
