using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>?> GetAll();
        Task<Comment?> GetById(Guid id);
        Task<Comment> CreateComment(CreateCommentDTO commentDto, User user, Post post);
        Task<Comment?> UpdateComment(Guid id, User user, Post post);
        Task DeleteComment(Guid id);
        Task<List<Comment>> GetAllCommentsByPost(Post post);
        Task<List<Comment>> GetAllCommentsByUser(User user);

    }
}
