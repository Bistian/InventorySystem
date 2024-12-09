using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
using static InventoryManagmentSystem.Academy.AcademyForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace InventoryManagmentSystem.Academy
{
    public partial class ClassList : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        //Creating command
        SqlCommand command = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr2;
        Dictionary<Guid, string> academyMap = new Dictionary<Guid, string>();
        Guid AcademyId;
        AcademyForm parent;
        AcademyForm.Class selectedClass;

        public ClassList(AcademyForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            AcademyId = parent.AcademyId;
            dataGridClasses.Columns["column_start_date"].DefaultCellStyle.Format = "d";
            dataGridClasses.Columns["column_end_date"].DefaultCellStyle.Format = "d";

            checkBoth.Checked = true;
            LoadClasses();
            initLable();
            this.parent = parent;
        }

        public void LoadClasses()
        {
            HelperSql.ClassFindAll(connection, dataGridClasses);
        }

        public void initLable()
        {
            if (parent.AcademyId != Guid.Empty)
            {
                string query = $"SELECT Name FROM tbAcademies WHERE Id = '{parent.AcademyId}'";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labelAcademyName.Text = $"{reader[0]} class list";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
            else
            {
                labelAcademyName.Text = "All Classes";
            }
        }

        private void UpdateClass(DataGridViewRow row)
        {
            selectedClass.uuid = (Guid)row.Cells["column_id"].Value;
            selectedClass.academyName = row.Cells["column_academy"].Value.ToString();
            selectedClass.name = row.Cells["column_name"].Value.ToString();
            selectedClass.start = (DateTime)row.Cells["column_start_date"].Value;
            selectedClass.end = (DateTime)row.Cells["column_end_date"].Value;
            HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new CreateClassForm(parent, selectedClass));
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
            if (e.RowIndex < 0) { return; }
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
                HelperFunctions.OpenChildFormToPanel(parent.panelDocker, roster, this);
            }
        }

        private string GetAcademyName(Guid SearchId)
        {
            SqlConnection connection2 = new SqlConnection(connectionString);
            //Creating command
            SqlCommand command2 = new SqlCommand();


            string AcademyName = "";
            string query = $@"
                    SELECT Name FROM tbAcademies WHERE Id = '{SearchId}'
                    ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                command2 = new SqlCommand(query, connection2);
                connection2.Open();
                dr2 = command2.ExecuteReader();
                while (dr2.Read())
                {
                    AcademyName = dr2[0].ToString();
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
            return AcademyName;
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadClasses(); }

            // SQL
            int i = 0;
            dataGridClasses.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT Id, AcademyId, Name, StartDate, EndDate, IsFinished FROM tbClasses WHERE Name LIKE '%{searchTerm}%' AND  AcademyId ='{AcademyId}'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                i++;
                dataGridClasses.Rows.Add(i, reader[0], GetAcademyName((Guid)reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HelperFunctions.PdfSaveDocument(WriteClassListToPdf);
        }

        private void WriteClassListToPdf(PdfDocument document)
        {
            // Add a new page to the PDF
            PdfPage page = document.AddPage();
            // Get the graphics object of the PDF page
            XGraphics graphics = XGraphics.FromPdfPage(page);

            const int startY = 50;
            int positionY = startY;
            int ExtraLineSpace = 10;

            XFont fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
            double maxPageHeight = page.Height.Point;
            int lineHeight = (int)fontTitle.Height;

            string text = $"{labelAcademyName.Text}";
            HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
            positionY += lineHeight + ExtraLineSpace;

            XFont font = new XFont("Arial", 12, XFontStyle.Regular);
            foreach(DataGridViewRow row in dataGridClasses.Rows)
            {
                if (!row.Visible)
                {
                    continue;
                }
                // Check if adding the next line exceeds the page height
                if (positionY + (lineHeight * 4) > maxPageHeight)
                {
                    // Add a new page
                    page = document.AddPage();
                    graphics = XGraphics.FromPdfPage(page);
                    positionY = startY;

                    text = $"{labelAcademyName.Text}";
                    HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
                    positionY += lineHeight + ExtraLineSpace;
                }

                text = $"Class: {row.Cells["column_name"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Start: {row.Cells["column_start_date"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"End: {row.Cells["column_end_date"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight + ExtraLineSpace;
            }
        }

        private void CheckBox_Checked_Changed(object sender, EventArgs e)
        {
            // Cast the sender to a CheckBox
            var currentCheckBox = sender as System.Windows.Forms.CheckBox;

            if (currentCheckBox != null && currentCheckBox.Checked)
            {
                // Uncheck all other checkboxes
                if (currentCheckBox != checkActive) checkActive.Checked = false;
                if (currentCheckBox != checkInactive) checkInactive.Checked = false;
                if (currentCheckBox != checkBoth) checkBoth.Checked = false;
            }
            else if (!checkActive.Checked && !checkInactive.Checked && !checkBoth.Checked)
            {
                currentCheckBox.Checked = true;
            }

            if (currentCheckBox.Text == "Active")
            {
                HelperSql.ClassFindByStatus(connection, dataGridClasses, true);
            }
            else if(currentCheckBox.Text == "Inactive")
            {
                HelperSql.ClassFindByStatus(connection, dataGridClasses, false);
            }
            else if (currentCheckBox.Text == "Both")
            {
                LoadClasses();
            }
        }
    }  
}
