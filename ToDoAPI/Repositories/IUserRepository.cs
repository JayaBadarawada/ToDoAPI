using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User AddUser(User u);
        bool UpdateUser(int id, User u);
        bool DeleteUser(int id);
        

        // Tasks
        IEnumerable<ToDo> GetToDos();
        ToDo CreateToDo(ToDo t, int id);
        bool DeleteToDo(ToDo t, int id);

    }
}
