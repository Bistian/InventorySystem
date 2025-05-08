using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagmentSystem.Services
{
    public class AcademyService
    {
        private readonly AppDbContext _database;
        public AcademyService(AppDbContext database)
        {
            this._database = database;
        }

        public Academy Add(Guid addressId, string name)
        {
            var a = new Academy()
            {
                Id = Guid.NewGuid(),
                IdAddress = addressId,
                Name = name,
                CreatedAt = new DateTime(),
            };

            _database.Academies.Add(a);
            _database.SaveChanges();
            return a;
        }

        public void Update(Academy academy)
        {
            try
            {
                _database.Entry(academy).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid academyId)
        {
            try
            {
                _database.Entry(new Academy() { Id = academyId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Academy> FindAll()
        {
            try
            {
                var list = _database.Academies.ToList();
                if (list.Count > 0)
                {
                    return list;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<AcademyFull> FindAllFull()
        {
            try
            {
                var rows = (
                    from ac in _database.Academies

                        // join the Address table on ac.IdAddress == addr.Id
                    join addr0 in _database.Addresses
                        on ac.IdAddress equals addr0.Id
                    // since it’s one-to-one and required, we don’t need DefaultIfEmpty()

                    // join the Contact table on ac.IdContact == c.Id
                    join c0 in _database.Contacts
                        on ac.IdContact equals c0.Id

                    // project directly into AcademyFull
                    select new AcademyFull
                    {
                        Id = ac.Id,
                        AcademyName = ac.Name,

                        IdAddress = ac.IdAddress,
                        Street = addr0.Street,
                        Number = addr0.Number,
                        City = addr0.City,
                        State = addr0.State,
                        Zip = addr0.Zip,

                        IdContact = ac.IdContact,
                        ContactName = c0.Name,
                        ContactEmail = c0.Email,
                        ContactPhone = c0.PhoneNumber
                    }
                ).ToList();
                if (rows.Count > 0)
                {
                    return rows;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Academy FindById(Guid academyId)
        {
            try
            {
                return _database.Academies.FirstOrDefault(a => a.Id == academyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
