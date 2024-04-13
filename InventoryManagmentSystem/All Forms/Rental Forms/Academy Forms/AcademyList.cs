using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Academy
{
    public partial class AcademyList : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        AcademyForm parent;
        List<Item> academyList;

        public AcademyList(AcademyForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            academyList = HelperSql.AcademyFindAll(connection);
            LoadAcademies();
        }

        private void LoadAcademies()
        {
            dataGridAcademies.Rows.Clear();
            int count = 1;
            foreach(var item in academyList)
            {
                AddRow(item, count++);
            }
        }

        private void AddRow(Item item, int count)
        {
            dataGridAcademies.Rows.Add(count,
                item.GetColumnValue("Id"),
                item.GetColumnValue("Name"),
                item.GetColumnValue("ContactName"),
                item.GetColumnValue("Email"),
                item.GetColumnValue("Phone"),
                item.GetColumnValue("Street"),
                item.GetColumnValue("City"),
                item.GetColumnValue("State"),
                item.GetColumnValue("Zip")
            );
        }

        private void UpdateAcademy(DataGridViewRow row)
        {
            dataGridAcademies.Visible = false;
            AcademyForm.Academy academy = new AcademyForm.Academy();
            academy.uuid = new Guid(row.Cells["column_id"].Value.ToString());
            academy.name = row.Cells["column_name"].Value.ToString();
            academy.email = row.Cells["column_email"].Value.ToString();
            academy.phone = row.Cells["column_phone"].Value.ToString();
            academy.street = row.Cells["column_street"].Value.ToString();
            academy.city = row.Cells["column_city"].Value.ToString();
            academy.state = row.Cells["column_state"].Value.ToString();
            academy.zip = row.Cells["column_zip"].Value.ToString();
            HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new CreateAcademyForm(parent, academy));
            this.Close();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            if (string.IsNullOrEmpty(searchTerm)) 
            { 
                LoadAcademies();
                return;
            }

            int count = 1;
            foreach(var item in academyList)
            {
                if(item.GetColumnValue("Name") == $"%{searchTerm}%")
                {
                    AddRow(item, count++);
                }
            }
        }

        private void dataGridAcademies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridAcademies.Rows[e.RowIndex];
            string column = dataGridAcademies.Columns[e.ColumnIndex].Name;
            string AcademyId = row.Cells["column_id"].Value.ToString();

            parent.AcademyId = Guid.Parse(AcademyId);

            if (column == "column_update")
            {
                UpdateAcademy(row);
                return;
            }

            var parentForm = this.ParentForm as AcademyForm;

            ClassList ClassListForm = new ClassList(this.parent);
            HelperFunctions.OpenChildFormToPanel(parentForm.panelDocker, ClassListForm, this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HelperFunctions.PdfSaveDocument(WriteAcademyListToPdf);
        }

        private void WriteAcademyListToPdf(PdfDocument document)
        {
            /*  Format
                Academy: name
                Email: email@gmail.com
                Phone: 123.456.789
                Address: street, city, state, zip
            */

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

            string text = "Academy List";
            HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
            positionY += lineHeight + ExtraLineSpace;

            XFont font = new XFont("Arial", 12, XFontStyle.Regular);
            foreach (DataGridViewRow row in dataGridAcademies.Rows)
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

                    text = "Academy List";
                    HelperFunctions.PdfWriteLine(graphics, fontTitle, text, positionY);
                    positionY += lineHeight + ExtraLineSpace;
                }

                text = $"Academy: {row.Cells["column_name"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Email: {row.Cells["column_email"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Phone: {row.Cells["column_phone"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight;

                text = $"Address: {row.Cells["column_street"].Value}, {row.Cells["column_city"].Value}, {row.Cells["column_state"].Value}, {row.Cells["column_zip"].Value}";
                HelperFunctions.PdfWriteLine(graphics, font, text, positionY);
                positionY += lineHeight + ExtraLineSpace;

            }
        }       
    }
}
