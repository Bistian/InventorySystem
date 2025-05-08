using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class FireDepartment
    {
        [Column("id")]
        public Guid Id
        {
            get; set; 
        }

        [Column("id_address")]
        public Guid IdAddress
        {
            get; set;
        }

        [Column("id_contact")]
        public Guid IdContact
        {
            get; set;
        }

        [Column("name")]
        public string Name
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

        [ForeignKey(nameof(IdAddress))]
        public Address Address
        {
            get; set;
        }

        [ForeignKey(nameof(IdContact))]
        public Contact Contact
        {
            get; set;
        }
    }
}
