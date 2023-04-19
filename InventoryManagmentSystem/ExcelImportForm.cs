using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;

namespace InventoryManagmentSystem
{
    /*TODO: (Manual) Delete columns if changing selected table.*/
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

        #region Excel_Variables
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        #endregion Excel_Variables

        string tableColumnSerial = "";


        List<TextBox> listTextBox = new List<TextBox>();
        List<string> listTableColumns = new List<string>();
        List<string> listExcelColumns = new List<string>();
        string excelFileName = "";
        int headerRow = -1;
        int selectedWorksheet = 1;
        int rows = 0;

        public ExcelImportForm()
        {
            InitializeComponent();
        }

        ~ExcelImportForm()
        {
            workbook.Close();
            excelApp.Quit();
            CloseBackgroundExcel();
            con.Close();
        }
        private void ExcelImport_Load(object sender, EventArgs e)
        {
            comboBoxTbSelect.Items.Add("Pants");
            comboBoxTbSelect.Items.Add("Jackets");

            // Keep it disabled until a proper Excel file has been selected.
            comboBoxTbSelect.Enabled = false;
        }

        /// <summary>
        /// Import Excel file manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ImportExcel(true);
        }

        /// <summary>
        /// Import Excel file using standard Excel documents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStandard_Click(object sender, EventArgs e)
        {
            ImportExcel(false);
        }

        /// <summary>
        /// Logic for importing.
        /// </summary>
        /// <param name="isManual">Tells is the user is going to import manually</param>
        private void ImportExcel(bool isManual)
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
                workbook = excelApp.Workbooks.Open(excelFileName);

                // Get all worksheet names available in the selected Excel file.
                List<string> worksheetNames = new List<string>();
                foreach (Excel.Worksheet worksheet in workbook.Worksheets)
                {
                    worksheetNames.Add(worksheet.Name);
                }

                // Get user prompt initialized.
                var promptForm = new ExcelUserPromptForm(worksheetNames, isManual);

                // Subscribe to the event inside of promptForm.
                // This will listen for user inputs.
                promptForm.userPrompt += (s, arguments) =>
                {
                    // Make sure user selected something before setting worksheet.
                    if(arguments.selectedWorksheet != "")
                    {
                        worksheet = workbook.Worksheets[arguments.selectedWorksheet];
                    }
                    headerRow = arguments.selectedRow;
                };

                // This will update the selectedWorksheet and headerRow when the user is done.
                promptForm.ShowDialog();

                // If user cancels the dialog for import, this IF handles it without errors.
                if(worksheet == null) 
                {
                    ClearExcelVar();
                    return; 
                }

                // If it is not manual I know what row the header is.
                if(isManual == false)
                {
                    headerRow = 2;
                    FindExcelColumnNames();

                    // Find the type to know which table to use.
                    Excel.Range cell = worksheet.Cells[3, 1];
                    string table = "tb" + cell.Value.ToString().Trim();

                    // Find the names of all columns on the database table.
                    string query = "SELECT COLUMN_NAME " +
                        "FROM INFORMATION_SCHEMA.COLUMNS " +
                        "WHERE TABLE_NAME = '" + table + "'" +
                        "ORDER BY ORDINAL_POSITION";

                    cm = new SqlCommand(query, con);
                    con.Open();
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        listTableColumns.Add(dr.GetString(0));
                    }
                    con.Close();

                    tableColumnSerial = listTableColumns[3];

                    UpdateDatabaseStandard(table);
                }


                // Cannot select a worksheet before selecting an Excel file.
                /*if (selectedWorksheet >= 0 && headerRow > 0)
                {
                    comboBoxTbSelect.Enabled = true;
                }*/
            }
        }

        // Using standar Excel files, update the database.
        private void UpdateDatabaseStandard(string tableName)
        {

            List<object[]> rows = new List<object[]>();

            int rowNum = worksheet.UsedRange.Rows.Count;
            int colNum = worksheet.UsedRange.Columns.Count;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = rowNum+1;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            // Loop through the rows in the worksheet and add them to the rows collection.
            for (int i = headerRow + 1; i <= worksheet.UsedRange.Rows.Count + 1; i++)
            {
                object[] values = new object[colNum];
                bool isDuplicate = false;
                bool isNull = false;
                for (int j = 1; j <= worksheet.UsedRange.Columns.Count; j++)
                {
                    var v = worksheet.Cells[i, j].Value;
                    if(v != null && v.GetType() == typeof(string))
                    {
                        v = ((string)v).Trim();
                    }

                    // Making sure not to add empty rows.
                    if ((j == 1 || j == 2 || j == 3) && v == null)
                    {
                        isNull = true;
                        break;
                    }

                    // Make sure this item is not duplicated.
                    if (j == 3)
                    {
                        isDuplicate = CheckDuplicateSerialNumber(v.ToString(), tableName);
                        if(isDuplicate) { break; }
                    }

                    values[j - 1] = v;
                }
                Console.WriteLine($"Cell({i}/{rowNum})");
                progressBar1.Value = i;

                // Only add row if it does not have a duplicated serial number and initial columns are not null.
                if (isDuplicate == false && isNull == false)
                {
                    rows.Add(values);
                }
            }

            progressBar1.Visible = false;

            // Convert the rows collection to a DataTable.
            DataTable dataTable = new DataTable();
            for (int i = 0; i < colNum; i++)
            {
                var v = worksheet.Cells[headerRow, i + 1].Value;
                if (v == null) { continue; }
                dataTable.Columns.Add(v);
            }

            foreach (var row in rows)
            {
                dataTable.Rows.Add(row);
            }

            // Match columns from Excel and Database.
            string columns = "";
            string colValues = "";
            // I will hard code somethings to keep the standard Excel format.
            // Excel: 0.ItemType 1.Brand 2.Serial 3.Size 4.MDF 5.UsedNew 6.DueDate 7.Location
            // Database: 1.ItemType 2.Brand 3.SerialNumber 4.Location 5.UsedNew 6.ManufactureDate 7.DueDate 8.Size || Color 9.Other
            if(tableName == "tbJackets" || tableName == "tbPants")
            {
                for(int i = 1; i <= 8; ++i)
                {
                    // Select database column to add to.
                    columns += listTableColumns[i];
                    // Select value from Excel column to add to database.
                    if(i == 4)
                    {
                        colValues += "@" + listExcelColumns[7];
                    }
                    else if(i == 5)
                    {
                        colValues += "@" + listExcelColumns[5];
                    }
                    else if(i == 6)
                    {
                        colValues += "@" + listExcelColumns[4];
                    }
                    else if( i == 8)
                    {
                        colValues += "@" + listExcelColumns[3];
                    }
                    else
                    {
                        colValues += "@" + listExcelColumns[i-1];
                    }

                    // Add comma and space unless it is the lest item.
                    if (i < 8)
                    {
                        columns += ", ";
                        colValues += ", ";
                    }
                }
            }
            else if(tableName == "tbHelmets")
            {

            }
            else if( tableName == "tbBoots")
            {

            }
            
            /*for (int i = 0; i < listExcelColumns.Count; ++i)
            {
                columns += listTableColumns[i+1].ToString();
                colValues += "@" + listExcelColumns[i].ToString();
                if (i < listExcelColumns.Count - 1)
                {
                    columns += ", ";
                    colValues += ", ";
                }
            }*/

            con.Open();
            // Insert rows from Excel into the database table.
            string query = "INSERT INTO " + tableName +
                " (" + columns + ") VALUES (" + colValues + ")";

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    cm = new SqlCommand(query, con);
                    for (int i = 0; i < dataTable.Columns.Count; ++i)
                    {
                        object value = row[i];
                        SqlDbType dbType = SqlDbType.VarChar;

                        // Find out the data type of this cell.
                        if (value != null && value != DBNull.Value)
                        {
                            Type valueType = value.GetType();
                            if (valueType == typeof(int))
                            {
                                dbType = SqlDbType.Int;
                            }
                            else if (valueType == typeof(double))
                            {
                                dbType = SqlDbType.Float;
                            }
                            else if (valueType == typeof(DateTime))
                            {
                                dbType = SqlDbType.DateTime;
                            }

                            // Add more data types as needed

                            SqlParameter parameter = new SqlParameter("@" + dataTable.Columns[i].ColumnName, dbType);
                            parameter.Value = value;
                            cm.Parameters.Add(parameter);
                        }
                        else
                        {
                            // Handle null or DBNull values
                            SqlParameter parameter = new SqlParameter("@" + dataTable.Columns[i].ColumnName, dbType);
                            parameter.Value = DBNull.Value;
                            cm.Parameters.Add(parameter);
                        }
                    }

                    /*for(int i = 0; i < listColumns.Count; ++i)
                    {
                        string col = listColumns[i].ToString();
                        cm.Parameters.AddWithValue("@" + col, row[col]);
                    }*/

                    cm.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                    
            }
            ClearExcelVar();
        }

        /// <summary>
        /// Try to find a match for the given serial number.
        /// </summary>
        /// <param name="serial">Serial number to be looked for.</param>
        /// <param name="table">Table to look at.</param>
        /// <returns>false if serial number does not exist in the given table.</returns>
        private bool CheckDuplicateSerialNumber(string serial, string table)
        {
            bool result = false;
            string query = "SELECT CASE\r\n" +
                "WHEN EXISTS (SELECT 1 FROM " + table + " " +
                "WHERE " + tableColumnSerial + " = '" + serial + "')\r\n " +
                "THEN CAST(1 AS BIT)\r\n " +
                "ELSE CAST(0 AS BIT)\r\n" +
                "END";

            cm = new SqlCommand(query, con);
            con.Open();
            dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                result = dr.GetBoolean(0);
            }
            con.Close();
            return result;
        }

        #region Manula Import

        /// <summary>
        /// Make a list with the name of all availabe Excel column names.
        /// </summary>
        private void FindExcelColumnNames()
        {
            if(worksheet == null || workbook == null) { return; }

            // Loop through the cells in the headerRow
            int col = 1;
            while(true)
            {
                try
                {
                    var v = (worksheet.Cells[headerRow, col] as Excel.Range).Value;
                    if(v == null) { break; }

                    listExcelColumns.Add(v.ToString());
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
            if (worksheet == null || workbook == null) { return -2; }

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
            workbook = excelApp.Workbooks.Open(excelFileName);

            // Get the selected worksheet
            worksheet = workbook.Sheets[selectedWorksheet];
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

        // Select which table is going to be used.
        private void comboBoxTbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindExcelColumnNames();

            switch(comboBoxTbSelect.SelectedItem.ToString())
            {
                case "Pants":
                    //ImportPants();
                    UpdateDatabaseStandard("tbPants");
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

            MakeColumnsManualMethod(query);

        }

        // Make columns from Excel and Database to be filled by the user.
        private void MakeColumnsManualMethod(string query)
        {
            List<TextBox> list = new List<TextBox>();

            cm = new SqlCommand(query, con);
            con.Open();
            dr = cm.ExecuteReader();

            // Screen positions.
            int boxWidth = 100;
            int boxHeight = 20;
            int boxSpacing = 10;
            Point databaseColumnPos = new Point(150, 20);
            Point excelColumnPos = new Point(150 + boxWidth + boxSpacing, 20);

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

            rows = 0;
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
                textBox.Name = "tb" + rows;
                textBox.Text = dr[0].ToString();
                textBox.Size = new Size(boxWidth, boxHeight);
                textBox.Location = databaseColumnPos;
                this.Controls.Add(textBox);

                // Make combo box with info from Excel.
                ComboBox comboBox = new ComboBox();
                comboBox.Name = "cb" + rows;
                comboBox.Location = excelColumnPos;
                comboBox.Size = new Size(boxWidth, boxHeight);
                for (int i = 0; i < listExcelColumns.Count; ++i)
                {
                    comboBox.Items.Add(listExcelColumns[i]);
                }
                this.Controls.Add(comboBox);
                ++rows;
            }
            listTextBox.Clear();
            listTextBox = list;

            dr.Close();
            con.Close();
        }

        #endregion Manual Import

        #region Helper

        // Convert a value from Excel into the appropriate data type to fit the database column.
        private object ConvertExcelValueToType(string value, Type targetType)
        {
            if (targetType == typeof(int))
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    return intValue;
                }
            }
            else if (targetType == typeof(double))
            {
                double doubleValue;
                if (double.TryParse(value, out doubleValue))
                {
                    return doubleValue;
                }
            }
            else if (targetType == typeof(DateTime))
            {
                DateTime dateTimeValue;
                if (DateTime.TryParse(value, out dateTimeValue))
                {
                    return dateTimeValue;
                }
            }
            // Handle any additional data types here...

            return value; // Return as string by default
        }

        /// <summary>
        /// Clear variables related to Excel.
        /// </summary>
        private void ClearExcelVar()
        {
            workbook.Close();
            excelApp.Quit();
            CloseBackgroundExcel();
            worksheet = null;
            workbook = null;
            excelApp = null;
            con.Close();
            listExcelColumns.Clear();
            listTableColumns.Clear();
            headerRow = -1;
            selectedWorksheet = -1;
            comboBoxTbSelect.Enabled = false;
        }

        /// <summary>
        /// Close Excel applications running on the background.
        /// </summary>
        private void CloseBackgroundExcel()
        {
            // Release the Excel object
            Marshal.ReleaseComObject(excelApp);

            // Force garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Close the Excel process
            Process[] processes = Process.GetProcessesByName("EXCEL");
            foreach (Process process in processes)
            {
                if (string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    process.Kill();
                }
            }
        }

        #endregion Helper


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