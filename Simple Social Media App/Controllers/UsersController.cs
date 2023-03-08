﻿using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;
using System.Linq;
using System.Security.Claims;

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
        [HttpGet("/get_all_users")]

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
        [HttpGet("/get_user/{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
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
        [HttpPut("/update_user/{id}")]
//        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutUser(Guid id, UserDTO userDTO)
        {
            try
            {
                var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (String.IsNullOrEmpty(loginId))
                {
                    return BadRequest("You need to log in again");
                }

                // Check that logged in user doesn't edit another user
                if(!loginId.Equals(id.ToString()))
                {
                    return BadRequest("Wrong user");
                }

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
        [HttpPost("/create_user")]
        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("User-information don't full-fill the requirements");
                }

                var result = await _userRepository.PostUser(userDto);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("/delete_user/{id}")]
//        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if(String.IsNullOrEmpty(loginId)) { return BadRequest("You need to log in again"); };

                // Check that logged in user doesn't delete another user
                if (!loginId.Equals(id.ToString()))
                {
                    return BadRequest("Wrong user");
                }


                await _userRepository.DeleteUser(id);

                await HttpContext.SignOutAsync();
                return StatusCode(200, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(LoginDTO loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Redirect("/login");
                }
                var found = await _userRepository.FindUserForLogin(loginDto);

                if (found == null)
                {
                    return NotFound();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, found.Full_Name),
                    new Claim(ClaimTypes.NameIdentifier, found.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "User")
                };

                var ci = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var cp = new ClaimsPrincipal(ci);

                var properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(cp, properties);


                return Ok("Log in!");
                //return LocalRedirect("/api/Posts/Home");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/logout")]
        public async Task<ActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync();

                return Ok("Log out!");
                //return LocalRedirect("/api/Users/login");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/findUserByEmail/{email}")]
        public async Task<ActionResult> FindUserByEmail(string email)
        {
            try
            {
                var result = await _userRepository.FindUserByEmail(email);
                if (result == null)
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

    }
}
