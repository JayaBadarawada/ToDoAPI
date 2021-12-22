using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DataAccess;
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
            var users = _userRepository.GetUsers();
            return Ok(users);
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

        [HttpGet("{userId}/todos")]
        public ActionResult<User> GetUserTodos(int userId)
        {
            var todos = _userRepository.GetUserTodos(userId);
            if (todos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todos);
            }
        }

        [HttpGet("{userId}/todos/{id}")]
        public IActionResult GetUserTodoDetails(int userId, int id)
        {
            var todo = _userRepository.GetUserTodoDetails(userId, id);
            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todo);
            }
        }

        [HttpPost]
        public IActionResult AddUser(User u)
        {
            var resp = _userRepository.AddUser(u);
            if (!resp)
            {
                return BadRequest();
            }
            else
            {
                return Ok("User Successfully Created!");
            }

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
    }
}
