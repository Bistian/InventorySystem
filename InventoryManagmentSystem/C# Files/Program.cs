using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InventoryManagmentSystem.Config_Files;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Services;

namespace InventoryManagmentSystem
{
    internal static class Program
    {
        // Global settings
        public static SettingsManager SettingsManager
        {
            get; private set;
        }
        public static string ConnectionString
        {
            get; private set;
        }

        // Global Services
        public static AcademyService AcademyService
        {
            get; private set; 
        }
        public static AddressService AddressService
        {
            get; private set;
        }
        public static BootsService BootsService
        {
            get; private set;
        }
        public static BrandService BrandService
        {
            get; private set;
        }
        public static ClassService ClassService
        {
            get; private set;
        }
        public static ClientService ClientService
        {
            get; private set; 
        }
        public static ContactService ContactService
        {
            get; private set;
        }
        public static FireDepartmentService FireDepartmentService
        {
            get; private set;
        }
        public static HelmetService HelmetService
        {
            get; private set;
        }
        public static ItemService ItemService
        {
            get; private set;
        }
        public static JacketService JacketService
        {
            get; private set;
        }
        public static MaskService MaskService
        {
            get; private set;
        }
        public static MeasurementService MeasurementService
        {
            get; private set;
        }
        public static PantsService PantsService
        {
            get; private set;
        }
        public static RentalService RentalService
        {
            get; private set;
        }
        public static StudentService StudentService
        {
            get; private set;
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Debug();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1) Load JSON‐based settings
            SettingsManager = new SettingsManager();

            // 2) Get the current connection string
            ConnectionString = DatabaseConfig.GetConnectionString();

            // 3) Dependency Injection container
            var services = new ServiceCollection();
            services.AddSingleton(SettingsManager);

            var database = new AppDbContext(ConnectionString);
            AcademyService = new AcademyService(database);
            AddressService = new AddressService(database);
            BootsService = new BootsService(database);
            BrandService = new BrandService(database);
            ClassService = new ClassService(database);
            ClientService = new ClientService(database);
            ContactService = new ContactService(database);
            FireDepartmentService = new FireDepartmentService(database);
            HelmetService = new HelmetService(database);
            ItemService = new ItemService(database);
            JacketService = new JacketService(database);
            MaskService = new MaskService(database);
            MeasurementService = new MeasurementService(database);
            PantsService = new PantsService(database);
            RentalService = new RentalService(database);
            StudentService = new StudentService(database);

            // 4) register your AppDbContext with the runtime string
            services.AddScoped<AppDbContext>(serviceProvider =>
             new AppDbContext(DatabaseConfig.GetConnectionString())
            );

            // 5) register your services
            services.AddScoped<MainForm>();

            var provider = services.BuildServiceProvider();

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            MessageBox.Show($"An unhandled exception occurred: {exception?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Hack to normalize class activities
        private static void UpdateClassActivity(SqlConnection connection)
        {
            string query = "UPDATE TBCLASSES " +
                           "SET isFinished = 'true' " +
                           "WHERE endDate <= CAST(GETDATE() AS DATE); ";

            var command = new SqlCommand(query, connection);
            try
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private static void Debug()
        {
#if DEBUG
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
        }
    }
}
