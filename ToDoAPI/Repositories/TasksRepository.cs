using System.Collections.Generic;
using System.Linq;
using ToDoAPI.DataAccess;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class TasksRepository:ITasksRepository
    {

        private readonly DataContext _context;
        public TasksRepository(DataContext context) { _context = context; }

      

        public IEnumerable<ToDo> GetToDos()
        {
            return _context.Tasks.ToList();
        }
        public ToDo CreateToDo(ToDo t)
        {
            var task = new ToDo() { Id = t.Id, Task = t.Task };

            _context.Tasks.Add(task);
            _context.SaveChangesAsync();

            return task;
        }
    }
}
