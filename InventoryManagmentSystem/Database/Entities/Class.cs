using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Class
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("id_academy")]
        public Guid IdAcademy
        {
            get; set;
        }

        [Column("name")]
        public string Name
        {
            get; set;
        }

        [Column("start_at")]
        public DateTime StartAt
        {
            get; set;
        }

        [Column("end_at")]
        public DateTime EndAt
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

        [ForeignKey(nameof(IdAcademy))]
        public Academy Academy
        {
            get; set;
        }
    }
}
