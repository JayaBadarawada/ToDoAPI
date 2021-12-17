using System;
using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public class TasksRepository:ITasksRepository
    {
        public readonly List<ToDo> todos = new List<ToDo>()
        {
            new ToDo(){Id=1,Task="Buy Groceries"},
             new ToDo(){Id=2,Task="Watering plants"},
              new ToDo(){Id=3,Task="Pay Bills"},
        };
        public IEnumerable<ToDo> GetToDos()
        {
            return todos;
        }
        public void CreateToDo(ToDo t)
        {
            var task= new ToDo() { Id = t.Id, Task = t.Task };

            todos.Add(task);
        }
    }
}
