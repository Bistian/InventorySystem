using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Services
{
    public class BrandService
    {
        private readonly AppDbContext _database;

        public BrandService(AppDbContext database)
        {
            this._database = database;
        }

        public Brand Add(string name, string itemType)
        {
            var result = FindByNameAndType(name, itemType);
            if (result != null) 
            {
                Console.WriteLine("Cannot add duplicated brand.");
                return null;
            }

            try
            {
                var newBrand = new Brand();
                newBrand.Id = Guid.NewGuid();
                newBrand.Name = name;
                newBrand.ItemType = itemType;
                _database.Brands.Add(newBrand);
                _database.SaveChanges();
                return newBrand;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Delete(string name, string itemType)
        {
            try
            {
                var brand = FindByNameAndType(name, itemType);
                _database.Brands.Remove(brand);
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FillComboBox(ComboBox comboBox, string itemType)
        {
            try
            {
                var brands = _database.Brands.Where(b => b.ItemType == itemType);
                if(brands.Count() == 0)
                {
                    return;
                }
                foreach(var b in brands)
                {
                    comboBox.Items.Add(b.Name);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Brand> FindAll()
        {
            try
            {
                var list = _database.Brands.ToList();
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

        public Brand FindByNameAndType(string name, string itemType)
        {
            try
            {
                return _database.Brands.FirstOrDefault(b => 
                    b.Name == name && 
                    b.ItemType == itemType
                );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
