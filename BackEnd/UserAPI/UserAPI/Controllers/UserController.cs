using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersBL<UsersModel> _users;

        public UserController(IUsersBL<UsersModel> userModel)
        {
            this._users = userModel;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersModel>> Get()
        {
            return await _users.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(UsersModel cliente)
        {
            string message = await _users.Insert(cliente);
            return new JsonResult(message);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(UsersModel cliente)
        {
            string message = await _users.Update(cliente);            
            return new JsonResult(message); 
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            string message = await _users.Delete(id);
            return new JsonResult(message);
        }
    }
}
