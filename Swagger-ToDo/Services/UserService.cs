using System.Collections.Generic;
using System.Linq;
using Swagger_ToDo.Context;
using Swagger_ToDo.Interfaces;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoContext _context;
        
        public UserService(ToDoContext context)
        {
            _context = context;
        }
        
        public void Add(UserModel model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var model = new UserModel { Id = id };
            
            _context.Users.Attach(model);
            _context.Users.Remove(model);

            _context.SaveChanges();
        }

        public void Update(UserModel model)
        {
            _context.Users.Update(model);
            _context.Entry(model).Property(n => n.Id).IsModified = false;
            _context.SaveChanges();
        }

        public void RemoveAll(int userId)
        {
            _context.Users.RemoveRange(_context.Users.Where(u => u.Id == userId));
            _context.SaveChanges();
        }

        public UserModel Get(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users;
        }
    }
}