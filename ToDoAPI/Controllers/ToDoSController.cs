using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public ActionResult CreateToDo(ToDo t)
        {
            _taskRepository.CreateToDo(t);
            return Ok();
        }
    }
   
}
