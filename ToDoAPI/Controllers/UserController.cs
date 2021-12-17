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
    public class UserController : ControllerBase

    {

        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
       public IActionResult GetUsers()
        {
           
            return Ok(_userRepository.GetUsers());
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public ActionResult AddUser(User u)
        {
            _userRepository.AddUser(u);
            return Ok("User Successfully Created!");

        }
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User u)
        {
            var resp = _userRepository.UpdateUser(id, u);
            if (!resp)
            {
                return NotFound();
            }
            else
            {
                return Ok("User Successfully Updated!");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var item = _userRepository.DeleteUser(id);
            if (!item)
            {
                return NotFound();
            }
            else
            {
                return Ok("User Successfully Deleted!");
            }
        }

        [HttpPut]
        [Route("ToDo/{id}")]
        public ActionResult AddTask(int id,ToDo toDo)
        {
            var res = _userRepository.AddToDo(id,toDo);
            if (res == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }




    }

}
