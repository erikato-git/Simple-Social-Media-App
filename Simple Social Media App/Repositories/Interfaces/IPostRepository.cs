using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<User>?> GetAll();
        Task<User?> GetById(int id);
        Task<User> PostUser(UserDTO user);
        Task<User?> UpdateUser(int id, UserDTO userDTO);
        Task DeleteUser(int id);

    }
}
