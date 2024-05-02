using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem
{
    public partial class HomeForm : Form
    {
        public int dueDays;

        public HomeForm()
        {
            InitializeComponent();
            PrintRented();
            PrintStock();
            dueDays = SettingsData.Instance.dueDaysFromToday;
            labelDueDate.Text = $"Due Within {dueDays} Days";
            InitTables();
        }

        // Get the current connection string
        static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //Creating command
        SqlConnection connection = new SqlConnection(connectionString);

        //Used for counting rentals
        int total = 0;

        private Form activeForm = null;

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
                ) AS i ON c.Id = i.Location;
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
                      AND DueDate BETWEEN GETDATE() AND DATEADD(DAY, 10, GETDATE())
                ) AS i ON c.Id = i.Location
                JOIN (
                    SELECT Location, COUNT(*) AS ItemCount
                    FROM tbItems
                    WHERE Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND Condition NOT IN ('Retired') 
                      AND DueDate IS NOT NULL 
                      AND DueDate BETWEEN GETDATE() AND DATEADD(DAY, ${dueDays}, GETDATE())
                    GROUP BY Location
                ) AS ic ON c.Id = ic.Location
                WHERE i.RowNum = 1;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private void InitTables()
        {
            LoadTables(dataGridViewBeforeDue, QueryForRented(), "column_due");
            LoadTables(dataGridViewPastDue, QueryForPastDue(), "column_due2");
            HelperFunctions.DataGridHideTime(dataGridViewBeforeDue, "column_due");
            HelperFunctions.DataGridHideTime(dataGridViewPastDue, "column_due2");
        }

        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            HelperFunctions.DataGridHideTime(grid, columnName);
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        private void PrintRented()
        {
            uint rented = HelperSql.ItemRentCount(connection, "jacket");
            btnCoats.Text = $"{rented} Coats";
            rented = HelperSql.ItemRentCount(connection, "pants");
            btnPants.Text = $"{rented} Pants";
            rented = HelperSql.ItemRentCount(connection, "helmet");
            btnHelmets.Text = $"{rented} Helmets";
        }

        private void PrintStock()
        {
            var stock = HelperSql.ItemStockCount(connection, "boots");
            ButtonInStockBoots.Text = $"{stock} Boots";
            stock = HelperSql.ItemStockCount(connection, "helmet");
            ButtonInStockHelmets.Text = $"{stock} Helmets";
            stock = HelperSql.ItemStockCount(connection, "jacket");
            ButtonInStockJackets.Text = $"{stock} Coats";
            stock = HelperSql.ItemStockCount(connection, "pants");
            ButtonInStockPants.Text = $"{stock} Pants";
        }

        private void OpenDockedForm(string formType, string ItemType)
        {
            Form childForm = null;
            //access the main panel in the parent form that will be docked into
            Panel MainPanel = this.ParentForm.Controls.Find("MainPanel", true).FirstOrDefault() as Panel;

            //deciding the type of form that will be docked
            if (formType == "RentalForm")
            {
                childForm = new RentalForm(ItemType);
            }
            else if (formType == "NewRentalModuleForm")
            {
                childForm = new NewRentalModuleForm();
            }
            else if (formType == "ExistingCustomerModuleForm")
            {
                childForm = new ExistingCustomerModuleForm();
            }
            else if (formType == "InventoryForm")
            {
                childForm = new InventoryForm(ItemType);
            }


            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.Dispose();
        }

        private void dataGridViewBeforeDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridViewBeforeDue.Rows[e.RowIndex];
            string column = dataGridViewBeforeDue.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_rentee"].Value.ToString();
            string clientId = row.Cells["column_id"].Value.ToString();


            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(clientId);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void dataGridViewPastDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridViewPastDue.Rows[e.RowIndex];
            string column = dataGridViewPastDue.Columns[e.ColumnIndex].Name;

            string clientName = row.Cells["column_rentee2"].Value.ToString();
            string clientId = row.Cells["column_id2"].Value.ToString();


            var parentForm = this.ParentForm as MainForm;
            NewRentalModuleForm Profile = new NewRentalModuleForm(null, clientName);
            try
            {
                Profile.LoadProfile(clientId);
                parentForm.openChildForm(Profile);

                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR Existing Customer Module:{ex.Message}");
            }
        }

        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            OpenDockedForm("NewRentalModuleForm", null);
        }

        private void buttonActiveRental_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as MainForm;
            OpenDockedForm("ExistingCustomerModuleForm", null);
            parentForm.ColorTabSwitch("ActiveRentals", false);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            OpenDockedForm("InventoryForm", "Jacket");
        }

        private void ButtonInStockJackets_Click(object sender, EventArgs e)
        {
            OpenDockedForm("InventoryForm", "Jacket");
        }

        private void ButtonInStockPants_Click(object sender, EventArgs e)
        {
            OpenDockedForm("InventoryForm", "Pants");
        }

        private void ButtonInStockHelmets_Click(object sender, EventArgs e)
        {
            OpenDockedForm("InventoryForm", "Helmet");
        }

        private void ButtonInStockBoots_Click(object sender, EventArgs e)
        {
            OpenDockedForm("InventoryForm", "Boots");
        }

        private void btnRented_Click(object sender, EventArgs e)
        {
            OpenDockedForm("RentalForm", null);
        }

        private void btnCoats_Click(object sender, EventArgs e)
        {
            OpenDockedForm("RentalForm", "Jacket");
        }

        private void btnPants_Click(object sender, EventArgs e)
        {
            OpenDockedForm("RentalForm", "Pants");
        }

        private void btnHelmets_Click(object sender, EventArgs e)
        {
            OpenDockedForm("RentalForm", "Helmet");
        }
    }
}
