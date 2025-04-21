using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Measurement
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("chest")]
        public string Chest
        {
            get; set;
        }

        [Column("sleeve")]
        public string Sleeve
        {
            get; set;
        }

        [Column("waist")]
        public string Waist
        {
            get; set;
        }

        [Column("inseam")]
        public string Inseam
        {
            get; set;
        }

        [Column("hips")]
        public string Hips
        {
            get; set;
        }

        [Column("height")]
        public string Height
        {
            get; set;
        }

        [Column("weight")]
        public string Weight
        {
            get; set;
        }

        [Column("gender")]
        public string Gender
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
