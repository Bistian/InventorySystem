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
    public class StudentService
    {
        private readonly AppDbContext _database;

        public StudentService(AppDbContext database)
        {
            this._database = database;
        }

        public Student Add(Guid clientId, Guid? classId = null)
        {
            var student = new Student()
            {
                IdClass = classId,
                IdClient = clientId,
            };

            try
            {
                _database.Students.Add(student);
                _database.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Update(Student student)
        {
            try
            {
                _database.Entry(student).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool Delete(Student student)
        {
            try
            {
                _database.Students.Remove(student);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Student> FindAll()
        {
            try
            {
                return _database.Students.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Student> FindByIdClass(Guid classId)
        {
            try
            {
                return _database.Students.Where(s => s.IdClass == classId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Student FindByIdClient(Guid clientId)
        {
            try
            {
                return _database.Students.FirstOrDefault(s => s.IdClient == clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
