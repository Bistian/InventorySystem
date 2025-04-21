using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Database.Entities
{
    internal class Rental
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("id_client")]
        public Guid IdClient
        {
            get; set;
        }

        [Column("id_item")]
        public Guid IdItem
        {
            get; set;
        }

        [Column("id_representative")]
        public Guid? IdRepresentative
        {
            get; set;
        }

        [Column("notes")]
        public string Notes
        {
            get; set;
        }

        [Column("rented_at")]
        public DateTime RentedAt
        {
            get; set;
        }

        [Column("returned_at")]
        public DateTime ReturnedAt
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

        [ForeignKey(nameof(IdClient))]
        public Client Client
        {
            get; set;
        }

        [ForeignKey(nameof(IdItem))]
        public Item Item
        {
            get; set;
        }

        //[ForeignKey(nameof(IdRepresentative))]
        //public Representative Representative
        //{
        //    get; set;
        //}
    }
}
