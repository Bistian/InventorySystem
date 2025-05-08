using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Address
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("street")]
        public string Street
        {
            get; set;
        }

        [Column("number")]
        public string Number
        {
            get; set;
        }

        [Column("city")]
        public string City
        {
            get; set;
        }

        [Column("state")]
        public string State
        {
            get; set;
        }

        [Column("zip")]
        public string Zip
        {
            get; set;
        }

        [Column("created_at")]
        public DateTime CreatedAt
        {
            get; set;
        }

        [Column("updated_at")]
        public DateTime UpdatedAt
        {
            get; set;
        }
    }
}
