using InventoryManagmentSystem.Database.Entities;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using InventoryManagmentSystem.Database;
using System.Linq;
using System.Data.Entity;

namespace InventoryManagmentSystem.Services
{
    public class ClientService
    {
        private readonly AppDbContext _database;

        public ClientService(AppDbContext database)
        {
            this._database = database;
        }

        public Client Add(Guid addressId, Guid fireDepartmentId, Guid measurementId, string driverLicense, string email, string name, string phoneNumber, Guid? classId = null )
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                IdAddress = addressId,
                IdFireDepartment = fireDepartmentId,
                IdMeasurement = measurementId,
                DriverLicense = driverLicense,
                Email = email,
                IsActive = false,
                Name = name,
                PhoneNumber = phoneNumber,
                CreatedAt = DateTime.Now,
            };

            try
            {
                if (client.Id == Guid.Empty)
                {
                    client.Id = Guid.NewGuid();
                }
                _database.Clients.Add(client);
                _database.SaveChanges();
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Update(Client client)
        {
            try
            {
                _database.Entry(client).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Client client)
        {
            try
            {
                _database.Clients.Remove(client);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public void Activity(Guid clientId, bool isActive)
        {
            var c = FindById(clientId);
            if(c == null) { return; }

            c.IsActive = isActive;
            Update(c);
        }
        
        public List<Client> FindAll()
        {
            try
            {
                return _database.Clients.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Client FindByDriverLicense(string driverLicense, string name)
        {
            try
            {
                return _database.Clients.FirstOrDefault(c =>
                    c.DriverLicense == driverLicense &&
                    c.Name == name
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Client FindById(Guid clientId)
        {
            try
            {
                return _database.Clients.FirstOrDefault(c => c.Id == clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Client FindByName(string name)
        {
            try
            {
                return _database.Clients.FirstOrDefault(c => c.Name == name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Client> FindBySearchBar(string searchTerm, bool isActive, bool isInactive)
        {
            // Start from the full DbSet
            IQueryable<Client> query = _database.Clients;

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
            try
            {
                var results = query.ToList();

                if (results.Count > 0)
                {
                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }

        public void LoadToDataGrid(DataGridView grid)
        {
            var clients = FindAll();
            if(clients == null)
            {
                return;
            }

            int index = 0;
            clients.ForEach(c =>
            {
                grid.Rows.Add(
                    ++index,
                    c.Id,
                    c.Name,
                    c.PhoneNumber,
                    c.Email,
                    "Academy ID",
                    c.DriverLicense
                );
            });
        }

    }
}
