using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        
    }
    
}
