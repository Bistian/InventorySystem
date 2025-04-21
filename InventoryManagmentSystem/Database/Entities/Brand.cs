using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Brand
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("name")]
        public string Name
        {
            get; set;
        }

        [Column("item_type")]
        public string ItemType
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
