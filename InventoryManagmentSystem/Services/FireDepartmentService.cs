using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class FireDepartmentService
    {
        private readonly AppDbContext _database;
        public FireDepartmentService(AppDbContext database)
        {
            this._database = database;
        }

        public FireDepartment Add(Guid addressId, Guid contactId, string name)
        {
            var fd = new FireDepartment()
            {
                Id = Guid.NewGuid(),
                IdAddress = addressId,
                IdContact = contactId,
                Name = name,
                CreatedAt = new DateTime(),
            };

            _database.FireDepartments.Add(fd);
            _database.SaveChanges();
            return fd;
        }

        public void Update(FireDepartment fd)
        {
            try
            {
                _database.Entry(fd).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid fdId)
        {
            try
            {
                _database.Entry(new FireDepartment() { Id = fdId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<FireDepartment> FindAll()
        {
            try
            {
                var list = _database.FireDepartments.ToList();
                if (list.Count > 0)
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
