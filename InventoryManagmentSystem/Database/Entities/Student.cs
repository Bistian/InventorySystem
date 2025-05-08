using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Student
    {
        [Column("id_client")]
        public Guid IdClient
        {
            get; set;
        }

        [Column("id_class")]
        public Guid? IdClass
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
