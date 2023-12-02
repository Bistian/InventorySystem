using System;

namespace InventoryManagmentSystem
{
    public class Boots
    {
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string AcquisitionDate { get; set; }
        public string ManufactureDate { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
    }

    public class Helmet
    {
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string AcquisitionDate { get; set; }
        public string ManufactureDate { get; set; }
        public string Color { get; set; }
    }

    public class History
    {
        public int Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid ClientId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public string ItemType { get; set; }
        public string DueDate { get; set; }
        public string SerialNumber { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public string BusinessModel { get; set; }
        public object Specifications { get; set; }
    }

    public class Jacket
    {
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string AcquisitionDate { get; set; }
        public string ManufactureDate { get; set; }
        public string Size { get; set; }
    }

    public class Mask
    {
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string AcquisitionDate { get; set; }
        public string ManufactureDate { get; set; }
        public string Size { get; set; }
    }

    public class Pants
    {
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string AcquisitionDate { get; set; }
        public string ManufactureDate { get; set; }
        public string Size { get; set; }
    }
}
