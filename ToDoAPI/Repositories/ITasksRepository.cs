using System;
using System.Collections.Generic;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface ITasksRepository
    {
        IEnumerable<ToDo> GetToDos();
        ToDo CreateToDo(ToDo t, int id);
        bool DeleteToDo(int id);

    }
}
