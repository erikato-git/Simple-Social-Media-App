using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>?> GetAll();
        Task<Post?> GetById(Guid id);
        Task<Post> CreatePost(CreatePostDTO postDto, User user);
        Task<Post?> UpdatePost(Guid id, UpdatePostDTO postDto);
        Task DeletePost(Guid id);

    }
}
