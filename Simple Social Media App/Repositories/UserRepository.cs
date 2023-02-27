using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories.Interfaces;
using System.ComponentModel;
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

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return null;
            }

            return user;
        }

        // Commands

        public async Task<User> PostUser(UserDTO userDto)
        {
            Random rnd = new();
            int salt = rnd.Next();
            
            userDto.Password = HashPassword(userDto.Password + salt);
            var user = _mapper.Map<User>(userDto);

            user.Salt = salt;

            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return user;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA512.Create();
            
            var bytes = Encoding.Default.GetBytes(password);

            var hashed = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hashed);
        }

        public async Task<User?> UpdateUser(int id, UserDTO userDto)
        {
            var found = await _context.Users.FindAsync(id);
            if(found == null)
            {
                return null;
            }

            _mapper.Map(userDto, found);
            _context.SaveChanges();

            return found;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return;
        }
    }
}
