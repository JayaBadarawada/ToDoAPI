using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DataAccess;
using ToDoAPI.Entities;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoSController : ControllerBase
    {
        public readonly ITasksRepository _taskRepository;
        public ToDoSController(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetToDoS()
        {
            return Ok(_taskRepository.GetToDos());
        }

        [HttpGet("{id}")]
        public IActionResult GetTodosById(int id)
        {
            var todo = _taskRepository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost("{userId}")]
        public ActionResult CreateToDo(ToDo t, int userId)
        {
            _taskRepository.CreateToDo(t , userId);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteToDo(int id)
        {
           var todo = _taskRepository.DeleteToDo(id);
            if (!todo)
            {
                return NotFound();
            }
            else
            {
                return Ok("Todo Successfully Deleted!");
            }
        }
    }
   
}
