using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Repositories.EF
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _db;

        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Client> GetAll()
        {
            try
            {
                return _db.Clients.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Client FindByDriverLicense(string driverLicense, string name)
        {
            return _db.Clients.FirstOrDefault(c => 
                c.DriverLicense == driverLicense && 
                c.Name == name
            );
        }

        public Client FindById(Guid id)
        {
            return _db.Clients.Find(id);
        }

        public Client FindByName(string name)
        {
            return _db.Clients.FirstOrDefault(c => c.Name == name);
        }

        public List<Guid> FindRented(string clientId)
        {
            // _database.Items.FirstOrDefault(i => i.Location == clientId)
            return null;
        }

        public List<Client> FindBySearchBar(string searchTerm, bool isActive, bool isInactive)
        {
            // Start from the full DbSet
            IQueryable<Client> query = _db.Clients;

            // 1) Filter on IsActive/IsInactive
            if (isActive && !isInactive)
            {
                query = query.Where(c => c.IsActive);
            }
            else if (!isActive && isInactive)
            {
                query = query.Where(c => !c.IsActive);
            }

            // 2) Filter on the searchTerm (LIKE %searchTerm%)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => c.Name.Contains(searchTerm));
            }

            // 3) Materialize
            var results = query.ToList();

            if(results.Count > 0)
            {
                return results;
            }
            return null;
        }

        public void Add(Client client)
        {
            //if (client.Id == Guid.Empty)
            //{
            //    client.Id = Guid.NewGuid();
            //}

            if (client.Id == Guid.Empty)
            {
                client.Id = Guid.NewGuid();
            }
            _db.Clients.Add(client);
            _db.SaveChanges();
        }

        public void Update(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
