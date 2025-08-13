using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;

namespace InventoryManagmentSystem.Repositories.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client FindByDriverLicense(string driverLicense, string name);
        Client FindById(Guid id);
        Client FindByName(string name);
        List<Client> FindBySearchBar(string searchTerm, bool isActive, bool isInactive);
        void Add(Client client);
        void Update(Client client);
    }
}
