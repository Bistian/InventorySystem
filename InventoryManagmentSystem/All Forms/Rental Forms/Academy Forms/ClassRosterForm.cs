using Microsoft.Office.Interop.Excel;
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
using System.Xml.Linq;
using static InventoryManagmentSystem.Academy.AcademyForm;

namespace InventoryManagmentSystem.Academy
{
    public partial class ClassRosterForm : Form
    {


        #region SQL_Variables
        //Database Path
        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        #endregion SQL_Variables

        AcademyForm parent;
        public ClassRosterForm(AcademyForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            LoadStudents();
            initLable();
        }

        private void initLable()
        {
            if (parent.ClassId != Guid.Empty)
            {
                string query = $@"
                    SELECT a.Name, c.Name 
                    FROM tbClasses AS c 
                    JOIN tbAcademies AS a 
                        ON a.Id = c.AcademyId 
                    WHERE c.Id = '{parent.ClassId}'";
                HelperFunctions.RemoveLineBreaksFromString(ref query);

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        labelTitle.Text = $"{reader[0]} {reader[1]} Student List";
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
                labelTitle.Text = "All students";
            }
        }

        private void LoadStudents()
        {
            string query = $"SELECT DriversLicenseNumber, Name, Phone, Email FROM tbClients WHERE IdClass = '{parent.ClassId}'";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    ++index;
                    dataGridStudents.Rows.Add(index, reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        private void dataGridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridStudents.Rows[e.RowIndex];
            string column = dataGridStudents.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0) { return; }

            string clientName = row.Cells["column_student"].Value.ToString();
            string licence = row.Cells["column_drivers_license"].Value.ToString();

            string message = "Are you sure you want to select this client";
            if (!HelperFunctions.YesNoMessageBox(message, "Continue"))
            {
                return;
            }

            var parentForm = this.ParentForm.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(licence, clientName);
                parentForm.openChildForm(Profile);
                this.parent.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) { LoadStudents(); }

            // SQL
            int i = 0;
            dataGridStudents.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT DriversLicenseNumber, Name, Phone, Email FROM tbClients WHERE Name LIKE '%{searchTerm}%' AND  IdClass ='{this.parent.ClassId}'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                i++;
                dataGridStudents.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelperFunctions.PdfSaveDocument(WriteRosterToPdf);
        }

        private void WriteRosterToPdf(PdfDocument document)
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

            string text = $"{labelTitle.Text}";
            HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
            positionY += lineHeight + ExtraLineSpace;

            XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);
            foreach (DataGridViewRow row in dataGridStudents.Rows)
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

                    text = $"{labelTitle.Text}";
                    HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
                    positionY += lineHeight + ExtraLineSpace;
                }

                text = $"Student: {row.Cells["column_student"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Phone: {row.Cells["column_phone"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Email: {row.Cells["column_email"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight + ExtraLineSpace;
            }
        }
    }
}
