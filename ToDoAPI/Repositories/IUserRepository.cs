using System;
using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
