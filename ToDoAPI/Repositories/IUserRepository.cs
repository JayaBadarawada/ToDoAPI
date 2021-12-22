using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        List<ToDo> GetUserTodos(int userId);
        ToDo GetUserTodoDetails(int userId, int id);
        bool AddUser(User u);
        bool UpdateUser(int id, User u);
        bool DeleteUser(int id);
        // bool AddToDo(int id, ToDo t);
        IEnumerable<ToDo> GetToDos();
        ToDo CreateToDo(ToDo t, int id);
        bool DeleteToDo(ToDo t, int id);

    }
}
