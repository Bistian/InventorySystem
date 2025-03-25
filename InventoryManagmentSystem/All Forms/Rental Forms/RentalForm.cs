using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class RentalForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        //Makes date red if it is less than this number.
        int daysForWarning = 14;

        string SearchTerm = "";
        public RentalForm(string ItemType)
        {
            InitializeComponent();
            RefreshForm(ItemType);
            InitTables();
        }

        private string QueryForPastDue()
        {
            string query = $@"
                SELECT c.Id, c.Name, i.DueDate AS LateDueDate, i.ItemCount
                FROM tbClients AS c
                JOIN (
                    SELECT Location, MIN(DueDate) AS DueDate, COUNT(*) AS ItemCount
                    FROM tbItems AS i_inner
                    WHERE i_inner.Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND i_inner.Condition NOT IN ('Retired') 
                      AND i_inner.DueDate IS NOT NULL 
                      AND i_inner.DueDate < GETDATE()
                    GROUP BY Location
                ) AS i ON CAST(c.Id AS NVARCHAR(MAX)) = i.Location;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private string QueryForRented()
        {
            string query = $@"
                SELECT c.Id, c.Name, i.DueDate AS ClosestDueDate, ic.ItemCount AS ItemCountPerLocation
                FROM tbClients AS c
                JOIN (
                    SELECT Location, DueDate,
                           ROW_NUMBER() OVER (PARTITION BY Location ORDER BY ABS(DATEDIFF(DAY, GETDATE(), DueDate))) AS RowNum
                    FROM tbItems
                    WHERE Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND Condition NOT IN ('Retired') 
                      AND DueDate IS NOT NULL 
                ) AS i ON CAST(c.Id AS NVARCHAR(MAX)) = i.Location
                JOIN (
                    SELECT Location, COUNT(*) AS ItemCount
                    FROM tbItems
                    WHERE Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND Condition NOT IN ('Retired') 
                      AND DueDate IS NOT NULL 
                      AND DueDate > GETDATE()
                    GROUP BY Location
                ) AS ic ON CAST(c.Id AS NVARCHAR(MAX)) = ic.Location
                WHERE i.RowNum = 1;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private void InitTables()
        {
            LoadTables(dataGridRented, QueryForRented(), "column_rented_due_date");
            LoadTables(dataGridPastDue, QueryForPastDue(), "column_past_due_due_date");
            HelperFunctions.DataGridFormatDateColumn(dataGridRented, "column_rented_due_date");
            HelperFunctions.DataGridFormatDateColumn(dataGridPastDue, "column_past_due_due_date");
        }

        private string QuerySwitch(string itemType, string sign)
        {
            string query = $@"
                SELECT ItemType='boots', c.Name, DueDate, SerialNumber FROM tb{itemType} AS t
                INNER JOIN tbClients AS c ON (c.DriversLicenseNumber = t.Location OR c.Id = t.Location)
                WHERE DueDate IS NOT NULL AND DueDate {sign} CONVERT(DATE, GETDATE())
            ";
            return query;
        }

        /// <summary>
        /// Render the tables.
        /// </summary>
        /// <param name="grid">Which table you are going to render.</param>
        /// <param name="query">SQL code for the table.</param>
        /// <param name="columnName">Name of the column as it is in Edit Columns.</param>
        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            HelperFunctions.DataGridFormatDateColumn(grid, columnName);
            grid.Rows.Clear();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    ++i;
                    grid.Rows.Add(i,
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        // Check if rented due date is getting closer and turns date red.
        private void dataGridRented_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Is this the Due Date column?
            if (e.ColumnIndex != 3) { return; }

            //Check if the date is getting close.
            DateTime date = DateTime.Parse(e.Value.ToString());
            if ((date - DateTime.Now).TotalDays > daysForWarning) { return; }

            //Change cell color.
            e.CellStyle.ForeColor = Color.Red;
        }

        private void dataGridRented_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, false);
        }

        private void dataGridPastDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPopUp(e, true);
        }

        /// <summary>
        /// Makes the pop up window with the client's information.
        /// </summary>
        /// <param name="e">Event from the click.</param>
        /// <param name="isPastDue">Flag checking if the function is working with the rented table or the past due.</param>
        private void ClientPopUp(DataGridViewCellEventArgs e, bool isPastDue)
        {
            // Check if the clicked cell is in a row
            if (e.RowIndex < 0) { return; }

            // Column 2 is the only one this function should operate on.
            if (e.ColumnIndex != 2) { return; }

            // Get the data from rentee at that row.
            DataGridViewRow row;
            if (isPastDue)
            {
                row = dataGridPastDue.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridRented.Rows[e.RowIndex];
            }


            string rentee = row.Cells[2].Value.ToString();
            // Check if there is at least one item with that name on the clints table.
            string query = (
                "SELECT COUNT(*) FROM tbClients " +
                "WHERE Name ='" + rentee + "'");

            var command = new SqlCommand(query, connection);
            connection.Open();

            // If there are no matches with that name, return.
            if ((int)command.ExecuteScalar() <= 0)
            {
                connection.Close();
                return;
            }
            connection.Close();

            // Show the details of the row in a new form or dialog
            DialogBoxClient dialogBoxClient = new DialogBoxClient(rentee);
            dialogBoxClient.ShowDialog();
        }

        private void ButtonNewRental_Click(object sender, EventArgs e)
        {
            NewOrExistingCustomerModuleForm ModForm = new NewOrExistingCustomerModuleForm();
            ModForm.ShowDialog();
            RefreshForm(null);
        }

        private void RefreshForm(string ItemType)
        {
            LoadTables(dataGridRented, QueryForRented(), "column_rented_due_date");
            LoadTables(dataGridPastDue, QueryForPastDue(), "column_past_due_due_date");
        }

        private void labelSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchBar.Text.Length < 1)
            {
                foreach (DataGridViewRow row in dataGridPastDue.Rows)
                {
                    row.Visible = true;
                }
                foreach (DataGridViewRow rowRented in dataGridRented.Rows)
                {
                    rowRented.Visible = true;
                }
                return;
            }

            SearchTerm = searchBar.Text;

            foreach (DataGridViewRow row in dataGridPastDue.Rows)
            {
                // Convert cell value to lowercase for case-insensitive comparison
                string cellValue = row.Cells["column_past_due_rentee"].Value?.ToString().ToLower();
                if (cellValue != null && cellValue.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = true;
                }
            }
            foreach (DataGridViewRow row in dataGridRented.Rows)
            {
                // Convert cell value to lowercase for case-insensitive comparison
                string cellValue = row.Cells["column_rented_rentee"].Value?.ToString().ToLower();
                if (cellValue != null && cellValue.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = true;
                }
            }


        }

        private void dataGridPastDue_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridPastDue.Rows[e.RowIndex];
            string column = dataGridPastDue.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_past_due_rentee"].Value.ToString();
            string clientId = row.Cells["column_past_due_id"].Value.ToString();


            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(clientId, clientName);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void dataGridRented_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridRented.Rows[e.RowIndex];
            string column = dataGridRented.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_rented_rentee"].Value.ToString();
            string clientId = row.Cells["column_rented_id"].Value.ToString();


            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(clientId, clientName);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }
    }
}
