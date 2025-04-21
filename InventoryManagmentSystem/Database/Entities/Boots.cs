using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Boots
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("size", TypeName = "numeric(4,1)")]
        public decimal Size
        {
            get; set;
        }

        [Column("material")]
        public string Material
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
        public Item Item
        {
            get; set;
        }
    }
}
