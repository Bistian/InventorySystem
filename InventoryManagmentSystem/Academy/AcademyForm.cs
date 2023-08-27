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
            public Guid academyId;
            public string name;
            public DateTime start;
            public DateTime end;
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        bool minimized = false;
        public AcademyForm()
        {
            InitializeComponent();
            InitMinimizeButton();

            AcademyList ListForm = new AcademyList(this);
            HelperFunctions.openChildFormToPanel(panelDocker, ListForm);
        }

        private void InitMinimizeButton()
        {
            int height = (int)(panelLeft.Size.Height * .5) - btnRezsize.Size.Height / 2;
            int width = panelLeft.Size.Width - btnRezsize.Size.Width / 2;

            Point position = new Point(width, height);
            btnRezsize.Location = position;

            if (minimized)
            {
                btnRezsize.Text = "> p";
                labelAcademies.Visible = false;
            }
            else
            {
                btnRezsize.Text = "< p";
                labelAcademies.Visible = true;
            }
        }

        private void btnRezsize_Click(object sender, System.EventArgs e)
        {
            if (!minimized)
            {
                panelLeft.Width = panelLeft.Width / 10;
                minimized = !minimized;
            }
            else
            {
                panelLeft.Width = panelLeft.Width * 10;
                minimized = !minimized;
            }
            InitMinimizeButton();
        }

        private void btnCreateAcademy_Click(object sender, System.EventArgs e)
        {
            CreateAcademyForm AcadForm = new CreateAcademyForm(this);

            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.openChildFormToPanel(panelDocker, AcadForm, currDocked);

            labelAcademies.Text = "Academies";
        }

        private void btnAcademyList_Click(object sender, System.EventArgs e)
        {
            AcademyList ListForm = new AcademyList(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.openChildFormToPanel(panelDocker, ListForm, currDocked);

            labelAcademies.Text = "Academies";
        }

        private void btnCreateClass_Click(object sender, System.EventArgs e)
        {
            CreateClassForm ListForm = new CreateClassForm();
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.openChildFormToPanel(panelDocker, ListForm, currDocked);

            labelAcademies.Text = "Classes";
        }

        private void btnClassList_Click(object sender, System.EventArgs e)
        {
            ClassList ClassList = new ClassList(this);
            Form currDocked = panelDocker.Controls.OfType<Form>().FirstOrDefault();
            HelperFunctions.openChildFormToPanel(panelDocker, ClassList, currDocked);

            labelAcademies.Text = "Classes";
        }
    }
}
