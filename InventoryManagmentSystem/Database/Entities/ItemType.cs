using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class ItemType
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("type")]
        public string Type
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
