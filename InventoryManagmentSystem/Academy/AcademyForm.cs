using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AcademyForm : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        #region SQL_Variables
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        bool minimized = false;
        public AcademyForm()
        {
            InitializeComponent();
            InitMinimizeButton();

            AcademyList ListForm = new AcademyList();
            HelperFunctions.openChildFormToPanel(panelDocker, ListForm);
        }

        private void InitMinimizeButton()
        {
            int height = (int)(panelLeft.Size.Height * .5) - btnRezsize.Size.Height / 2;
            int width = panelLeft.Size.Width - btnRezsize.Size.Width / 2;

            Point position = new Point(width, height);
            btnRezsize.Location = position;

            if(minimized)
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
            CreateAcademyForm AcadForm = new CreateAcademyForm();
            HelperFunctions.openChildFormToPanel(panelDocker, AcadForm);
            //need to close previous form
        }

        private void btnAcademyList_Click(object sender, System.EventArgs e)
        {
            AcademyList ListForm = new AcademyList();
            HelperFunctions.openChildFormToPanel(panelDocker, ListForm);
            //need to close previous form
        }
    }
}
