using System.Threading.Tasks;
using DatinApp.Api.Data;
using DatinApp.Api.Dtos;
using DatinApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatinApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exist");
            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };
            
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}