﻿using System;
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
    public partial class ExcelImportForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;

        List<System.Windows.Forms.TextBox> listTextBox = new List<System.Windows.Forms.TextBox>();
        List<string> listTableColumns = new List<string>();
        List<string> listExcelColumns = new List<string>();

        int headerRow = -1;
        int selectedWorksheet = 1;
        int rows = 0;
        string tableColumnSerial = "";
        string excelFileName = "";

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


            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            excelFileName = openFileDialog.FileName;

            // Create a new Excel application object and open the selected workbook.
            excelApp = new Excel.Application();
            excelApp.Visible = false;
            workbook = excelApp.Workbooks.Open(excelFileName);

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
            UpdateDatabase(tableName);
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
            else if(trimed == "Mask")
            {
                table = "tbMasks";
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
            string query = $@"
                SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = '{tableName}' 
                ORDER BY ORDINAL_POSITION";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    listTableColumns.Add(dataReader.GetString(0));
                }
                tableColumnSerial = listTableColumns[3];
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
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

                var uuid = HelperSql.ItemInsertAndGetUuid(connection, 
                    row[0].ToString(), row[2].ToString(), row[5].ToString(), "Rent");

                if (uuid == "") { return; }

                DateTime today = new DateTime();
                bool isInserted = false;
                if(isPants)
                {
                    isInserted = HelperSql.PantsInsert(connection, uuid,
                        row[1].ToString(), today.ToString(), row[4].ToString(), row[3].ToString());
                }

                if(!isInserted)
                {
                    HelperSql.ItemDelete(connection, uuid);
                    return;
                }

               /* string query = $"INSERT INTO {table} " +
                    $"(ItemId, Brand, SerialNumber, Location, Condition, ManufactureDate, DueDate, Size) " +
                    $"VALUES ('{uuid}','{row[1]}','{row[2]}','{row[7]}','{row[5]}','{row[4]}',@date,'{row[3]}')";*/
                
                /*try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

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
                    // If I cannot connect the item, I need to delete it.
                    HelperSql.ItemDelete(connection, uuid);
                }*/
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
                //Guid uuid = HelperSql.ItemInsertAndGetUuid(connection, row[0].ToString());
                string query = $"INSERT INTO {table} " +
                    "(ItemId, Brand, SerialNumber, Location, Condition, ManufactureDate, DueDate, Size, [Material]) " +
                    "VALUES (@ItemId, @Brand, @SerialNumber, @Location, @Condition, @ManufactureDate, @DueDate, @Size, @Material)";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    //command.Parameters.AddWithValue("@ItemId", uuid);
                    command.Parameters.AddWithValue("@Brand", row[1]);
                    command.Parameters.AddWithValue("@SerialNumber", row[2]);
                    command.Parameters.AddWithValue("@Location", row[8]);
                    command.Parameters.AddWithValue("@Condition", row[5]);
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
                    // If I cannot connect the item, I need to delete it.
                    //HelperSql.ItemDelete(connection, uuid);
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

                //Guid uuid = HelperSql.ItemInsertAndGetUuid(connection, row[0].ToString());
                string query = $"INSERT INTO {table} " +
                    "(ItemId, Brand, SerialNumber, Location, Condition, ManufactureDate, DueDate, Color) " +
                    "VALUES (@ItemId, @Brand, @SerialNumber, @Location, @Condition, @ManufactureDate, @DueDate, @Color)";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    //command.Parameters.AddWithValue("@ItemId", uuid);
                    command.Parameters.AddWithValue("@Brand", row[1]);
                    command.Parameters.AddWithValue("@SerialNumber", row[2]);
                    command.Parameters.AddWithValue("@Location", row[7]);
                    command.Parameters.AddWithValue("@Condition", row[5]);
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
                    // If I cannot connect the item, I need to delete it.
                    //HelperSql.ItemDelete(connection, uuid);
                }
            }
        }

        /// <summary>
        /// Using standar Excel files, update the database.
        /// </summary>
        /// <param name="tableName"></param>
        private void UpdateDatabase(string tableName)
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
            string query = $@"
                SELECT CASE
                WHEN EXISTS (
                    SELECT 1 FROM {table} 
                    WHERE {tableColumnSerial} = '{serial}')
                THEN CAST(1 AS BIT) 
                ELSE CAST(0 AS BIT) 
                END";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    result = dataReader.GetBoolean(0);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
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

        /// <summary>
        /// Import Excel file using standard Excel documents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }


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