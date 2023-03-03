using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;
using System.ComponentModel;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Simple_Social_Media_App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Queries

        public async Task<List<User>?> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id null");
            }

            var user = await _context.Users.FindAsync(id);
            return user;
        }

        // Commands

        public async Task<User> PostUser(UserDTO userDto)
        {
            if(userDto == null)
            {
                throw new ArgumentNullException("userDto is null");
            }

            Random rnd = new();
            int salt = rnd.Next();
            
            userDto.Password = HashPassword(userDto.Password,salt.ToString());
            var user = _mapper.Map<User>(userDto);

            user.Salt = salt;

            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return user;
        }

        private string HashPassword(string password, string salt)
        {
            var passwordWithSalt = password + salt;

            using var sha = SHA512.Create();
            
            var bytes = Encoding.Default.GetBytes(passwordWithSalt);

            var hashed = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hashed);
        }

        public async Task<User?> UpdateUser(Guid id, UserDTO userDto)
        {
            if (String.IsNullOrEmpty(id.ToString()) || userDto == null)
            {
                throw new ArgumentNullException("id or userDto is null");
            }

            var found = await _context.Users.FindAsync(id);

            if(found == null)
            {
                return null;
            }

            userDto.Password = HashPassword(userDto.Password, found.Salt.ToString());

            _mapper.Map(userDto, found);
            _context.SaveChanges();

            return found;
        }

        public async Task DeleteUser(Guid id)
        {
            if(String.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentNullException("id is null");
            }

            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            // Remove objects attached to the user

            _context.Users.Remove(user);
            _context.SaveChanges();

            return;
        }

        public async Task<User?> FindUserForLogin(LoginDTO loginDto)
        {
            if(loginDto == null)
            {
                throw new ArgumentNullException("loginDto is null");
            }

            var emailFound = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(loginDto.Email));

            if(emailFound == null)
            {
                return null;
            }

            var hashedPassword = HashPassword(loginDto.Password, emailFound.Salt.ToString());
            
            var found = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(loginDto.Email) && x.Password.Equals(hashedPassword));;

            return found;
        }


    }
}
