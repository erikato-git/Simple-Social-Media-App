using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;

namespace Simple_Social_Media_App.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CommentRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public async Task<List<Comment>?> GetAll()
        {
            return await _dataContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id is empty");
            }

            var comment = await _dataContext.Comments.FindAsync(id);

            if(comment == null)
            {
                return null;
            }

            return comment;
        }

        public async Task<List<Comment>> GetAllCommentsByPost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post is null");
            }

            var commentsByPost = await _dataContext.Comments.Where(x => x.PostId == post.PostId).ToListAsync();
            
            return commentsByPost;
        }

        public async Task<List<Comment>> GetAllCommentsByUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("post is null");
            }

            var commentsByUser = await _dataContext.Comments.Where(x => x.UserId == user.UserId).ToListAsync();

            return commentsByUser;
        }


        public async Task<Comment> CreateComment(CreateCommentDTO commentDto, User user)
        {
            if ( commentDto == null || user == null )
            {
                throw new ArgumentNullException("comment, user or post is null");
            }

            var comment = _mapper.Map<Comment>(commentDto);
            comment.UserId = user.UserId;
            comment.User = user;
            comment.PostId = commentDto.PostId;

            var post = await _dataContext.Posts.FindAsync(commentDto.PostId);
            comment.Post = post;

            await _dataContext.Comments.AddAsync(comment);
            _dataContext.SaveChanges();

            return comment;
        }

        public async Task DeleteComment(Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id is empty");
            }

            var comment = await _dataContext.Comments.FindAsync(id);

            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            _dataContext.Comments.Remove(comment);
            _dataContext.SaveChanges();

            return;
        }


        public async Task<Comment?> UpdateComment(Guid id, UpdateCommentDTO commentDto)
        {
            if(String.IsNullOrEmpty(id.ToString()) || commentDto == null)
            {
                throw new ArgumentNullException("id or post is null");
            }

            var found = await _dataContext.Comments.FindAsync(id);

            if(found == null)
            {
                return null;
            }

            _mapper.Map(commentDto, found);
            _dataContext.SaveChanges();

            return found;

        }
    }
}
