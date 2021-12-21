using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.DataAccess;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;
        public UserRepository(DataContext context) { _context = context; }



        public IEnumerable<User> GetUsers() => _context.Users.ToList();


        public User GetUserById(int id) {

            var user = _context.Users
                           .Where(u => u.Id == id)
                           .Include(u => u.Todos)
                           .FirstOrDefault();
            return user;

        }  
        

        public User AddUser(User u)
        {
            User user = new() { Id = u.Id, Name = u.Name };
            _context.Users.Add(user);
            _context.SaveChangesAsync();
            return user;
        }

        public bool UpdateUser(int id, User u)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.Name = u.Name;
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddToDo(int id, ToDo t)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.Todos.Add(t);
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
