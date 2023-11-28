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
        string firetec = "Location='FIRETEC' OR Location='Fire-Tec' OR Location='FIRE TEC'";

        private void InitTables()
        {
            string query = HelperQuery.RentItems();
            query += $@"
                AND DueDate IS NOT NULL AND CAST(DueDate AS DATE)
                BETWEEN CAST(GETDATE() AS DATE) AND 
                DATEADD(DAY, {dueDays}, CAST(GETDATE() AS DATE))
            ";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            LoadTables(dataGridViewBeforeDue, query, "Due");

            query = HelperQuery.RentItems();
            query += " AND DueDate IS NOT NULL AND DATEDIFF(day, DueDate, GETDATE()) > 0";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            LoadTables(dataGridViewPastDue, query, "DueDate2");
        }

        private void LoadTables(DataGridView grid, string query, string columnName)
        {
            // Change the styling for the date column.
            grid.Columns[columnName].DefaultCellStyle.Format = "d";
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
                        reader[2]
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
            uint rented = HelperDatabaseCall.ItemRentCount(connection, "jacket");
            btnCoats.Text = $"{rented} Coats";
            rented = HelperDatabaseCall.ItemRentCount(connection, "pants");
            btnPants.Text = $"{rented} Pants";
            rented = HelperDatabaseCall.ItemRentCount(connection, "helmet");
            btnHelmets.Text = $"{rented} Helmets";
        }

        private void PrintStock()
        {
            var stock = HelperDatabaseCall.ItemStockCount(connection, "boots");
            ButtonInStockBoots.Text = $"{stock} Boots";
            stock = HelperDatabaseCall.ItemStockCount(connection, "helmet");
            ButtonInStockHelmets.Text = $"{stock} Helmets";
            stock = HelperDatabaseCall.ItemStockCount(connection, "jacket");
            ButtonInStockJackets.Text = $"{stock} Coats";
            stock = HelperDatabaseCall.ItemStockCount(connection, "pants");
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

            string rentee = row.Cells["Rentee"].Value.ToString();

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
