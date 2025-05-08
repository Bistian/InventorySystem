using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class PantsService
    {
        private readonly AppDbContext _database;

        public PantsService(AppDbContext database)
        {
            this._database = database;
        }

        public Pants Add(Guid itemId, string size)
        {
            var pants = new Pants();
            pants.Id = itemId;
            pants.Size = size;
            _database.Pants.Add(pants);
            _database.SaveChanges();
            return pants;
        }

        public void Update(Pants pants)
        {
            try
            {
                _database.Entry(pants).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Pants pants)
        {
            try
            {
                _database.Pants.Remove(pants);
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
            var pants = FindById(itemId);
            try
            {
                _database.Pants.Remove(pants);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Pants FindById(Guid id)
        {
            try
            {
                return _database.Pants.FirstOrDefault((System.Linq.Expressions.Expression<Func<Pants, bool>>)(b => b.Id == id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
