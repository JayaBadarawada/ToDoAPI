using System;
using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface ITasksRepository
    {
        IEnumerable<ToDo> GetToDos();
        void CreateToDo(ToDo t);
    }
}
