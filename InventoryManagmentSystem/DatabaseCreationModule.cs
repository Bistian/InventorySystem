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
        bool isInit;

        public DatabaseCreationModule(bool isInit = true)
        {
            InitializeComponent();
            this.isInit = isInit;
            if (!isInit)
            {
                BackColor = panelTop.BackColor;
                panelTop.Visible = false;
                panelTop.Enabled = false;
                ButtonClose.Visible = false;
                ButtonClose.Enabled = false;
            }
        }

        private string createDatabase()
        {
            string filePath = ""; // file path selected by the user

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "SQL Server database files| *.mdf";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // user selected a file path, save it
                filePath = saveDialog.FileName;
            }
            else
            {
                this.Dispose();
                return null;
            }

            string databaseName = Path.GetFileNameWithoutExtension(filePath);

            // Check if the database file already exists
            if (File.Exists(filePath))
            {
                MessageBox.Show("The database file already exists.");
                return "failed";
            }

            // Create the new database file
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
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
            }
            return filePath;
        }

        private void btnNewDatabase_Click(object sender, EventArgs e)
        {
           string filePath = createDatabase();
           // If user canceled the action, just return.
           if(filePath == null) { return; }
           string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+filePath+";Integrated Security=True;Connect Timeout=30";

            //Create the tables

            //Helmets
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbHelmets] (" +
                    "   [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                    "   [ItemType]        VARCHAR (50) DEFAULT ('Helmet') NOT NULL," +
                    "   [Brand]           VARCHAR (50) NOT NULL," +
                    "   [SerialNumber]    VARCHAR (50) NOT NULL," +
                    "   [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                    "   [UsedNew]         VARCHAR (50) NOT NULL," +
                    "   [ManufactureDate] DATE         NOT NULL," +
                    "   [DueDate]         DATE         NULL," +
                    "   [Color]           VARCHAR (50) NOT NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            //Jackets
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbJackets] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemType]        VARCHAR (50) DEFAULT ('Jacket') NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NOT NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            //Pants
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbPants] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemType]        VARCHAR (50) DEFAULT ('Pants') NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            //Boots
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbBoots] (" +
                "    [Id]              INT          IDENTITY (1, 1) NOT NULL," +
                "    [ItemType]        VARCHAR (50) DEFAULT ('Boots') NOT NULL," +
                "    [Brand]           VARCHAR (50) NOT NULL," +
                "    [SerialNumber]    VARCHAR (50) NOT NULL," +
                "    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL," +
                "    [UsedNew]         VARCHAR (50) NOT NULL," +
                "    [ManufactureDate] DATE         NOT NULL," +
                "    [DueDate]         DATE         NULL," +
                "    [Size]            VARCHAR (50) NOT NULL," +
                "    [Material]        VARCHAR (50) NOT NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            //Clients
             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                connection.Open();

                string sql =
                    "CREATE TABLE [dbo].[tbClients] (" +
                    "[Id]                    INT IDENTITY(1, 1) NOT NULL, " +
                    "[Name]                  VARCHAR(50) NOT NULL," +
                    "[Phone]                 VARCHAR(50) NOT NULL," +
                    "[Email]                 VARCHAR(50) NOT NULL," +
                    "[Academy]               VARCHAR(50) NOT NULL," +
                    "[DayNight]              VARCHAR(50) NOT NULL," +
                    "[DriversLicenseNumber]  VARCHAR(50) NOT NULL," +
                    "[Address]               VARCHAR(50) NOT NULL," +
                    "[FireTecRepresentative] VARCHAR(50) NULL);";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
             }

            //Departments
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            }

            //General
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbGeneral] (" +
                    "[Id]           INT NOT NULL," +
                    "[ItemType] NCHAR(10) NULL," +
                    "[SerialNum] NCHAR(10) NULL," +
                    "[Brand] NCHAR(10) NULL," +
                    "[CurrLocation] NCHAR(10) NULL);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            //Users
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                    "CREATE TABLE[dbo].[tbUser] (" +
                    "[username] VARCHAR(50) NOT NULL," +
                    "[password] VARCHAR(50) NOT NULL," +
                    "[fullname] VARCHAR(50) NOT NULL);";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            // Get the current connection string
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connectionStringSettings = config.ConnectionStrings.ConnectionStrings["MyConnectionString"];
            string GlobalConnectionString = connectionStringSettings.ConnectionString;

            // Modify the connection string
            GlobalConnectionString = connectionString;

            // Update the configuration file
            connectionStringSettings.ConnectionString = GlobalConnectionString;
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the ConfigurationManager to reflect the changes
            ConfigurationManager.RefreshSection("connectionStrings");

            if(isInit)
            {
                this.Dispose();
                MainForm ModForm = new MainForm();
                ModForm.ShowDialog();
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnFindDatabase_Click(object sender, EventArgs e)
        {
            // Select existing database.
            string filePath = "";
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "SQL Server database files| *.mdf";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // user selected a file path, save it.
                filePath = saveDialog.FileName;
            }
            else
            {
                this.Dispose();
                return;
            }

            string databaseName = Path.GetFileNameWithoutExtension(filePath);

            // Get the current connection string.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connectionStringSettings = config.ConnectionStrings.ConnectionStrings["MyConnectionString"];

            // Update the configuration file
            connectionStringSettings.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + filePath + ";Integrated Security=True;Connect Timeout=30";
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the ConfigurationManager to reflect the changes
            ConfigurationManager.RefreshSection("connectionStrings");

            if (isInit)
            {
                this.Dispose();
                MainForm ModForm = new MainForm();
                ModForm.ShowDialog();
            }
            else
            {
                this.Dispose();
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Module?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

    }
}
