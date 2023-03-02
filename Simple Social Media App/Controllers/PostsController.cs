using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_Social_Media_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostsController(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }


        [HttpGet("/get_all_posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            try
            {
                var result = await _postRepository.GetAll();
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

        [HttpGet("/get_post/{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            try
            {
                var result = await _postRepository.GetById(id);
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

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/update_post/{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, UpdatePostDTO updatePostDto)
        {
            try
            {
                var findPost = await _postRepository.GetById(id);

                if(findPost == null) { return NotFound("Couldn't find post"); }

                var userId = findPost.UserId;

                var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (String.IsNullOrEmpty(loginId)) { return BadRequest("You need to login"); }

                // Check that logged in user can't edit another user's post
                if (!loginId.Equals(userId.ToString())) { return BadRequest("You can only edit your own posts"); }

                var result = await _postRepository.UpdatePost(id,updatePostDto);
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/create_post")]
        public async Task<ActionResult<Post>> CreatePost(CreatePostDTO postDto)
        {
            try
            {
                var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                if(loginId == null) { return BadRequest("You need to log in again"); }

                // TODO: skift ID's ud med string, når jeg tager GUID i anvendelse
                var currentUser = await _userRepository.GetById(Guid.Parse(loginId));

                if(currentUser== null) { return NotFound("Couldn't find logged in user"); }

                var result = await _postRepository.CreatePost(postDto,currentUser);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("/delete_post/{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            try
            {
                var findPost = await _postRepository.GetById(id);

                if (findPost == null) { return NotFound("Couldn't find post"); }

                var userId = findPost.UserId;

                var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (String.IsNullOrEmpty(loginId)) { return BadRequest("You need to log in"); }

                // Check that logged in user can't delete another user's post
                if (!loginId.Equals(userId.ToString())) { return BadRequest("You can only delete your own posts"); }

                await _postRepository.DeletePost(id);
                return StatusCode(200, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}

