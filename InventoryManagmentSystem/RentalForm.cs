using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //Makes date red if it is less than this number.
        int daysForWarning = 14;

        public RentalForm()
        {
            InitializeComponent();
            LoadTables(dataGridRented, QueryRented(), "DueDate");
            LoadTables(dataGridPastDue, QueryPastDue(), "DDate");
        }

        private string QueryRented()
        {
            return ("SELECT ItemType, Location, DueDate, SerialNumber FROM tbPants " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbBoots " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbJackets " +
                "WHERE DueDate IS NOT NULL AND DueDate >= CONVERT(DATE, GETDATE()) " +
                "ORDER BY DueDate");
        }

        private string QueryPastDue()
        {
            return ("SELECT ItemType, Location, DueDate, SerialNumber FROM tbPants " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbBoots " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbHelmets " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "UNION SELECT ItemType, Location, DueDate, SerialNumber FROM tbJackets " +
                "WHERE DueDate IS NOT NULL AND DueDate < CONVERT(DATE, GETDATE()) " +
                "ORDER BY DueDate");
        }

        /* Render the tables.
         * grid: which table you are going to render.
         * query: SQL code for the table.
         * columnName: name of the column as it is in Edit Columns.
        */
        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            grid.Columns[columnName].DefaultCellStyle.Format = "d";

            grid.Rows.Clear();
            cm = new SqlCommand(query, con);
            con.Open();
            dr = cm.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                ++i;
                grid.Rows.Add(i,
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2],
                    dr[3].ToString()
                );
            }

            dr.Close();
            con.Close();
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

        /* Makes the pop up window with the client's information.
         * e: is the event from the click.
         * isPastDue: a flag checking if the function is working with the rented table or the past due.
         */
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

            cm = new SqlCommand(query, con);
            con.Open();
            
            // If there are no matches with that name, return.
            if((int) cm.ExecuteScalar() <= 0) {
                con.Close();
                return; 
            }
            con.Close();

            // Show the details of the row in a new form or dialog
            DialogBoxClient dialogBoxClient = new DialogBoxClient(rentee);
            dialogBoxClient.ShowDialog();
        }

        private void ButtonNewRental_Click(object sender, EventArgs e)
        {
            NewRentalModuleForm ModForm = new NewRentalModuleForm();
            ModForm.ShowDialog();
        }
    }

}
