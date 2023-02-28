using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;

namespace Simple_Social_Media_App.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> PostUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUser(int id, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
