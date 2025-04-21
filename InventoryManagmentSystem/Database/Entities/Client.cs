using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace InventoryManagmentSystem.Database.Entities
{
    public class Client
    {
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("id_address")]
        public Guid IdAddress
        {
            get; set;
        }

        [Column("id_class")]
        public Guid IdClass
        {
            get; set;
        }

        [Column("id_fire_department")]
        public Guid IdFireDepartment
        {
            get; set;
        }

        [Column("id_measurement")]
        public Guid IdMeasurement
        {
            get; set;
        }

        [Column("driver_license")]
        public string DriverLicense
        {
            get; set;
        }

        [Column("name")]
        public string Name
        {
            get; set;
        }

        [Column("phone_number")]
        public string PhoneNumber
        {
            get; set;
        }

        [Column("email")]
        public string Email
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

        [ForeignKey(nameof(IdAddress))]
        public Address Address
        {
            get; set;
        }

        [ForeignKey(nameof(IdFireDepartment))]
        public FireDepartment FireDepartment
        {
            get; set;
        }

        [ForeignKey(nameof(IdMeasurement))]
        public Measurement Measurement
        {
            get; set;
        }

        public ICollection<Class> Class { get; set; } = new List<Class>();
    }
}
