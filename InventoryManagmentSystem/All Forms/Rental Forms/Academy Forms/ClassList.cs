using Microsoft.Office.Interop.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class ClassList : Form
    {
        //Creating command
        private SqlCommand command = new SqlCommand();

        private Guid AcademyId;
        private AcademyForm parent;
        private AcademyForm.Class selectedClass;

        public ClassList(AcademyForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            AcademyId = parent.AcademyId;
            checkBoth.Checked = true;
            LoadClasses();
            initLable();
            this.parent = parent;
        }

        public void LoadClasses()
        {
            // SQL
            int i = 0;
            dataGridClasses.Rows.Clear();
            string query = $"SELECT Id, AcademyId, Name, StartDate, EndDate, IsFinished FROM tbClasses";
            if (AcademyId != Guid.Empty)
            {
                query = $"SELECT Id, AcademyId, Name, StartDate, EndDate, IsFinished FROM tbClasses WHERE AcademyId LIKE '%{AcademyId}%'";
            }
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        i++;
                        dataGridClasses.Rows.Add(i, reader[0], reader[1].ToString(), GetAcademyName((Guid)reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }

            }
            HelperFunctions.DataGridFormatDateColumn(dataGridClasses, "column_start_date");
            HelperFunctions.DataGridFormatDateColumn(dataGridClasses, "column_end_date");
        }

        public void initLable()
        {
            if (parent.AcademyId != Guid.Empty)
            {
                string query = $"SELECT Name FROM tbAcademies WHERE Id = '{parent.AcademyId}'";
                using (var connection = new SqlConnection(Program.ConnectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            labelAcademyName.Text = $"{reader[0]} class list";
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    finally { connection.Close(); }
                }
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
            selectedClass.start = DateTime.Parse(row.Cells["column_start_date"].Value.ToString());
            selectedClass.end = DateTime.Parse(row.Cells["column_end_date"].Value.ToString());
            HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new CreateClassForm(parent, selectedClass));
            this.Close();
        }

        public void ChangeClassStatus(DataGridViewRow row)
        {
            //this function does not work
            bool isFinished = Convert.ToBoolean(row.Cells["column_finished"].Value);
            Guid uuid = (Guid)row.Cells["column_id"].Value;
            string query = $@"
                UPDATE tbClasses
                SET IsFinished='{!isFinished}'
                WHERE Id='{uuid}'
            ";
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
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
            else if (column == "column_update")
            {
                UpdateClass(row);
            }
            else if (column == "column_finished")
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
            string AcademyName = "";
            string query = $@"
                    SELECT Name FROM tbAcademies WHERE Id = '{SearchId}'
                    ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AcademyName = reader[0].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
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
            string query = $"SELECT Id, AcademyId, Name, StartDate, EndDate, IsFinished FROM tbClasses WHERE Name LIKE '%{searchTerm}%'";
            if (AcademyId != Guid.Empty)
            {
                query = $"SELECT Id, AcademyId, Name, StartDate, EndDate, IsFinished FROM tbClasses WHERE Name LIKE '%{searchTerm}%' AND AcademyId LIKE '%{AcademyId}%'";
            }

            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        i++;
                        dataGridClasses.Rows.Add(i, reader[0], reader[1].ToString(), GetAcademyName((Guid)reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
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

            XFont fontTitle = new XFont("Arial", 16, XFontStyleEx.Bold);
            double maxPageHeight = page.Height.Point;
            int lineHeight = (int)fontTitle.Height;

            string text = $"{labelAcademyName.Text}";
            HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
            positionY += lineHeight + ExtraLineSpace;

            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);
            foreach (DataGridViewRow row in dataGridClasses.Rows)
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
                //this function does not work
                //HelperSql.ClassFindByStatus(connection, dataGridClasses, true);

                string columnName = "column_finished";

                foreach (DataGridViewRow row in dataGridClasses.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[columnName].Value))
                    {
                        row.Visible = true; // show the row
                    }
                    else
                    {
                        row.Visible = false; // Hide the row
                    }
                }
            }
            else if (currentCheckBox.Text == "Inactive")
            {
                //this function does not work
                //HelperSql.ClassFindByStatus(connection, dataGridClasses, false);

                string columnName = "column_finished";

                foreach (DataGridViewRow row in dataGridClasses.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[columnName].Value))
                    {
                        row.Visible = false; // show the row
                    }
                    else
                    {
                        row.Visible = true; // Hide the row
                    }
                }
            }
            else if (currentCheckBox.Text == "Both")
            {
                LoadClasses();
            }
        }
    }
}
