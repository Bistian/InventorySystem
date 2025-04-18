using InventoryManagmentSystem.Academy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static InventoryManagmentSystem.Academy.AcademyForm;

namespace InventoryManagmentSystem
{
    public partial class CreateClassForm : Form
    {
        Dictionary<string, string> academyMap = new Dictionary<string, string>();

        private bool isUpdate = false;
        AcademyForm parent;
        private AcademyForm.Class editingClass;

        public CreateClassForm(AcademyForm parent)
        {
            InitializeComponent();
            LoadAcademies();
            this.parent = parent;
        }
        public CreateClassForm(AcademyForm parent, AcademyForm.Class classToEdit)
        {
            InitializeComponent();
            LoadAcademies();

            this.parent = parent;
            editingClass = classToEdit;
            InitUpdate();
        }

        private void InitUpdate()
        {
            isUpdate = true;
            btnAdd.Text = "Update";
            cbAcademy.Text = editingClass.academyName;
            cbAcademy.Enabled = false;

            btnResetName.Enabled = true;
            btnResetName.Visible = true;

            btnResetStart.Enabled = true;
            btnResetStart.Visible = true;

            btnResetEnd.Enabled = true;
            btnResetEnd.Visible = true;

            btnCancel.Enabled = true;
            btnCancel.Visible = true;

            tbClassName.Text = editingClass.name;
            dpStartDate.Value = editingClass.start;
            dpEndDate.Value = editingClass.end;

        }

        private void LoadAcademies()
        {
            academyMap = HelperSql.AcademyListNames();
            foreach(var item in academyMap.Values)
            {
                cbAcademy.Items.Add(item);
            }
        }

        /// <summary>
        /// Check if item already exists on the table.
        /// </summary>
        /// <returns>1 = exists | 0 = dosn't exist | -1 = error. </returns>
        private int ItemAlreadyExists(string academyId)
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
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@AcademyId", academyId);
                    command.Parameters.AddWithValue("@Name", tbClassName.Text);
                    command.Parameters.AddWithValue("@Start", dpStartDate.Value.Date);
                    command.Parameters.AddWithValue("@End", dpEndDate.Value.Date);
                    object result = command.ExecuteScalar();
                    if (result != null) { found = 1; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); found = -1; }
                finally { connection.Close(); }
            }
            return found;
        }

        private bool AddClass()
        {

            // Get the uuid from the selected academy.
            string academyId = "";
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
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@AcademyId", academyId);
                    command.Parameters.AddWithValue("@Name", tbClassName.Text);
                    command.Parameters.AddWithValue("@Start", dpStartDate.Value.Date);
                    command.Parameters.AddWithValue("@End", dpEndDate.Value.Date);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); isAdded = false; }
                finally { connection.Close(); }
            }

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
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", row.Cells["column_name"].Value);
                    command.Parameters.AddWithValue("@StartDate", row.Cells["column_start_date"].Value);
                    command.Parameters.AddWithValue("@EndDate", row.Cells["column_end_date"].Value);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); isDeleted = false; }
                finally { connection.Close(); }
            }
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
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Finished", (!isFinished));
                    command.Parameters.AddWithValue("@Name", row.Cells["column_name"].Value);
                    command.Parameters.AddWithValue("@Start", row.Cells["column_start_date"].Value);
                    command.Parameters.AddWithValue("@End", row.Cells["column_end_date"].Value);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); isUpdated = false; }
                finally { connection.Close(); }
            }
            return isUpdated;
        }

        private bool UpdateClass()
        {
            string query = @"
                Update tbClasses
                Set Name=@Name, StartDate=@Start, EndDate=@End
                Where Id=@Id
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            using (var connection = new SqlConnection(Program.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", tbClassName.Text);
                    command.Parameters.AddWithValue("@Start", dpStartDate.Value);
                    command.Parameters.AddWithValue("@End", dpEndDate.Value);
                    command.Parameters.AddWithValue("@Id", editingClass.uuid);
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { connection.Close(); }
            }
            return false;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(isUpdate)
            {
                if(!UpdateClass())
                {
                    return;
                }
                HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new ClassList(parent));
                this.Close();
                return;
            }

            try
            {
                if (cbAcademy.SelectedIndex < 0) { throw new Exception("Academy needs to be filled."); }
                if (tbClassName.Text.Length == 0) { throw new Exception("Name needs to be filled."); }
                if (dpStartDate.Value >= dpEndDate.Value ) { throw new Exception("End date cannot be equal or bigger than start date."); }
                if (dpStartDate.Value < new DateTime()) { throw new Exception("Start date cannot be today or before."); }
                if (!AddClass()) { throw new Exception("Failed to add class."); }

                ClassList ClassList = new ClassList(parent);
                Form currDocked = parent.panelDocker.Controls.OfType<Form>().FirstOrDefault();
                HelperFunctions.OpenChildFormToPanel(parent.panelDocker, ClassList, currDocked);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                Console.WriteLine (ex.Message);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HelperFunctions.OpenChildFormToPanel(parent.panelDocker, new ClassList(parent));
            this.Close();
        }

        private void btnResetName_Click(object sender, EventArgs e)
        {
            tbClassName.Text = editingClass.name;
        }

        private void btnResetStart_Click(object sender, EventArgs e)
        {
            dpStartDate.Value = editingClass.start;
        }

        private void btnResetEnd_Click(object sender, EventArgs e)
        {
            dpEndDate.Value = editingClass.end;
        }
    }
}
