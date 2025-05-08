using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class JacketService
    {
        private readonly AppDbContext _database;

        public JacketService(AppDbContext database)
        {
            this._database = database;
        }

        public Jacket Add(Guid itemId,string size)
        {
            var jacket = new Jacket();
            jacket.Id = itemId;
            jacket.Size = size;
            _database.Jackets.Add(jacket);
            _database.SaveChanges();
            return jacket;
        }

        public void Update(Jacket jacket)
        {
            try
            {
                _database.Entry(jacket).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Jacket jacket)
        {
            try
            {
                _database.Jackets.Remove(jacket);
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
            var jacket = FindById(itemId);
            try
            {
                _database.Jackets.Remove(jacket);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Jacket FindById(Guid id)
        {
            try
            {
                return _database.Jackets.FirstOrDefault((System.Linq.Expressions.Expression<Func<Jacket, bool>>)(b => b.Id == id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
