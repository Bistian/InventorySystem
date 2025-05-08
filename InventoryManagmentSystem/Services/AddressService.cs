using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class AddressService
    {
        private readonly AppDbContext _database;
        public AddressService(AppDbContext database)
        {
            this._database = database;
        }

        public Address Add(string street, string number, string city, string state, string zip)
        {
            var a = new Address()
            {
                Id = Guid.NewGuid(),
                Street = street,
                Number = number,
                City = city,
                State = state,
                Zip = zip,
                CreatedAt = DateTime.Now,
            };
            _database.Addresses.Add(a);
            _database.SaveChanges();
            return a;
        }

        public void Update(Address address)
        {
            try
            {
                _database.Entry(address).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid addressId)
        {
            try
            {
                _database.Entry(new Address() { Id = addressId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Address FindById(Guid addressId)
        {
            try
            {
                return _database.Addresses.FirstOrDefault(a => a.Id == addressId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public string Location(Guid addressId)
        {
            var a = FindById(addressId);
            return $"{a.Street} {a.Number}, {a.City}, {a.State}";
        }
    }
}
