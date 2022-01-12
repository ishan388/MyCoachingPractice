using BusinessLayer.UserOps;
using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoachingPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IBLUsers bLUsers;

        public UsersController(IBLUsers _iBLUsers)
        {
            this.bLUsers = _iBLUsers;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bLUsers.Get().ConfigureAwait(false));
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            return Ok(await bLUsers.Get(userId).ConfigureAwait(false));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsersVM user)
        {
            return Ok(await bLUsers.Post(user).ConfigureAwait(false));
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsersVM user)
        {
            return Ok(await bLUsers.Put(user).ConfigureAwait(false));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            return Ok(await bLUsers.Delete(userId).ConfigureAwait(false));
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] UsersVM user)
        {
            return Ok(await bLUsers.Login(user).ConfigureAwait(false));
        }

        // Get api/<UsersController>
        [HttpGet("{email}")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            return Ok(await bLUsers.ForgetPassword(email).ConfigureAwait(false));
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword(int userId, string newPassword)
        {
            return Ok(await bLUsers.ResetPassword(userId, newPassword).ConfigureAwait(false));
        }
    }
}