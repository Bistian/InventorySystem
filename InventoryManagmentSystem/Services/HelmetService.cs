using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class HelmetService
    {
        private readonly AppDbContext _database;

        public HelmetService(AppDbContext database)
        {
            this._database = database;
        }

        public Helmet Add(Guid itemId, string color)
        {
            var helmet = new Helmet();
            helmet.Id = itemId;
            helmet.Color = color;
            _database.Helmets.Add(helmet);
            _database.SaveChanges();
            return helmet;
        }

        public void Update(Helmet helmet)
        {
            try
            {
                _database.Entry(helmet).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Helmet helmet)
        {
            try
            {
                _database.Helmets.Remove(helmet);
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
            var helmet = FindById(itemId);
            try
            {
                _database.Helmets.Remove(helmet);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Helmet FindById(Guid id)
        {
            try
            {
                return _database.Helmets.FirstOrDefault((System.Linq.Expressions.Expression<Func<Helmet, bool>>)(b => b.Id == id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
