using FakeItEasy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.Controllers;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.Repositories;
using Simple_Social_Media_App.Repositories.Interfaces;
using Simple_Social_Media_App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialMediaAppTests.ControllerTests
{
    public class UsersControllerTests
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

        public async Task<UsersController> createUsersControllerMoqAsync()
        {
            var fakeDb = await GetDbContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperService());
            });
            var mapper = config.CreateMapper();
            var userRepository = new UserRepository(fakeDb, mapper);
            var controller = new UsersController(userRepository);
            return controller;
        }



        //Task<ActionResult<IEnumerable<User>>> GetUsers()
        [Fact]
        public async void GetUsers_ReturnOK()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var controller = await createUsersControllerMoqAsync();

            // Act
            var result = await controller.GetUsers();

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result.Result);
            var actual = Assert.IsAssignableFrom<List<User>>(response.Value);    // casting result to ObjectResult

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(fakeDb.Users.ToList().Count, actual.Count);
        }

        //Task<ActionResult<User>> GetUser(int id)
        [Fact]
        public async void GetUser_ReturnOk()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var firtInDb = fakeDb.Users.First();
            var controller = await createUsersControllerMoqAsync();

            // Act
            var result = await controller.GetUser(firtInDb.Id);

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result.Result);
            var actual = Assert.IsAssignableFrom<User>(response.Value);    // casting result to ObjectResult

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(firtInDb.Full_Name, actual.Full_Name);

        }

        // TODO: HttpContext is null. Wait to fix the test-method 
        //Task<IActionResult> PutUser(int id, UserDTO userDTO)
        //[Fact]
        public async void PutUser_ReturnOk()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var firtInDb = fakeDb.Users.First();
            var controller = await createUsersControllerMoqAsync();

            UserDTO dto = new UserDTO { Full_Name = "New User Name", Email = firtInDb.Email, Password = firtInDb.Password };

            // Act
            var result = await controller.PutUser(firtInDb.Id, dto);

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result);
            var actual = Assert.IsAssignableFrom<User>(response.Value);    // casting result to ObjectResult

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(firtInDb.Id, actual.Id);
            Assert.NotEqual(firtInDb.Full_Name, actual.Full_Name);
            Assert.Equal(firtInDb.Email, actual.Email);

        }


        //Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        [Fact]
        public async void PostUser_ReturnOk()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var oldfakeDbLength = fakeDb.Users.Count();
            var controller = await createUsersControllerMoqAsync();

            UserDTO dto = new UserDTO { Full_Name = "New User", Email = "newuser@mail.com", Password = "123" };

            // Act
            var result = await controller.PostUser(dto);

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result.Result);
            var actual = Assert.IsAssignableFrom<User>(response.Value);     // casting result to ObjectResult

            var getUsersUpdated = await controller.GetUsers();
            var checkResponse = Assert.IsType<ObjectResult>(getUsersUpdated.Result);
            var castedCheckResponse = Assert.IsAssignableFrom<List<User>>(checkResponse.Value);
                        
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(castedCheckResponse.Count(), oldfakeDbLength + 1);
            Assert.Contains<User>(actual, castedCheckResponse);
        }


        // TODO: HttpContext is null. Wait to fix the test-method 
        //Task<IActionResult> DeleteUser(int id)
        //[Fact]
        public async void DeleteUser_ReturnOk()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var firstInDb = fakeDb.Users.First();
            var oldfakeDbLength = fakeDb.Users.Count();
            var controller = await createUsersControllerMoqAsync();

            //var claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.NameIdentifier,firstInDb.Id.ToString())
            //};
            //var ci = new ClaimsIdentity(claims);
            //var cp = new ClaimsPrincipal(ci);
            //await controller.HttpContext.SignInAsync(cp);

            // Act
            var result = await controller.DeleteUser(firstInDb.Id);

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result);

            var getUsersUpdated = await controller.GetUsers();
            var checkResponse = Assert.IsType<ObjectResult>(getUsersUpdated.Result);
            var castedCheckResponse = Assert.IsAssignableFrom<List<User>>(checkResponse.Value);

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.Equal(castedCheckResponse.Count(), oldfakeDbLength - 1);
            Assert.DoesNotContain<User>(firstInDb, castedCheckResponse);
        }


    }
}
