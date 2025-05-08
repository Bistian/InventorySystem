using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class MaskService
    {
        private readonly AppDbContext _database;

        public MaskService(AppDbContext database)
        {
            this._database = database;
        }

        public Mask Add(Guid itemId, string size)
        {
            var mask = new Mask();
            mask.Id = itemId;
            mask.Size = size;
            _database.Masks.Add(mask);
            _database.SaveChanges();
            return mask;
        }

        public void Update(Mask mask)
        {
            try
            {
                _database.Entry(mask).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Mask mask)
        {
            try
            {
                _database.Masks.Remove(mask);
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
            var masks = FindById(itemId);
            try
            {
                _database.Masks.Remove(masks);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Mask FindById(Guid id)
        {
            try
            {
                return _database.Masks.FirstOrDefault((System.Linq.Expressions.Expression<Func<Mask, bool>>)(b => b.Id == id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
