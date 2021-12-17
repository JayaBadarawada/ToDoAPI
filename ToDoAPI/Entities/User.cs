using System;
using System.Collections.Generic;

namespace ToDoAPI.Entities
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
       
        public List<ToDo> Todos { get; set; } = new List<ToDo>();


    }
}
