using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;

namespace Simple_Social_Media_App.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PostRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        // Queries

        public async Task<List<Post>?> GetAll()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetById(Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id is empty");
            }

            var post = await _dataContext.Posts.FindAsync(id);

            return post;
        }

        // Commands

        public async Task<Post?> UpdatePost(Guid id, UpdatePostDTO updatePostDto)
        {
            if (String.IsNullOrEmpty(id.ToString()) || updatePostDto == null)
            {
                throw new ArgumentNullException("id is empty or updatePostDto is null");
            }

            var found = await _dataContext.Posts.FindAsync(id);

            if(found == null)
            {
                return null;
            }

            _mapper.Map(updatePostDto, found);
            _dataContext.SaveChanges();

            return found;
        }

        public async Task<Post> CreatePost(CreatePostDTO postDto, User user)
        {
            if(postDto == null || user == null)
            {
                throw new ArgumentNullException("post or user is null");
            }

            var post = _mapper.Map<Post>(postDto);
            post.UserId = user.UserId;
            post.User = user;

            await _dataContext.Posts.AddAsync(post);
            _dataContext.SaveChanges();

            return post;

        }

        public async Task DeletePost(Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id is empty");
            }

            var post = await _dataContext.Posts.FindAsync(id);

            if (post == null)
            {
                throw new Exception("User not found");
            }

            _dataContext.Posts.Remove(post);
            _dataContext.SaveChanges();

            return;
        }

    }
}
