using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;


namespace InventoryManagmentSystem
{
    /*TODO: Delete columns if changing selected table.*/
    public partial class ExcelImportForm : Form
    {
        #region SQL_Variables
        //Database Path
        static string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\dbMS.mdf;");
        //Creating command
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + dbPath + " Integrated Security=True;Connect Timeout=30");
        //Creating command
        SqlCommand cm = new SqlCommand();
        //Creatinng Reader
        SqlDataReader dr;
        #endregion SQL_Variables

        List<TextBox> listTextBox = new List<TextBox>();
        List<string> listColumns = new List<string>();
        Excel.Application excelApp = null;
        string excelFileName = "";
        int headerRow = -1;
        int selectedWorksheet = 1;

        public ExcelImportForm()
        {
            InitializeComponent();
        }

        private void ExcelImport_Load(object sender, EventArgs e)
        {
            comboBoxTbSelect.Items.Add("Pants");
            comboBoxTbSelect.Items.Add("Jackets");

            // Keep it disabled until a proper Excel file has been selected.
            comboBoxTbSelect.Enabled = false;
        }

        // Select Excel file.
        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Release memory if needed and clean variables.
            if (excelApp != null)
            {
                ClearExcelVar();
            }

            // Make a new dialog to select Excel file.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelFileName = openFileDialog.FileName;

                // Create a new Excel Application object
                excelApp = new Excel.Application();
                excelApp.Visible = false;

                // Open the selected workbook
                Excel.Workbook workbook = excelApp.Workbooks.Open(excelFileName);

                // Get all worksheet names available in the selected Excel file.
                List<string> worksheetNames = new List<string>();
                foreach (Excel.Worksheet worksheet in workbook.Worksheets)
                {
                    worksheetNames.Add(worksheet.Name);
                }

                // Get user prompt initialized.
                var promptForm = new ExcelUserPromptForm(worksheetNames);

                // Subscribe to the event inside of promptForm.
                promptForm.userPrompt += (s, arguments) =>
                {
                    // Get the selected item and numeric value from the event arguments
                    selectedWorksheet = arguments.selectedWorksheet;
                    headerRow = arguments.selectedRow;
                };

                // This will update the selectedWorksheet and headerRow when the user is done.
                promptForm.ShowDialog();

                if(selectedWorksheet >= 0 && headerRow > 0) 
                { 
                    comboBoxTbSelect.Enabled = true; 
                }

                workbook.Close();
            }
        }

        /* Make a list with the name of all availabe column names.
         * headerRow: Row in which the column names can be found.
         */
        private void FindColumnNames()
        {
            if (selectedWorksheet < 0 || headerRow < 1) { return; }

            // Open the selected workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFileName);

            // Get the first worksheet
            Excel.Worksheet worksheet = workbook.Sheets[selectedWorksheet];
            worksheet.Select();

            // Loop through the cells in the headerRow
            int col = 1;
            while(true)
            {
                try
                {
                    var v = (worksheet.Cells[headerRow, col] as Excel.Range).Value;
                    if(v == null) { break; }

                    listColumns.Add(v.ToString());
                    ++col;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        /* Discover if column name exists and if it does, what is its index.
         * columnName: Name of the column you want to find.
         * headerRow: Row where the name of the column can be found.
         * return: Index of the column, or -1 if column was not found, -2 if headerRow or selectedWorksheet are invalid.
         */
        private int FindColumn(string columnName)
        {
            if (selectedWorksheet < 0 || headerRow < 1) { return -2; }

            // Open the selected workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFileName);

            // Get the first worksheet
            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet.Select();

            // Find the column by name
            Excel.Range columnRange = worksheet.Rows[headerRow].Find(columnName, Type.Missing,
                    Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByRows,
                    Excel.XlSearchDirection.xlNext, false, Type.Missing, Type.Missing);

            if(columnRange == null)
            {
                Console.WriteLine($"Column '{columnName}' not found.");
                workbook.Close();
                return -1;
            }

            workbook.Close();
            return columnRange.Column;
        }

        private void ExtractColumnInfo(int columnIndex)
        {
            if(selectedWorksheet < 0 || headerRow < 1) { return; }

            // Open the selected workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFileName);

            // Get the first worksheet
            Excel.Worksheet worksheet = workbook.Sheets[selectedWorksheet];
            worksheet.Select();

            for (int row = headerRow + 1; row <= worksheet.UsedRange.Rows.Count; row++)
            {
                string value;
                try
                {
                    var v = (worksheet.Cells[row, columnIndex] as Excel.Range).Value;
                    if (v == null) { break; }

                    value = v.ToString();
                    Console.WriteLine($"Cell({row}, {columnIndex}): {value}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            workbook.Close();
        }

        /*
        private void LoadExcelFile(string fileName)
        {
            // Create a new Excel Application object
            //Excel.Application excelApp = new Excel.Application();
            //excelApp.Visible = false;

            // Open the selected workbook
            //Excel.Workbook workbook = excelApp.Workbooks.Open(fileName);

            // Get the first worksheet
            //Excel.Worksheet worksheet = workbook.Sheets[1];

            // Get the range of cells containing data
            Excel.Range range = worksheet.UsedRange;

            // Create a new DataTable to store the data
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            for (int i = 1; i <= range.Columns.Count; i++)
            {
                dataTable.Columns.Add(range.Cells[1, i].Value.ToString());
            }

            // Add rows to the DataTable
            for (int i = 2; i <= range.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int j = 1; j <= range.Columns.Count; j++)
                {
                    dataRow[j - 1] = range.Cells[i, j].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            // Set the DataGridView's DataSource property to the DataTable
            //dataGridView1.DataSource = dataTable;

            // Clean up resources
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        */


        private void comboBoxTbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindColumnNames();

            switch(comboBoxTbSelect.SelectedItem.ToString())
            {
                case "Pants":
                    ImportPants();
                    break;

                case "Jackets":

                    break;

                default:
                    break;
            }
        }

        private void ImportPants()
        {
            // Get the name of each column in the table.
            string query = ("SELECT COLUMN_NAME " +
                "FROM INFORMATION_SCHEMA.COLUMNS " +
                "WHERE TABLE_NAME = 'tbPants'");

            MakeTextBoxes(query);

        }

        private void MakeTextBoxes(string query)
        {
            List<TextBox> list = new List<TextBox>();

            cm = new SqlCommand(query, con);
            con.Open();
            dr = cm.ExecuteReader();

            // Screen positions.
            int boxWidth = 100;
            int boxHeight = 20;
            int boxSpacing = 10;
            Point databaseColumnPos = new Point(150, 10);
            Point excelColumnPos = new Point(150 + boxWidth + boxSpacing, 10);

            // Add Label on top of database columns.
            Label databse = new Label();
            databse.Text = "Database";
            databse.Location = databaseColumnPos;
            databse.ForeColor = Color.White;
            this.Controls.Add(databse);

            // Add Label on top of Excel columns.
            Label excel = new Label();
            excel.Text = "Excel Table";
            excel.Location = excelColumnPos;
            excel.ForeColor = Color.White;
            this.Controls.Add(excel);

            while (dr.Read())
            {
                // Calculate the location of the next Text Box.
                databaseColumnPos = new Point(
                    databaseColumnPos.X,
                    databaseColumnPos.Y + boxHeight);

                // Calculate the location of the next combo box Fill.
                excelColumnPos = new Point(
                    databaseColumnPos.X + boxWidth + boxSpacing,
                    databaseColumnPos.Y);

                // Make text box with info from the database.
                TextBox textBox = new TextBox();
                textBox.ReadOnly = true;
                textBox.Name = dr[0].ToString();
                textBox.Text = dr[0].ToString();
                textBox.Size = new Size(boxWidth, boxHeight);
                textBox.Location = databaseColumnPos;
                this.Controls.Add(textBox);

                // Make combo box with info from Excel.
                ComboBox comboBox = new ComboBox();
                comboBox.Location = excelColumnPos;
                comboBox.Size = new Size(boxWidth, boxHeight);
                for (int i = 0; i < listColumns.Count; ++i)
                {
                    comboBox.Items.Add(listColumns[i]);
                }
                this.Controls.Add(comboBox);
            }
            listTextBox.Clear();
            listTextBox = list;

            dr.Close();
            con.Close();
        }

        private void ClearExcelVar()
        {
            excelApp.Quit();
            listColumns.Clear();
            headerRow = -1;
            selectedWorksheet = -1;
            comboBoxTbSelect.Enabled = false;
        }

        /*
        private void UpdateExcelFile(string fileName)
        {
            // Create a new Excel Application object
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Open the selected workbook
            Excel.Workbook workbook = excelApp.Workbooks.Open(fileName);

            // Get the first worksheet
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Get the range of cells containing data
            Excel.Range range = worksheet.UsedRange;

            // Get a DataTable containing the changes
            DataTable changesTable = ((DataTable)dataGridView1.DataSource).GetChanges();

            // Update the Excel file with the changes
            if (changesTable != null)
            {
                foreach (DataRow dataRow in changesTable.Rows)
                {
                    Excel.Range cell = range.Find(dataRow[0]);
                    if (cell != null)
                    {
                        cell.Offset[0, 1].Value = dataRow[1];
                    }
                    else
                    {
                        int lastRow = range.Rows.Count;
                        range.Cells[lastRow + 1, 1].Value = dataRow[0];
                        range.Cells[lastRow + 1, 2].Value = dataRow[1];
                    }
                }
            }
        }
        */
    }

}

/* To use Microsoft Office Excel dll:
 
    Add the reference to the Microsoft.Office.Interop.Excel assembly in your project. Here's how:

    1. In your Visual Studio project, right-click on the References folder and select "Add Reference..." from the context menu.

    2. In the "Reference Manager" dialog box, select "Browse" at the bottom left corner.

    3. Navigate to the folder where Microsoft Office is installed on your computer (e.g. C:\Program Files (x86)\Microsoft Office\Office16 for Office 2016), and select the file Microsoft.Office.Interop.Excel.dll.

    4. Click "Add" to add the reference to your project.

    5. Now, you can add the necessary using statement at the top of your code file:
        using Excel = Microsoft.Office.Interop.Excel;

 */

/* To use Visual Basic dll:
    Add a reference to Microsoft.VisualBasic.dll
    Location: C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\
 */