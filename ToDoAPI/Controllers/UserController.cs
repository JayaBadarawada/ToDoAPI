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
        public readonly DataContext _context;

        public UserController(IUserRepository userRepository, DataContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {

            return Ok(_context.Users.ToList());
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





    }

}
