using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Item2
    {
        [Key]
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("id_brand")]
        public Guid IdBrand
        {
            get; set;
        }

        [Column("id_client")]
        public Guid? IdClient
        {
            get; set;
        }

        [Column("serial_number")]
        public string SerialNumber
        {
            get; set;
        }

        [Column("type")]
        public string Type
        {
            get; set;
        }

        [Column("condition")]
        public string Condition
        {
            get; set;
        }

        [Column("business_model")]
        public string BusinessModel
        {
            get; set;
        }

        [Column("manufactured_at")]
        public DateTime ManufacturedAt
        {
            get; set;
        }

        [Column("due_date")]
        public DateTime? DueDate
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

        [ForeignKey(nameof(IdBrand))]
        public Brand Brand
        {
            get; set;
        }

        [ForeignKey(nameof(IdClient))]
        public Client Client
        {
            get; set;
        }
    }
}
