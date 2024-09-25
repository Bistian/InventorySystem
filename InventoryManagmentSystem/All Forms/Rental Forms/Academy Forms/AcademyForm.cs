using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AcademyForm : Form
    {

        public Guid AcademyId;
        public Guid ClassId;
        public struct Academy
        {
            public Guid uuid;
            public string name;
            public string contactName;
            public string email;
            public string phone;
            public string street;
            public string city;
            public string state;
            public string zip;
        }

        public struct Class
        {
            public Guid uuid;
            public string academyName;
            public string name;
            public DateTime start;
            public DateTime end;
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public AcademyForm()
        {
            InitializeComponent();

            AcademyList ListForm = new AcademyList(this);
            HelperFunctions.OpenChildFormToPanel(panelDocker, ListForm);
        }

        private void btnCreateAcademy_Click(object sender, System.EventArgs e)
        {
            CreateAcademyForm AcadForm = new CreateAcademyForm(this);

            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.OpenChildFormToPanel(panelDocker, AcadForm, currDocked);
        }

        private void btnAcademyList_Click(object sender, System.EventArgs e)
        {
            AcademyList ListForm = new AcademyList(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.OpenChildFormToPanel(panelDocker, ListForm, currDocked);
        }

        private void btnCreateClass_Click(object sender, System.EventArgs e)
        {
            CreateClassForm ListForm = new CreateClassForm(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.OpenChildFormToPanel(panelDocker, ListForm, currDocked);
        }

        private void btnClassList_Click(object sender, System.EventArgs e)
        {
            AcademyId = Guid.Empty;
            ClassList ClassList = new ClassList(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.OpenChildFormToPanel(panelDocker, ClassList, currDocked);
        }

        private void btnAssignStudent_Click(object sender, EventArgs e)
        {
            AcademyId = Guid.Empty;
            AssignStudentForm ClassList = new AssignStudentForm(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.OpenChildFormToPanel(panelDocker, ClassList, currDocked);
        }
    }
}
