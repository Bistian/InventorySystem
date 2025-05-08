using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class ContactService
    {
        private readonly AppDbContext _database;
        public ContactService(AppDbContext database)
        {
            this._database = database;
        }

        public Contact Add(string name, string email, string phoneNumber)
        {
            var c = new Contact()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                CreatedAt = DateTime.Now,
            };
            _database.Contacts.Add(c);
            _database.SaveChanges();
            return c;
        }

        public void Update(Contact contact)
        {
            try
            {
                _database.Entry(contact).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid contactId)
        {
            try
            {
                _database.Entry(new Contact() { Id = contactId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Contact FindById(Guid contactId)
        {
            try
            {
                return _database.Contacts.FirstOrDefault(a => a.Id == contactId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
