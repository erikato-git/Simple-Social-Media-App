using AutoMapper;
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

        public Task<Comment> CreateComment(CreateCommentDTO commentDto, User user, Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllCommentsByPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllCommentsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> UpdateComment(Guid id, User user, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
