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

namespace InventoryManagmentSystem
{
    public partial class CreateClassForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        Dictionary<Guid, string> academyMap = new Dictionary<Guid, string>();

        public CreateClassForm()
        {
            InitializeComponent();
            LoadAcademies();
        }

        private void LoadAcademies()
        {
            string query = "SELECT Id, Name FROM tbAcademies";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Create a map with the uuid as a key and the name as a value.
                    academyMap.Add((Guid)reader[0], reader[1].ToString());
                    // Fill the combo box with academy names.
                    cbAcademy.Items.Add(reader[1]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }


        /// <summary>
        /// Check if item already exists on the table.
        /// </summary>
        /// <returns>1 = exists | 0 = dosn't exist | -1 = error. </returns>
        private int ItemAlreadyExists(Guid academyId)
        {
            string query = @"
                SELECT * 
                FROM tbClasses 
                WHERE AcademyId = @AcademyId AND
                    Name = @Name AND
                    StartDate = @Start AND
                    EndDate = @End
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            int found = 0;
            try
            {
                SqlCommand command = new SqlCommand(@query, connection);
                command.Parameters.AddWithValue("@AcademyId", academyId);
                command.Parameters.AddWithValue("@Name", tbClassName.Text);
                command.Parameters.AddWithValue("@Start", dpStartDate.Value.Date);
                command.Parameters.AddWithValue("@End", dpEndDate.Value.Date);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { found = 1; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                found = -1;
            }
            connection.Close();
            return found;
        }

        private bool AddClass()
        {

            // Get the uuid from the selected academy.
            Guid academyId = Guid.Empty;
            foreach(var item in academyMap)
            {
                if(item.Value == cbAcademy.Text)
                {
                    academyId = item.Key;
                }
            }

            int exists = ItemAlreadyExists(academyId);
            if(exists == 1 || exists == -1) { return false; }

            string query = @"
                INSERT INTO tbClasses
                (AcademyId, Name, StartDate, EndDate)
                VALUES(@AcademyId, @Name, @Start, @End)
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isAdded = true;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AcademyId", academyId);
                command.Parameters.AddWithValue("@Name", tbClassName.Text);
                command.Parameters.AddWithValue("@Start", dpStartDate.Value.Date);
                command.Parameters.AddWithValue("@End", dpEndDate.Value.Date);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                isAdded =  false;
            }
            connection.Close();

            if (isAdded)
            {
                // Reset fields.
                tbClassName.Text = string.Empty;
            }

            return isAdded;
        }

        private bool DeleteClass(DataGridViewRow row)
        {
            string message = "Do you want to delete this class permanently?";
            if (!HelperFunctions.YesNoMessageBox(message, "Delete Class")) { return false; }

            string query = @"
                DELETE FROM tbClasses
                WHERE Name = @Name AND
                    StartDate = @StartDate AND
                    EndDate = @EndDate AND
                    IsFinished = 1
            ";

            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isDeleted = true;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", row.Cells["column_name"].Value);
                command.Parameters.AddWithValue("@StartDate", row.Cells["column_start_date"].Value);
                command.Parameters.AddWithValue("@EndDate", row.Cells["column_end_date"].Value);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows Deleted: {rowsAffected}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                isDeleted =  false;
            }
            connection.Close();
            return isDeleted;
        }

        private bool UpdateClassStatus(DataGridViewRow row)
        {
            string query = @"
                UPDATE tbClasses
                SET IsFinished = @Finished
                WHERE Name = @Name AND
                        StartDate = @Start AND
                        EndDate = @End
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);

            bool isUpdated = true;
            bool isFinished = (bool)row.Cells["column_finished"].Value;
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Finished", (!isFinished));
                command.Parameters.AddWithValue("@Name", row.Cells["column_name"].Value);
                command.Parameters.AddWithValue("@Start", row.Cells["column_start_date"].Value);
                command.Parameters.AddWithValue("@End", row.Cells["column_end_date"].Value);
                connection.Open();
                command.ExecuteNonQuery();

            }   
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                isUpdated = false;
            }
            connection.Close();
            return isUpdated;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAcademy.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                if (tbClassName.Text.Length == 0) { throw new Exception("Name needs to be filled."); }
                if (dpStartDate.Value >= dpEndDate.Value ) { throw new Exception("End date cannot be equal or bigger than start date."); }
                if (dpStartDate.Value < new DateTime()) { throw new Exception("Start date cannot be today or before."); }
                if (!AddClass()) { throw new Exception("Failed to add class."); }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                Console.WriteLine (ex.Message);
                return;
            }
        }

    }
}
