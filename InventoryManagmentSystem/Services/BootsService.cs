using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class BootsService
    {
        private readonly AppDbContext _database;

        public BootsService(AppDbContext database)
        {
            this._database = database;
        }

        public Boots Add(Guid itemId, decimal size)
        {
            var boots = new Boots();
            boots.Id = itemId;
            boots.Size = size;
            _database.Boots.Add(boots);
            _database.SaveChanges();
            return boots;
        }

        public void Update(Boots boots)
        {
            try
            {
                _database.Entry(boots).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Boots boots)
        {
            try
            {
                _database.Boots.Remove(boots);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Delete(Guid itemId)
        {
            var boots = FindById(itemId);
            try
            {
                _database.Boots.Remove(boots);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Boots FindById(Guid id)
        {
            try
            {
                return _database.Boots.FirstOrDefault((System.Linq.Expressions.Expression<Func<Boots, bool>>)(b => b.Id == id));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
