using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Configuration;

namespace InventoryManagmentSystem
{
    public partial class DatabaseCreationModule : Form
    {
        private bool isInit;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
        SqlConnection connection;

        public DatabaseCreationModule(bool isInit = true)
        {
            InitializeComponent();
            this.isInit = isInit;
            labelName.Visible = false;

            // Configure form for docking if this class is not called on app init.
            if (!isInit)
            {
                BackColor = panelTop.BackColor;
                panelTop.Visible = false;
                panelTop.Enabled = false;
                ButtonClose.Visible = false;
                ButtonClose.Enabled = false;
                labelName.Text = "Database: " +  ConfigurationManager.AppSettings["databaseName"];
                labelName.Visible = true;
            }
        }

        private void btnNewDatabase_Click(object sender, EventArgs e)
        {
            string filePath = GetNewDatabasePath();
            // If user canceled the action, just return.
            if (filePath == null) { return; }

            CreateDatabase(filePath);

            UpdateConfigFile(filePath);

            CreateMainFormOnInit();

            this.Close();
        }

        private void btnFindDatabase_Click(object sender, EventArgs e)
        {
            var dialogBox = new OpenFileDialog();
            dialogBox.Filter = "SQL Server database files| *.mdf";
            dialogBox.ShowDialog();
            string filePath = dialogBox.FileName;
            // If user canceled the action, just return.
            if (filePath == "") { return; }

            UpdateConfigFile(filePath);

            CreateMainFormOnInit();

            this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// Get file path for new database.
        /// </summary>
        /// <returns>string file path</returns>
        private string GetNewDatabasePath()
        {
            // Open dialog box to create a new database.
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "SQL Server database files| *.mdf";

            if(saveDialog.ShowDialog() == DialogResult.OK) 
            {
                string filePath = saveDialog.FileName;
                string databaseName = Path.GetFileNameWithoutExtension(filePath);
                // Check if the file already exists.
                if (File.Exists(filePath))
                {
                    // Prompt the user for confirmation to overwrite.
                    string message = "The file already exists. Do you want to overwrite it?";
                    DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DeleteFileAndDatabase(databaseName);
                    }
                    else
                    {
                        // User canceled overwrite, exit the method.
                        return null;
                    }
                }
                return filePath;
            }
            return null;
        }

        /// <summary>
        /// Create a new database and its tables.
        /// </summary>
        /// <param name="connectionString"></param>
        private void CreateDatabase(string filePath)
        {
            string databaseName = Path.GetFileNameWithoutExtension(filePath);

            // Create the new database file
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql =
                    $"CREATE DATABASE {databaseName} " +
                    $"ON PRIMARY (NAME={databaseName}_Data, " +
                    $"FILENAME='{filePath}') " +
                    $"LOG ON (NAME={databaseName}_Log, " +
                    $"FILENAME='{filePath}.ldf')";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            string connectDatabase = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + filePath + ";Integrated Security=True;Connect Timeout=30";

            // Items
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbItems] (" +
                    "[Id] INT NOT NULL PRIMARY KEY," +
                    "[ItemType] VARCHAR(50);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            // History
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbHistories] (" +
                    "[Id] INT NOT NULL PRIMARY KEY," +
                    "[ItemId] INT NOT NULL," +
                    "[ClientId] INT NOT NULL," +
                    "[RentDate] DATE NOT NULL," +
                    "[ReturnDate] DATE);" +
                    "FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([id])," +
                    "FOREIGN KEY (ClientId) REFERENCES [dbo].[tbClients] ([Id]));";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Boots
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbBoots] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemId]          INT          NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NOT NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL," +
                "    [Material]        VARCHAR (50) NOT NULL)," +
                "    FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id]));";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Helmets
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbHelmets] (" +
                    "   [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                    "   [ItemId]          INT          NOT NULL," +
                    "   [Brand]           VARCHAR (50) NOT NULL," +
                    "   [SerialNumber]    VARCHAR (50) NOT NULL," +
                    "   [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                    "   [UsedNew]         VARCHAR (50) NOT NULL," +
                    "   [ManufactureDate] DATE         NOT NULL," +
                    "   [DueDate]         DATE         NULL," +
                    "   [Color]           VARCHAR (50) NOT NULL)," +
                    "   FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id]));";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Jackets
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbJackets] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemId]          INT          NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NOT NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL)," +
                "    FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id]));";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Pants
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbPants] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemId]          INT          NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL)," +
                "    FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id]));"; ;
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Clients
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbClients] (" +
                    "[Id]                    INT IDENTITY(1, 1) NOT NULL, " +
                    "[Name]                  VARCHAR(50) NOT NULL," +
                    "[Phone]                 VARCHAR(50) NOT NULL," +
                    "[Email]                 VARCHAR(50) NOT NULL," +
                    "[Academy]               VARCHAR(50) NOT NULL," +
                    "[DayNight]              VARCHAR(50) NULL," +
                    "[DriversLicenseNumber]  VARCHAR(50) NOT NULL," +
                    "[Address]               VARCHAR(50) NOT NULL," +
                    "[Chest]                 VARCHAR(50) NOT NULL," +
                    "[Sleeve]                VARCHAR(50) NOT NULL," +
                    "[Waist]                 VARCHAR(50) NOT NULL," +
                    "[Inseam]                VARCHAR(50) NOT NULL," +
                    "[Hips]                  VARCHAR(50) NOT NULL," +
                    "[Height]                VARCHAR(50) NOT NULL," +
                    "[Weight]                VARCHAR(50) NOT NULL," +
                    "[Notes]                 VARCHAR(MAX) NULL," +
                    "[FireTecRepresentative] VARCHAR(50) NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Departments
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbDepartment] (" +
                    "[DeptID]      INT IDENTITY(1, 1) NOT NULL, " +
                    "[DeptName]    VARCHAR(50) NOT NULL," +
                    "[ContactName] VARCHAR(50) NOT NULL," +
                    "[Phone]       VARCHAR(50) NOT NULL," +
                    "[Email]       VARCHAR(50) NOT NULL," +
                    "[Address]     VARCHAR(50) NOT NULL," +
                    "[City]        VARCHAR(50) NOT NULL," +
                    "[State]       VARCHAR(50) NOT NULL," +
                    "[Zip]         VARCHAR(50) NOT NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Users
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbUser] (" +
                    "[username] VARCHAR(50) NOT NULL," +
                    "[password] VARCHAR(50) NOT NULL," +
                    "[fullname] VARCHAR(50) NOT NULL);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            // Providers
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbProviders] (" +
                    "[itemType] VARCHAR(50) NOT NULL," +
                    "[provider] VARCHAR(50) NOT NULL);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

            // Prices
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbPrices] (" +
                    "[name] VARCHAR(50) NOT NULL," +
                    "[boots] FLOAT NOT NULL," +
                    "[helmets] FLOAT NOT NULL," +
                    "[jackets] FLOAT NOT NULL," +
                    "[pants] FLOAT NOT NULL);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        /// <summary>
        /// Update variables inside of App.config.
        /// </summary>
        /// <param name="filePath"></param>
        private void UpdateConfigFile(string filePath)
        {
            // Get the current connection string.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connectionStringSettings = config.ConnectionStrings.ConnectionStrings["MyConnectionString"];

            // Update the configuration file
            string databaseName = Path.GetFileNameWithoutExtension(filePath);
            config.AppSettings.Settings["databaseName"].Value = databaseName;
            connectionStringSettings.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + filePath + ";Integrated Security=True;Connect Timeout=30";
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the ConfigurationManager to reflect the changes
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");
            SqlConnection.ClearAllPools();
        }

        /// <summary>
        /// If app is initializing, create main form.
        /// </summary>
        private void CreateMainFormOnInit()
        {
            if (isInit)
            {
                this.Hide();
                MainForm ModForm = new MainForm();
                ModForm.ShowDialog();
            }
            else
            {
                string message = "Program needs to be restarted to switch to the new database.";
                DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void DeleteFileAndDatabase(string filePath)
        {
            DetachDatabase(filePath);
            DropDatabase(filePath);
            File.Delete(filePath);
        }

        /// <summary>
        /// Detaching a database releases its data and log files from the SQL Server instance.
        /// Detaching the database allows you to maintain a backup of the database files before deleting them permanently.
        /// It also ensures that the database is not actively used or accessed by any active connections or processes.
        /// </summary>
        /// <param name="databaseName"></param>
        private void DetachDatabase(string databaseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Detach the database
                    string detachCommand = $"USE master; EXEC sp_detach_db '{databaseName}'";
                    using (SqlCommand command = new SqlCommand(detachCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                MessageBox.Show("Database detached successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR DETACH DATABASE: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the database.
        /// </summary>
        /// <param name="databaseName"></param>
        private void DropDatabase(string databaseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Drop the database
                    string dropCommand = $"USE master; DROP DATABASE {databaseName}";
                    using (SqlCommand command = new SqlCommand(dropCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"ERROR DROP DATABASE: {ex.Message}");
            }
            
        }
    }
}
