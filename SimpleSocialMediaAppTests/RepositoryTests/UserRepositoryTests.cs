using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.Controllers;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories;
using Simple_Social_Media_App.Repositories.Interfaces;
using Simple_Social_Media_App.Utils;

namespace SimpleSocialMediaAppTests.RepositoryTests
{
    public class UserRepositoryTests
    {
        private async Task<DataContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var fakeDb = new DataContext(options);
            if (await fakeDb.Users.CountAsync() == 0)
            {
                var tmpUsers = new List<User>()
                {
                    new User(){ Full_Name = "Alice", Email = "alice@mail.com", Password = "123" },
                    new User(){ Full_Name = "Bob", Email = "bob@mail.com", Password = "123" },
                    new User(){ Full_Name = "Charlie", Email = "charlie@mail.com", Password = "123" }
                };

                foreach (var i in tmpUsers)
                {
                    fakeDb.Users.Add(i);
                }

                await fakeDb.SaveChangesAsync();
            }

            return fakeDb;
        }



        //Task<List<User>?> GetAll();
        [Fact]
        public async Task GetAllTestAsync()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var fakeMapper = A.Fake<IMapper>();
            var userRepository = new UserRepository(fakeDb, fakeMapper);

            // Act
            var result = await userRepository.GetAll();

            // Assert
            result.Should().BeEquivalentTo(fakeDb.Users.ToList());
        }

        //Task<User?> GetById(int id);
        [Fact]
        public async void GetByIdTest()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var fakeMapper = A.Fake<IMapper>();
            var userRepository = new UserRepository(fakeDb, fakeMapper);
            var none_id = fakeDb.Users.Count() + 1;
            var exist_id = fakeDb.Users.ToList().First().Id;

            // Act
            var result1 = await userRepository.GetById(none_id);
            var result2 = await userRepository.GetById(exist_id);

            // Assert
            result1.Should().BeNull();
            result2.Should().NotBeNull();

        }

        //Task<User> PostUser(UserDTO user);
        [Fact]
        public async void PostUserTest()
        {
            // Arrange
            var userDto = new UserDTO
            {
                Full_Name = "New DTO",
                Email = "dto@mail.com",
                Password = "123"
            };

            var fakeDb = await GetDbContext();
            var fakeMapper = A.Fake<IMapper>();
            var userRepository = new UserRepository(fakeDb, fakeMapper);

            // Act 
            var result = await userRepository.PostUser(userDto);

            // Assert
            result.Should().NotBeNull();
//            result.Should().NotBeOfType(typeof(Task<User>));
        }

        //Task<User?> UpdateUser(int id, UserDTO userDTO);
        [Fact]
        public async Task UpdateUserTestAsync()
        {
            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperService());
            });
            var mapper = config.CreateMapper();
            var fakeDb = await GetDbContext();
            var userRepository = new UserRepository(fakeDb, mapper);

            var old_user_tmp = fakeDb.Users.ToList().First();
            var old_user = new User()
            {
                Id = old_user_tmp.Id,
                Full_Name = old_user_tmp.Full_Name,
                Email = old_user_tmp.Email,
                Password = old_user_tmp.Password
            };
            var userDto = new UserDTO() { Full_Name = "old_user_name_edit", Email = "old_user@mail.com", Password = "123" };

            // Act
            var result = await userRepository.UpdateUser(old_user.Id, userDto);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(old_user.Id);     // Ensure the same object has been updated
            result.Full_Name.Should().NotBe(old_user.Full_Name);
        }

        //Task DeleteUser(int id);
        [Fact]
        public async Task DeleteUserTestAsync()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var fakeMapper = A.Fake<IMapper>();
            var userRepository = new UserRepository(fakeDb, fakeMapper);

            var beforeUserTmp = fakeDb.Users.First();
            var firstIdBeforeRemove = beforeUserTmp.Id;

            // Act
            await userRepository.DeleteUser(firstIdBeforeRemove);
            var firstIdAfterRemove = fakeDb.Users.First().Id;

            // Assert
            firstIdBeforeRemove.Should().NotBe(firstIdAfterRemove);

        }
    }
}
