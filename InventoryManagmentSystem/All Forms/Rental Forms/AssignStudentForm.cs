using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using InventoryManagmentSystem.C__Files;
using InventoryManagmentSystem.Database.Entities;
using static System.Net.Mime.MediaTypeNames;


namespace InventoryManagmentSystem
{
    public partial class AssignStudentForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<string, string> academyMap = new Dictionary<string, string>();
        List<Class> classList;
        List<Academy> academyList;
        AcademyForm parent = null;

        public AssignStudentForm(AcademyForm parent)
        {
            InitializeComponent();
            PopulateAcademyList();

            if (parent != null)
            {
                this.parent = parent;
            }
        }

        private void UpdateStudent(object sender, EventArgs e)
        {
            NewRentalModuleForm parent = this.Parent.Parent as NewRentalModuleForm;

            ComboBoxItem Class = (ComboBoxItem)cbClasses.SelectedItem;
            if (Class.ID == string.Empty)
            {
                Console.WriteLine($"Could not update student, Class ID was empty");
                return;
            }

            var student = Program.StudentService.FindByIdClient(parent.ClientId);
            student.IdClass = Guid.Parse(Class.ID);
            Program.StudentService.Update(student);
        }

        private void PopulateAcademyList()
        {
            academyList = Program.AcademyService.FindAll();
            foreach (var academy in academyList)
            {
                cbAcademy.Items.Add(academy.Name);
            }
        }

        private void cbAcademy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAcademy.SelectedIndex;
            if (index == -1) { return; }

            string name = cbAcademy.Text;
            if(classList != null) { classList.Clear(); }
            cbClasses.Items.Clear();

            var academyId = academyList[index].Id;
            classList = Program.ClassService.FindByIdAcademy(academyId);
            if(classList == null) { return; }
            string currClass;
            cbClasses.Enabled = true;
            foreach (var item in classList)
            {
                var startDate = item.StartAt;
                var endDate = item.EndAt;
                var startyear = startDate.Year;
                var startmonth = startDate.Month;
                var startday = startDate.Day;

                if (endDate > DateTime.Now)
                {
                    var endyear = endDate.Year;
                    var endmonth = endDate.Month;
                    var endday = endDate.Day;

                    currClass = item.Name + $" {startmonth}/{startday}/{startyear} - {endmonth}/{endday}/{endyear}";
                    cbClasses.Items.Add(new ComboBoxItem(item.Id.ToString(), currClass));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAcademy.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                if (cbClasses.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                UpdateStudent(sender,e);
                

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
