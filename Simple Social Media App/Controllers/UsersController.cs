using Microsoft.AspNetCore.Mvc;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;

namespace Simple_Social_Media_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var result = await _userRepository.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _userRepository.GetById(id);
                if(result == null)
                {
                    return NotFound();
                }
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            try
            {
                var result = await _userRepository.UpdateUser(id, userDTO);
                if(result == null )
                {
                    return NotFound("User not found");
                }
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            try
            {
                var result = await _userRepository.PostUser(userDto);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
                return StatusCode(200, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
