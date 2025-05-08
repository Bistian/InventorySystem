using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.Services
{
    public class ClassService
    {
        private readonly AppDbContext _database;
        public ClassService(AppDbContext database)
        {
            this._database = database;
        }

        public Class Add(Guid academyId, string name, DateTime startAt, DateTime endAt)
        {
            var c = new Class()
            {
                Id = Guid.NewGuid(),
                IdAcademy = academyId,
                Name = name,
                EndAt = endAt,
                StartAt = startAt,
                CreatedAt = new DateTime(),
            };

            _database.Classes.Add(c);
            _database.SaveChanges();
            return c;
        }

        public void Update(Class classEntity)
        {
            try
            {
                _database.Entry(classEntity).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Guid classId)
        {
            try
            {
                _database.Entry(new Class() { Id = classId }).State = EntityState.Deleted;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Class> FindAll()
        {
            try
            {
                var list = _database.Classes.ToList();
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

        public Class FindById(Guid? classId)
        {
            if(classId == null)
            {
                return null;
            }

            try
            {
                return _database.Classes.FirstOrDefault(c => c.Id == classId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<Class> FindByIdAcademy(Guid academyId)
        {
            try
            {
                return _database.Classes.Where(c => c.IdAcademy == academyId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
