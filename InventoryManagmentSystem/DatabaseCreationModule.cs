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
using System.Collections;

namespace InventoryManagmentSystem
{
    public partial class DatabaseCreationModule : Form
    {
        private bool isInit;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";

        public DatabaseCreationModule(bool isInit = true)
        {
            InitializeComponent();
#if DEBUG
            btnDeleteDatabase.Enabled = true;
            btnDeleteDatabase.Visible = true;
#endif

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

            bool isOkay = CreateDatabase(filePath);
            if(!isOkay)
            {
                DeleteFileAndDatabase(filePath);
                this.Close();
                return;
            }

            UpdateConfigFile(filePath);

            CreateMainFormOnInit();

            this.Close();
        }

        private void btnFindDatabase_Click(object sender, EventArgs e)
        {
            string filePath = ChooseDatabaseFile();
            // If user canceled the action, just return.
            if (filePath == "") { return; }

            UpdateConfigFile(filePath);

            CreateMainFormOnInit();

            this.Close();
        }

        /// <summary>
        /// Ask user to find a database file localy.
        /// </summary>
        /// <returns>Name of the database.</returns>
        private string ChooseDatabaseFile()
        {
            var dialogBox = new OpenFileDialog();
            dialogBox.Filter = "SQL Server database files| *.mdf";
            dialogBox.ShowDialog();
            return dialogBox.FileName;
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
        /// Used as part the create tables call.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private bool RunQuery(SqlConnection connection, string query)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CreateTableClasses(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbClasses] (
                [Id]            INT IDENTITY(1, 1) NOT NULL,
                [Name]          VARCHAR(50) NOT NULL,
                [StartDate]     DATE NOT NULL,
                [EndDate]       DATE NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableClients(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbClients] (
                [Id]                    UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
                [IdClass]               INT NULL,
                [Name]                  VARCHAR(50) NOT NULL,
                [Phone]                 VARCHAR(50) NOT NULL,
                [Email]                 VARCHAR(50) NOT NULL,
                [Academy]               VARCHAR(50) NOT NULL,
                [Type]                  VARCHAR(50) NULL,
                [DriversLicenseNumber]  VARCHAR(50) NOT NULL,
                [Address]               VARCHAR(50) NOT NULL,
                [Chest]                 VARCHAR(50) NOT NULL,
                [Sleeve]                VARCHAR(50) NOT NULL,
                [Waist]                 VARCHAR(50) NOT NULL,
                [Inseam]                VARCHAR(50) NOT NULL,
                [Hips]                  VARCHAR(50) NOT NULL,
                [Height]                VARCHAR(50) NOT NULL,
                [Weight]                VARCHAR(50) NOT NULL,
                [Notes]                 VARCHAR(MAX) NULL,
                [FireTecRepresentative] VARCHAR(50) NULL,
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableItems(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbItems] (
                [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
                [ItemType] VARCHAR(50)
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableItemTypes(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbItemTypes] (
                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                [ItemType] VARCHAR (50) NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableHistories(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbHistories] (
                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                [ItemId] UNIQUEIDENTIFIER NOT NULL,
                [ClientId] UNIQUEIDENTIFIER NOT NULL,
                [RentDate] DATE NOT NULL,
                [ReturnDate] DATE,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id]),
                FOREIGN KEY (ClientId) REFERENCES [dbo].[tbClients] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableBoots(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbBoots] (
                [ItemId]          UNIQUEIDENTIFIER NOT NULL,
                [Brand]           VARCHAR (50) NOT NULL,
                [SerialNumber]    VARCHAR (50) NOT NULL,
                [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
                [UsedNew]         VARCHAR (50) NOT NULL,
                [ManufactureDate] DATE         NOT NULL,
                [DueDate]         DATE         NULL,
                [Size]            VARCHAR (50) NOT NULL,
                [Material]        VARCHAR (50) NOT NULL,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableHelmets(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbHelmets] (
                [ItemId]          UNIQUEIDENTIFIER NOT NULL,
                [Brand]           VARCHAR (50) NOT NULL,
                [SerialNumber]    VARCHAR (50) NOT NULL,
                [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
                [UsedNew]         VARCHAR (50) NOT NULL,
                [ManufactureDate] DATE         NOT NULL,
                [DueDate]         DATE         NULL,
                [Color]           VARCHAR (50) NOT NULL,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableJackets(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbJackets] (
                [ItemId]          UNIQUEIDENTIFIER NOT NULL,
                [Brand]           VARCHAR (50) NOT NULL,
                [SerialNumber]    VARCHAR (50) NOT NULL,
                [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
                [UsedNew]         VARCHAR (50) NOT NULL,
                [ManufactureDate] DATE         NOT NULL,
                [DueDate]         DATE         NULL,
                [Size]            VARCHAR (50) NOT NULL,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableMasks(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbMasks] (
                [ItemId]          UNIQUEIDENTIFIER NOT NULL,
                [Brand]           VARCHAR (50) NOT NULL,
                [SerialNumber]    VARCHAR (50) NOT NULL,
                [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
                [UsedNew]         VARCHAR (50) NULL,
                [ManufactureDate] DATE         NOT NULL,
                [DueDate]         DATE         NULL,
                [Size]            VARCHAR (50) NOT NULL,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTablePants(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE [dbo].[tbPants] (
                [ItemId]          UNIQUEIDENTIFIER NOT NULL,
                [Brand]           VARCHAR (50) NOT NULL,
                [SerialNumber]    VARCHAR (50) NOT NULL,
                [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
                [UsedNew]         VARCHAR (50) NULL,
                [ManufactureDate] DATE         NOT NULL,
                [DueDate]         DATE         NULL,
                [Size]            VARCHAR (50) NOT NULL,
                FOREIGN KEY (ItemId) REFERENCES [dbo].[tbItems] ([Id])
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableDepartments(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbDepartments] (
                [DeptID]      INT IDENTITY(1, 1) NOT NULL,
                [DeptName]    VARCHAR(50) NOT NULL,
                [ContactName] VARCHAR(50) NOT NULL,
                [Phone]       VARCHAR(50) NOT NULL,
                [Email]       VARCHAR(50) NOT NULL,
                [Address]     VARCHAR(50) NOT NULL,
                [City]        VARCHAR(50) NOT NULL,
                [State]       VARCHAR(50) NOT NULL,
                [Zip]         VARCHAR(50) NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableUsers(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbUsers] (
                [username] VARCHAR(50) NOT NULL,
                [password] VARCHAR(50) NOT NULL,
                [fullname] VARCHAR(50) NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableBrands(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbBrands] (
                [ItemType] VARCHAR(50) NOT NULL,
                [Brand] VARCHAR(50) NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTableAcademies(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbAcademies] (
                [AcademyName] VARCHAR(50) NOT NULL,
                [Brand] VARCHAR(50) NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        private bool CreateTablePrices(SqlConnection connection)
        {
            string query = @"
                CREATE TABLE[dbo].[tbPrices] (
                [Name] VARCHAR(50) NOT NULL,
                [Boots] FLOAT NOT NULL,
                [Helmet] FLOAT NOT NULL,
                [Jacket] FLOAT NOT NULL,
                [Mask] FLOAT NOT NULL,
                [Pants] FLOAT NOT NULL
            );";
            HelperFunctions.RemoveLineBreaksFromString(ref query);
            return RunQuery(connection, query);
        }

        /// <summary>
        /// Create a new database and its tables.
        /// </summary>
        /// <param name="connectionString"></param>
        private bool CreateDatabase(string filePath)
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
            using (SqlConnection connection = new SqlConnection(connectDatabase))
            {
                string error_message = "Failed to create table for ";
                try
                {
                    if (!CreateTableClasses(connection)) { throw new Exception(error_message + "classes"); }
                    if (!CreateTableClients(connection)) { throw new Exception(error_message + "client"); }
                    if (!CreateTableItems(connection)) { throw new Exception(error_message + "items"); }
                    if (!CreateTableItemTypes(connection)) { throw new Exception(error_message + "item types"); }
                    if (!CreateTableHistories(connection)) { throw new Exception(error_message + "histories"); }
                    if (!CreateTableBoots(connection)) { throw new Exception(error_message + "boots"); }
                    if (!CreateTableHelmets(connection)) { throw new Exception(error_message + "helmets"); }
                    if (!CreateTableJackets(connection)) { throw new Exception(error_message + "jackets"); }
                    if (!CreateTableMasks(connection)) { throw new Exception(error_message + "masks"); }
                    if (!CreateTablePants(connection)) { throw new Exception(error_message + "pants"); }
                    if (!CreateTableDepartments(connection)) { throw new Exception(error_message + "departments"); }
                    if (!CreateTableUsers(connection)) { throw new Exception(error_message + "users"); }
                    if (!CreateTableBrands(connection)) { throw new Exception(error_message + "brands"); }
                    if (!CreateTableAcademies(connection)) { throw new Exception(error_message + "academies"); }
                    if (!CreateTablePrices(connection)) { throw new Exception(error_message + "prices"); }
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                    return false;
                }
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
            DropDatabase(filePath);
            DetachDatabase(filePath);
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
            string fileName = Path.GetFileNameWithoutExtension(databaseName);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Detach the database
                    string detachCommand = $"EXEC sp_detach_db @dbname = N'{fileName}'";
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
            string fileName = Path.GetFileNameWithoutExtension(databaseName);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Drop the database
                    string dropCommand = $"USE master; DROP DATABASE {fileName}";
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

        /// <summary>
        /// Used by devs to delete a database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            string filePath = ChooseDatabaseFile();
            // If user canceled the action, just return.
            if (filePath == "") { return; }

            DeleteFileAndDatabase(filePath);
        }
    }
}
