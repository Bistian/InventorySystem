using InventoryManagmentSystem.Database.Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace InventoryManagmentSystem.Database
{
    public class AppDbContext : DbContext
    {
        // EF6 can accept your raw connection string:

        static AppDbContext()
        {
            // no more auto‐drop/creates
            System.Data.Entity.Database.SetInitializer<AppDbContext>(null);
        }


        public AppDbContext(string connectionString) : base(connectionString)
        {
            // Optional: see generated SQL in the Output window
            Debug.WriteLine("EF 6 connecting to: " + Database.Connection.ConnectionString);
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Entities.Academy> Academies
        {
            get; set;
        }
        public DbSet<Address> Addresses
        {
            get; set;
        }
        public DbSet<Boots> Boots
        {
            get; set;
        }
        public DbSet<Brand> Brands
        {
            get; set;
        }
        public DbSet<Class> Classes
        {
            get; set;
        }
        public DbSet<Client> Clients
        {
            get; set;
        }
        public DbSet<Contact> Contacts
        {
            get; set;
        }
        public DbSet<FireDepartment> FireDepartments
        {
            get; set;
        }
        public DbSet<Helmet> Helmets
        {
            get; set;
        }
        public DbSet<Item2> Items
        {
            get; set;
        }
        public DbSet<ItemType> ItemTypes
        {
            get; set;
        }
        public DbSet<Jacket> Jackets
        {
            get; set;
        }
        public DbSet<Mask> Masks
        {
            get; set;
        }
        public DbSet<Measurement> Measurements
        {
            get; set;
        }
        public DbSet<Pants> Pants
        {
            get; set;
        }
        public DbSet<Rental> Rentals
        {
            get; set;
        }
        public DbSet<Student> Students
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // apply any additional Fluent mappings here…
            base.OnModelCreating(modelBuilder);
        }
    }
}
