using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Column("is_active")]
        public bool IsActive
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




/*
 [Table("tbClients")]
    public class Client
    {
        [Key]
        [Column("id")]
        public Guid Id
        {
            get; set;
        }

        [Column("Address")]
        public string Address
        {
            get; set;
        }

        [Column("Academy")]
        public string Academy
        {
            get; set;
        }

        [Column("Type")]
        public string Type
        {
            get; set;
        }

        [Column("IdClass")]
        public Guid ?IdClass
        {
            get; set;
        }

        [Column("FireTecRepresentative")]
        public string FireTecRepresentative
        {
            get; set;
        }

        [Column("DriversLicenseNumber")]
        public string DriverLicense
        {
            get; set;
        }

        [Column("Location")]
        public string Location
        {
            get; set;
        }

        [Column("Phone")]
        public string PhoneNumber
        {
            get; set;
        }

        [Column("Email")]
        public string Email
        {
            get; set;
        }

        [Column("IsActive")]
        public bool IsActive
        {
            get; set;
        }

        [Column("Chest")]
        public string Chest
        {
            get; set;
        }

        [Column("Sleeve")]
        public string Sleeve
        {
            get; set;
        }

        [Column("Waist")]
        public string Waist
        {
            get; set;
        }

        [Column("Inseam")]
        public string Inseam
        {
            get; set;
        }

        [Column("Hips")]
        public string Hips
        {
            get; set;
        }

        [Column("Height")]
        public string Height
        {
            get; set;

        }

        [Column("Weight")]
        public string Weight
        {
            get; set;
        }

        [Column("Notes")]
        public string Notes
        {
            get; set;
        }

        public ICollection<Class> Class { get; set; } = new List<Class>();
    }
 */
