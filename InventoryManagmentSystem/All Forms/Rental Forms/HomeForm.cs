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
                    SELECT Location, DueDate, COUNT(*) AS ItemCount
                    FROM tbItems AS i_inner
                    WHERE i_inner.Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND i_inner.Condition NOT IN ('Retired') 
                      AND i_inner.DueDate IS NOT NULL 
                      AND i_inner.DueDate = (
                          SELECT MAX(DueDate)
                          FROM tbItems
                          WHERE Location = i_inner.Location
                            AND DueDate < GETDATE()
                      )
                    GROUP BY Location, DueDate
                ) AS i ON c.Id = i.Location;
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return query;
        }

        private string QueryForRented()
        {
            string query = $@"
                SELECT c.Id, c.Name, i.DueDate AS ClosestDueDate, i.ItemCount
                FROM tbClients AS c
                JOIN (
                    SELECT Location, DueDate, COUNT(*) AS ItemCount
                    FROM tbItems AS i_inner
                    WHERE i_inner.Location NOT IN ('Fire-Tec', 'FIRE TEC', 'FIRETEC') 
                      AND i_inner.Condition NOT IN ('Retired') 
                      AND i_inner.DueDate IS NOT NULL 
                      AND i_inner.DueDate = (
                          SELECT TOP 1 DueDate
                          FROM tbItems
                          WHERE Location = i_inner.Location
                            AND DueDate <= GETDATE()
                          ORDER BY ABS(DATEDIFF(day, DueDate, GETDATE()))
                      )
                    GROUP BY Location, DueDate
                ) AS i ON c.Id = i.Location
                    OR c.DriversLicenseNumber = i.Location;
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
            ClientPopUp(e, true);
        }

        private void dataGridViewPastDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            ClientPopUp(e, false);
        }

        /// <summary>
        /// Pop up with client information when client's name is clicked on table.
        /// </summary>
        /// <param name="e">Event that was triggered.</param>
        /// <param name="isBeforeDue">Boolean representing which table was clicked.</param>
        private void ClientPopUp(DataGridViewCellEventArgs e, bool isBeforeDue)
        {
            // Check if the clicked cell is in a row
            if (e.RowIndex < 0) { return; }

            // Column 2 is the only one this function should operate on.
            if (e.ColumnIndex != 2) { return; }

            // Get the data from rentee at that row.
            DataGridViewRow row;
            if (isBeforeDue)
            {
                row = dataGridViewBeforeDue.Rows[e.RowIndex];
            }
            else
            {
                row = dataGridViewPastDue.Rows[e.RowIndex];
            }

            string rentee = string.Empty;
            try
            {
                rentee = row.Cells["column_rentee"].Value.ToString();
            }
            catch
            {
                rentee = row.Cells["column_rentee2"].Value.ToString();
            }


            // Check if there is at least one item with that name on the clints table.
            string query = $@"
                SELECT COUNT(*) FROM tbClients   
                WHERE Name ='{rentee}'
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // If there are no matches with that name, return.
                if ((int)command.ExecuteScalar() > 0)
                {
                    // Show the details of the row in a new form or dialog
                    DialogBoxClient dialogBoxClient = new DialogBoxClient(rentee);
                    dialogBoxClient.ShowDialog();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }
            finally { connection.Close(); }
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
