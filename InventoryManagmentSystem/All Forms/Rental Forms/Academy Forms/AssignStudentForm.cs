using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using static InventoryManagmentSystem.Academy.AcademyForm;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace InventoryManagmentSystem.Academy
{
    public partial class AssignStudentForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<string, string> academyMap = new Dictionary<string, string>();
        List<Item> classList;
        List<Item> academyList;
        AcademyForm parent = null;

        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            PopulateAcademyList();
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
        private void PopulateAcademyList()
        {
            academyList = HelperSql.AcademyFindAll(connection);
            foreach (var academy in academyList)
            {
                cbAcademy.Items.Add(academy.GetColumnValue("Name"));
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
            string ClassName = Regex.Replace(cbClasses.Text, @"\s\d{1,2}/\d{1,2}/\d{4}\s-\s\d{1,2}/\d{1,2}/\d{4}$", "");
            foreach (var item in classList)
            {
                if (item.GetColumnValue("Name") == ClassName)
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
                MessageBox.Show("IAcademy Successfully Updated!.");
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
            cbClasses.Enabled = true;
            int index = cbAcademy.SelectedIndex;
            if (index == -1) { return; }

            string name = cbAcademy.Text;
            if (classList != null) { classList.Clear(); }
            cbClasses.Items.Clear();

            var academyId = academyList[index].GetColumnValue("Id");
            classList = HelperSql.ClassListByAcademy(connection, academyId);
            if (classList == null) { return; }
            string currClass;
            foreach (var item in classList)
            {
                string startDate = item.GetColumnValue("StartDate");
                string endDate = item.GetColumnValue("EndDate");
                var StartDateFinal = DateTime.Parse(startDate);
                var startyear = StartDateFinal.Year;
                var startmonth = StartDateFinal.Month;
                var startday = StartDateFinal.Day;

                var EndDateFinal = DateTime.Parse(endDate);
                var endyear = EndDateFinal.Year;
                var endmonth = EndDateFinal.Month;
                var endday = EndDateFinal.Day;

                currClass = item.GetColumnValue("Name") + $" {startmonth}/{startday}/{startyear} - {endmonth}/{endday}/{endyear}";
                cbClasses.Items.Add(currClass);
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
