using Microsoft.AspNetCore.Mvc;
using ECommerceApplication.Models;
using ECommerceApplication.Repository;
using Microsoft.AspNetCore.Identity.Data;

namespace ECommerceApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] User loginRequest)
        {
            var token = userRepository.Login(loginRequest.UserName, loginRequest.Password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(token);
        }

        [HttpPost("logout")]
        public ActionResult Logout([FromHeader(Name = "Authorization")] string token)
        {
            if (!userRepository.IsAuthenticated(token))
            {
                return Unauthorized("Invalid or expired session.");
            }

            userRepository.Logout(token);
            return Ok("Successfully logged out.");
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = userRepository.GetUsers();
            return users;
        }


        [HttpPost(Name = "CreateUser")]
        public ActionResult<User> CreateUser(User newUser)
        {
            bool isUserAdded = userRepository.AddUser(newUser);
            if (!isUserAdded)
            {
                return BadRequest();
            }
            return newUser;
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            bool isUserUpdated = userRepository.UpdateUser(updatedUser);
            if(!isUserUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            bool isUserDeleted = userRepository.DeleteUser(id);
            if(!isUserDeleted)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
