using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Services
{
    public class RentalService
    {
        private readonly AppDbContext _database;
        public RentalService(AppDbContext database)
        {
            this._database = database;
        }

        public Rental Add(Guid clientId, Guid itemId, string notes, DateTime rentedAt, DateTime dueDate)
        {
            var rental = FindActiveByIdItem(itemId);
            if(rental != null)
            {
                MessageBox.Show("Item cannot be rented, it has not been returned yet.", "Error", MessageBoxButtons.OK);
                return null;
            }
            var r = new Rental()
            {
                Id = Guid.NewGuid(),
                IdClient = clientId,
                IdItem = itemId,
                IdRepresentative = null, // TODO: Need to fix this later
                Notes = notes,
                RentedAt = rentedAt,
                DueDate = dueDate,
                ReturnedAt = null,
                CreatedAt = new DateTime(),
            };

            _database.Rentals.Add(r);
            _database.SaveChanges();
            return r;
        }

        public void Update(Rental rental)
        {
            try
            {
                _database.Entry(rental).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid rentalId)
        {
            try
            {
                _database.Entry(new Rental() { Id = rentalId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Rental> FindAll()
        {
            try
            {
                var list = _database.Rentals.ToList();
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

        public List<Rental> FindByIdItem(Guid itemId)
        {
            try
            {
                return _database.Rentals.Where(r => r.IdItem == itemId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Rental FindActiveByIdItem(Guid itemId)
        {
            try
            {
                return _database.Rentals.FirstOrDefault(r => r.IdItem == itemId && r.ReturnedAt == null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void Return(Rental rental)
        {
            rental.UpdatedAt = DateTime.Now;
            rental.ReturnedAt = DateTime.Now;
            Update(rental);
        }
    }
}
