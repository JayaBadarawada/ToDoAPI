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


        public readonly IUserRepository _userRepository;
        public ToDoSController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetToDoS()
        {

            return Ok(_userRepository.GetToDos());
        }

        [HttpPost("{id}")]
        public ActionResult CreateToDo(ToDo t, int id)
        {
            _userRepository.CreateToDo(t , id);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteToDo(ToDo t, int id)
        {
           var todo = _userRepository.DeleteToDo(t, id);
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
