using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoAPI.DataAccess;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private readonly DataContext _context;
        public TasksRepository(DataContext context) { _context = context; }

        public IEnumerable<ToDo> GetToDos() => _context.Tasks.ToList();
        public ToDo GetTodoById(int id) 
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public ToDo CreateToDo(ToDo t, int userId)
        {
            User user = _context.Users.Where(u => u.Id == userId).Include(u => u.Todos).FirstOrDefault();
            ToDo task = new() { Id = t.Id, Task = t.Task };

            user.Todos.Add(task);
            _context.SaveChangesAsync();

            return task;
        }


        public bool DeleteToDo(int id)
        {
            ToDo todo = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _context.Tasks.Remove(todo);
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
