using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class MeasurementService
    {
        private readonly AppDbContext _database;
        public MeasurementService(AppDbContext database)
        {
            this._database = database;
        }

        public Measurement Add(string chest, string gender, string height, string hips, string inseam, string sleeve, string waist, string weight)
        {
            var m = new Measurement()
            {
                Id = Guid.NewGuid(),
                Chest = chest,
                Gender = gender,
                Height = height,
                Hips = hips,
                Inseam = inseam,
                Sleeve = sleeve,
                Waist = waist,
                Weight = weight,
                CreatedAt = new DateTime(),
            };

            _database.Measurements.Add(m);
            _database.SaveChanges();
            return m;
        }

        public void Update(Measurement measurement)
        {
            try
            {
                _database.Entry(measurement).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid measurementId)
        {
            try
            {
                _database.Entry(new Measurement() { Id = measurementId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Measurement> FindAll()
        {
            try
            {
                var list = _database.Measurements.ToList();
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

        public Measurement FindById(Guid measurementId)
        {
            try
            {
                return _database.Measurements.FirstOrDefault(m => m.Id == measurementId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
