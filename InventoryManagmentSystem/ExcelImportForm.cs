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
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace InventoryManagmentSystem
{
    /*TODO: (Manual) Delete columns if changing selected table.*/
    public partial class ExcelImportForm : Form
    {
        #region SQL_Variables
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;
        #endregion SQL_Variables

        #region Excel_Variables
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        #endregion Excel_Variables

        enum itemTypes
        {
            boots, helmet, jackets, pants, mask
        }

        enum tables
        {

        }

        string tableColumnSerial = "";

        List<System.Windows.Forms.TextBox> listTextBox = new List<System.Windows.Forms.TextBox>();
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
            connection.Close();
        }
        private void ExcelImport_Load(object sender, EventArgs e)
        {

            // ========== Manual Import Area ==========
            // Keep it disabled until a proper Excel file has been selected.
            comboBoxTbSelect.Enabled = false;
            comboBoxTbSelect.Items.Add("Pants");
            comboBoxTbSelect.Items.Add("Jackets");
        }

        /// <summary>
        /// Import Excel file manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Import Excel file using standard Excel documents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStandard_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }

        /// <summary>
        /// Logic for importing.
        /// </summary>
        /// <param name="isManual">Tells is the user is going to import manually</param>
        private void ImportExcel()
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
                OpenExcelFile(excelFileName);
                SubscribeToPromptForm();

                // If user cancels the dialog for import, this IF handles it without errors.
                if(worksheet == null) 
                {
                    ClearExcelVar();
                    return; 
                }

                // For using the import with a standar Excel document, header needs to be 2.
                headerRow = 2;
                FindExcelColumnNames();
                string tableName = FindTableName();

                // Could not find a table matching the item type.
                if(tableName == "")
                {
                    ClearExcelVar();
                    return;
                }
                FindNamesOfColumnsOnTable(tableName);
                UpdateDatabaseStandard(tableName);
            }
        }

        /// <summary>
        /// Starts a new Excel app. This is needed to open an Excel file.
        /// </summary>
        /// <param name="excelFileName"></param>
        private void OpenExcelFile(string excelFileName)
        {
            // Create a new Excel Application object
            excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Open the selected workbook
            workbook = excelApp.Workbooks.Open(excelFileName);
        }

        /// <summary>
        /// Wait for user to respond to ExcelUserPromptForm.
        /// This form will select which worksheet needs to be used.
        /// Also selects what row will be the start (2 for standard).
        /// </summary>
        private void SubscribeToPromptForm()
        {
            // Get all worksheet names available in the selected Excel file.
            List<string> worksheetNames = new List<string>();
            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                worksheetNames.Add(worksheet.Name);
            }

            // Get user prompt initialized.
            var promptForm = new ExcelUserPromptForm(worksheetNames, false);

            // Subscribe to the event inside of promptForm.
            // This will listen for user inputs.
            promptForm.userPrompt += (s, arguments) =>
            {
                // Make sure user selected something before setting worksheet.
                if (arguments.selectedWorksheet != "")
                {
                    worksheet = workbook.Worksheets[arguments.selectedWorksheet];
                }
                headerRow = arguments.selectedRow;
            };

            // This will update the selectedWorksheet and headerRow when the user is done.
            promptForm.ShowDialog();
        }

        /// <summary>
        /// Find the table being used based on the item type.
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns>Table Name or empty string if no table was found</returns>
        private string FindTableName()
        {
            // Find the type to know which table to use.
            Excel.Range cell = worksheet.Cells[3, 1];
            string trimed = cell.Value.ToString().Trim();
            string table = "";
            if (trimed == "Jacket")
            {
                table = "tbJackets";
            }
            else if (trimed == "Pants")
            {
                table = "tbPants";
            }
            else if (trimed == "Helmet")
            {
                table = "tbHelmets";
            }
            else if (trimed == "Boots")
            {
                table = "tbBoots";
            }
            
            return table;
        }

        /// <summary>
        /// Used fill the listTableColumns and set the tableColumnSerial.
        /// </summary>
        /// <param name="tableName"></param>
        private void FindNamesOfColumnsOnTable(string tableName)
        {
            // Find the names of all columns on the database table.
            string query = "SELECT COLUMN_NAME " +
                "FROM INFORMATION_SCHEMA.COLUMNS " +
                "WHERE TABLE_NAME = '" + tableName + "'" +
                "ORDER BY ORDINAL_POSITION";

            command = new SqlCommand(query, connection);
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                listTableColumns.Add(dataReader.GetString(0));
            }
            connection.Close();

            tableColumnSerial = listTableColumns[3];
        }

        /// <summary>
        /// Import items that are either pants or jackets.
        /// The columns are hard coded.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="isPants"></param>
        private void ImportPantsOrJackets(List<object[]> rows, bool isPants)
        {
            for(int i = 0; i < rows.Count; ++i)
            {
                object[] row = (object[])rows[i];
                string table = isPants ? "tbPants" : "tbJackets";

                if (row[7] == null)
                {
                    row[7] = "Fire-Tec";
                }
                else
                {
                    string str = row[7].ToString();
                    if (str == "firetec" || 
                        str == "FIRETEC" || 
                        str == "fire-tec" || 
                        str == "Firetec")
                    {
                        row[7] = "Fire-Tec";
                    }
                }

                string query = $"INSERT INTO {table} " +
                    $"(ItemType, Brand, SerialNumber, Location, UsedNew, ManufactureDate, DueDate, Size) " +
                    $"VALUES ('{row[0]}','{row[1]}','{row[2]}','{row[7]}','{row[5]}','{row[4]}',@date,'{row[3]}')";

                try
                {
                    connection.Open();
                    command = new SqlCommand(query, connection);

                    SqlParameter parameter = new SqlParameter("@date", SqlDbType.Date);
                    if (row[6] == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = row[6];
                    }
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    #if DEBUG
                        Console.WriteLine($"Error Row {i}");
                        Console.WriteLine(ex.ToString());
                    #endif
                }
            }
        }

        private void ImportBoots(List<object[]> rows)
        {
            for (int i = 0; i < rows.Count; ++i)
            {
                object[] row = (object[])rows[i];
                string table = "tbBoots";

                if (row[8] == null)
                {
                    row[8] = "Fire-Tec";
                }
                else
                {
                    string str = row[8].ToString();
                    if (str == "firetec" ||
                        str == "FIRETEC" ||
                        str == "fire-tec" ||
                        str == "Firetec")
                    {
                        row[8] = "Fire-Tec";
                    }
                }

                string query = $"INSERT INTO {table} " +
                    "(ItemType, Brand, SerialNumber, Location, UsedNew, ManufactureDate, DueDate, Size, [Material]) " +
                    "VALUES (@ItemType, @Brand, @SerialNumber, @Location, @UsedNew, @ManufactureDate, @DueDate, @Size, @Material)";

                try
                {
                    connection.Open();
                    command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ItemType", row[0]);
                    command.Parameters.AddWithValue("@Brand", row[1]);
                    command.Parameters.AddWithValue("@SerialNumber", row[2]);
                    command.Parameters.AddWithValue("@Location", row[8]);
                    command.Parameters.AddWithValue("@UsedNew", row[5]);
                    command.Parameters.AddWithValue("@ManufactureDate", row[4]);
                    command.Parameters.AddWithValue("@DueDate", row[7] ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Size", row[6]);
                    command.Parameters.AddWithValue("@Material", row[3]);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    #if DEBUG
                    Console.WriteLine($"Error Row {i}");
                    Console.WriteLine(ex.ToString());
                    #endif
                }
            }
        }

        private void ImportHelmets(List<object[]> rows)
        {
            for (int i = 0; i < rows.Count; ++i)
            {
                object[] row = (object[])rows[i];
                string table = "tbHelmets";

                if (row[7] == null)
                {
                    row[7] = "Fire-Tec";
                }
                else
                {
                    string str = row[7].ToString();
                    if (str == "firetec" ||
                        str == "FIRETEC" ||
                        str == "fire-tec" ||
                        str == "Firetec")
                    {
                        row[7] = "Fire-Tec";
                    }
                }

                string query = $"INSERT INTO {table} " +
                    "(ItemType, Brand, SerialNumber, Location, UsedNew, ManufactureDate, DueDate, Color) " +
                    "VALUES (@ItemType, @Brand, @SerialNumber, @Location, @UsedNew, @ManufactureDate, @DueDate, @Color)";

                try
                {
                    connection.Open();
                    command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ItemType", row[0]);
                    command.Parameters.AddWithValue("@Brand", row[1]);
                    command.Parameters.AddWithValue("@SerialNumber", row[2]);
                    command.Parameters.AddWithValue("@Location", row[7]);
                    command.Parameters.AddWithValue("@UsedNew", row[5]);
                    command.Parameters.AddWithValue("@ManufactureDate", row[4]);
                    command.Parameters.AddWithValue("@DueDate", row[6] ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Color", row[3]);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    #if DEBUG
                    Console.WriteLine($"Error Row {i}");
                    Console.WriteLine(ex.ToString());
                    #endif
                }
            }
        }

        /// <summary>
        /// Using standar Excel files, update the database.
        /// </summary>
        /// <param name="tableName"></param>
        private void UpdateDatabaseStandard(string tableName)
        {

            List<object[]> rows = new List<object[]>();

            int colNum = worksheet.UsedRange.Columns.Count;

            // Set progress bar to start.
            progressBar1.Minimum = 0;
            progressBar1.Maximum = worksheet.UsedRange.Rows.Count - headerRow;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            // Loop through the rows in the worksheet and add them to the rows collection.
            for (int i = headerRow + 1; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                object[] values = new object[colNum];
                bool isDuplicate = false;
                bool isNull = false;
                for (int j = 1; j <= worksheet.UsedRange.Columns.Count; j++)
                {
                    var v = worksheet.Cells[i, j].Value;

                    // Making sure not to add empty row cells to important places.
                    if ((j == 1 || j == 2 || j == 3) && v == null)
                    {
                        isNull = true;
                        break;
                    }

                    // Take away empty spaces from beginning and end.
                    if(v != null && v.GetType() == typeof(string))
                    {
                        v = ((string)v).Trim();
                    }

                    // Make sure this item is not duplicated.
                    if (j == 3)
                    {
                        isDuplicate = CheckDuplicateSerialNumber(v.ToString(), tableName);
                        if(isDuplicate) { break; }
                    }

                    values[j - 1] = v;
                }
                
                ++progressBar1.Value;
                #if DEBUG
                Console.WriteLine($"Cell({progressBar1.Value}/{progressBar1.Maximum})");
                #endif
                // Only add row if it does not have a duplicated serial number and initial columns are not null.
                if (isDuplicate == false && isNull == false)
                {
                    rows.Add(values);
                }
            }

            progressBar1.Visible = false;

            if (tableName == "tbPants")
                ImportPantsOrJackets(rows, true);
            else if (tableName == "tbJackets")
                ImportPantsOrJackets(rows, false);
            else if (tableName == "tbBoots")
                ImportBoots(rows);
            else if (tableName == "tbHelmets")
                ImportHelmets(rows);

            ClearExcelVar();

            /*
            // Create the colums for the Data Table.
            DataTable dataTable = new DataTable();
            for (int i = 0; i < colNum; i++)
            {
                var v = worksheet.Cells[headerRow, i + 1].Value;
                if (v == null) { continue; }
                dataTable.Columns.Add(listExcelColumns[i]);
            }

            // Add rows to the Data Table
            foreach (var row in rows)
            {
                dataTable.Rows.Add(row);
            }
            */
            /*
            // Match columns from Excel and Database.
            string columns = "";
            string colValues = "";
            // I will hard code somethings to keep the standard Excel format.
            // Excel: 0.ItemType 1.Brand 2.Serial 3.Size 4.MDF 5.UsedNew 6.DueDate 7.Location
            // Database: 1.ItemType 2.Brand 3.SerialNumber 4.Location 5.UsedNew 6.ManufactureDate 7.DueDate 8.Size || Color 9.Other
            if(tableName == "tbJackets" || tableName == "tbPants")
            {
                for (int i = 1; i <= 8; ++i)
                {
                    // Select database column to add to.
                    columns += listTableColumns[i];
                    // Select value from Excel column to add to database.
                    if (i == 4)
                    {
                        colValues += "@" + listExcelColumns[7];
                    }
                    else if (i == 5)
                    {
                        colValues += "@" + listExcelColumns[5];
                    }
                    else if (i == 6)
                    {
                        colValues += "@" + listExcelColumns[4];
                    }
                    else if (i == 8)
                    {
                        colValues += "@" + listExcelColumns[3];
                    }
                    else
                    {
                        colValues += "@" + listExcelColumns[i - 1];
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
            */
            /* for (int i = 0; i < listExcelColumns.Count; ++i)
             {
                 columns += listTableColumns[i + 1].ToString();
                 colValues += "@" + listExcelColumns[i].ToString();
                 if (i < listExcelColumns.Count - 1)
                 {
                     columns += ", ";
                     colValues += ", ";
                 }
             }*/

            /*con.Open();
            // Insert rows from Excel into the database table.
            string query = "INSERT INTO " + tableName + " (" + columns + ") " +
                            "VALUES (" + colValues + ")";*/

            /* string query2 = "insert into tbPants" + 
                 "(ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew, DueDate, Location) " +
                 "VALUES (@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8)";*/

            /*      string query2 = "insert into tbPants" +
                      "(ItemType, Brand, SerialNumber, Size, ManufactureDate, UsedNew, DueDate, Location) " +
                      "VALUES (@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8)";

                  cm.Parameters.AddWithValue("@v1", rows[0][0]);
                  cm.Parameters.AddWithValue("@v2", rows[0][1]);
                  cm.Parameters.AddWithValue("@v3", rows[0][2]);
                  cm.Parameters.AddWithValue("@v4", rows[0][3]);
                  cm.Parameters.AddWithValue("@v5", rows[0][4]);
                  cm.Parameters.AddWithValue("@v6", rows[0][5]);
                  cm.Parameters.AddWithValue("@v7", rows[0][6]);
                  cm.Parameters.AddWithValue("@v8", rows[0][7]);*/

            /*foreach (DataRow row in dataTable.Rows)
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

                            // Add more data types as needed...

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
                    cm.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    // TODO: Send an error notification to user.
                    Console.WriteLine(ex.ToString());
                }
                    
            }*/

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

            command = new SqlCommand(query, connection);
            connection.Open();
            dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = dataReader.GetBoolean(0);
            }
            connection.Close();
            return result;
        }

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
                    listExcelColumns.Add(v);
                    ++col;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        private Guid AddItem(itemTypes type)
        {
            // TODO: FIX THIS SHIT
            string query =
                "INSERT INTO tbItems(ItemType) " +
                "OUTPUT inserted.Id " +
                "VALUES(@ItemType)";
            Guid uuid = Guid.Empty;

            try
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemType", "");
                connection.Open();
                uuid = (Guid)command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"ERROR adding item: {ex.Message}");
                MessageBox.Show("Could not add item.");
            }
            return uuid;
        }

        #region Manula Import

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
                    //ImportPantsManual();
                    UpdateDatabaseStandard("tbPants");
                    break;

                case "Jackets":

                    break;

                default:
                    break;
            }
        }

        private void ImportPantsManual()
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
            List<System.Windows.Forms.TextBox> list = new List<System.Windows.Forms.TextBox>();

            command = new SqlCommand(query, connection);
            connection.Open();
            dataReader = command.ExecuteReader();

            // Screen positions.
            int boxWidth = 100;
            int boxHeight = 20;
            int boxSpacing = 10;
            System.Drawing.Point databaseColumnPos = new System.Drawing.Point(150, 20);
            System.Drawing.Point excelColumnPos = new System.Drawing.Point(150 + boxWidth + boxSpacing, 20);

            // Add Label on top of database columns.
            System.Windows.Forms.Label databse = new System.Windows.Forms.Label();
            databse.Text = "Database";
            databse.Location = databaseColumnPos;
            databse.ForeColor = Color.White;
            this.Controls.Add(databse);

            // Add Label on top of Excel columns.
            System.Windows.Forms.Label excel = new System.Windows.Forms.Label();
            excel.Text = "Excel Table";
            excel.Location = excelColumnPos;
            excel.ForeColor = Color.White;
            this.Controls.Add(excel);

            rows = 0;
            while (dataReader.Read())
            {
                // Calculate the location of the next Text Box.
                databaseColumnPos = new System.Drawing.Point(
                    databaseColumnPos.X,
                    databaseColumnPos.Y + boxHeight);

                // Calculate the location of the next combo box Fill.
                excelColumnPos = new System.Drawing.Point(
                    databaseColumnPos.X + boxWidth + boxSpacing,
                    databaseColumnPos.Y);

                // Make text box with info from the database.
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                textBox.ReadOnly = true;
                textBox.Name = "tb" + rows;
                textBox.Text = dataReader[0].ToString();
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

            dataReader.Close();
            connection.Close();
        }

        #endregion Manual Import

        #region Helper

        /// <summary>
        /// Convert a value from Excel into the appropriate data type to fit the database column.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
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
            connection.Close();
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