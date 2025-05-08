using System;

namespace InventoryManagmentSystem.Database.Types
{
    public class ItemFull
    {
        public Guid Id
        {
            get; set;
        }
        public Guid IdBrand
        {
            get; set;
        }
        public Guid? IdClient
        {
            get; set;
        }
        public string SerialNumber
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public string Brand
        {
            get; set;
        }
        public string Condition
        {
            get; set;
        }
        public string BusinessModel
        {
            get; set;
        }
        public DateTime? DueDate
        {
            get; set;
        }
        public DateTime ManufacturedAt
        {
            get; set;
        }
        public string Size
        {
            get; set;
        }
        public string Material
        {
            get; set;
        }
        public string Color
        {
            get; set;
        }
    }
}
