using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestAPI.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersRepo repo;

        public UsersController(IUsersRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("User/{id}")]
        [SwaggerResponse(200, "", typeof(User))]
        [SwaggerResponse(404, "User not found for a given Id")]
        public ActionResult<User> GetUser(int id)
        {
            var u = repo.GetUserById(id);

            if (u == null)
                return NotFound();
            
            return Ok(u);
        }

        [HttpPost("AddUser")]
        [SwaggerResponse(201)]
        public async Task<ActionResult> PostUser(User user)
        {
            repo.AddUser(user);

            var userCreated = GetUser(user.Id).Value;
            await Task.FromResult(userCreated);


            return Created(@$"\Users?id={user.Id}", userCreated);
        }

        [HttpDelete("DeleteUser")]
        public void DeleteUser(int id)
        {
            repo.RemoveUser(id);
        }
    }
}
