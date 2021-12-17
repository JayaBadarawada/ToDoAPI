using System;
using System.Collections.Generic;
using System.Linq;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class UserRepository:IUserRepository
    {
        public readonly List<User> users = new List<User>()
        {
            new User(){Id=1,Name="User1"},
             new User(){Id=2,Name="User2"},
              new User(){Id=3,Name="User3"},


        };
        public IEnumerable<User> GetUsers()
        {
            return users;
        }
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(dog => dog.Id == id);
        }
        public void AddUser(User u)
        {
            var id = users.Last().Id;
            var user = new User() { Id = (id + 1), Name = u.Name };
            users.Add(user);

        }
        public bool UpdateUser(int id, User u)
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.Name = u.Name;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddToDo(int id,ToDo t)
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if (user !=null)
            {
                user.Todos.Add(t);
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}
