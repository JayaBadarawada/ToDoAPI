using System;
using System.Collections.Generic;
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
    }
}
