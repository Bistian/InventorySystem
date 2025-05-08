using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Helmet
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("color")]
        public string Color
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

        [ForeignKey(nameof(Id))]
        public Item2 Item
        {
            get; set;
        }
    }
}
