using Microsoft.AspNetCore.Mvc;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>?> GetAll();
        Task<User?> GetById(Guid id);
        Task<User> PostUser(UserDTO user);
        Task<User?> UpdateUser(Guid id, UserDTO userDTO);
        Task DeleteUser(Guid id);
        Task<User?> FindUserForLogin(LoginDTO loginDto);
        Task<User> FindUserByEmail(string email);
    }
}
