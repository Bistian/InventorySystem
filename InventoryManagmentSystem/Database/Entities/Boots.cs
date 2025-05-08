using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Boots
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("size")]
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
        public Item2 Item
        {
            get; set;
        }
    }
}
