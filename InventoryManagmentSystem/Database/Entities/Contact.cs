using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Contact
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("name")]
        public Guid Name
        {
            get; set;
        }

        [Column("email")]
        public Guid Email
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
