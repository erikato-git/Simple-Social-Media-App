using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.DataAccess.Model;
using Simple_Social_Media_App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_Social_Media_App.Controllers;
using Simple_Social_Media_App.Repositories;
using Simple_Social_Media_App.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleSocialMediaAppTests.ControllerTests
{
    public class PostsControllerTests
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
                    new User(){ UserId = new Guid(), Full_Name = "Alice", Email = "alice@mail.com", Password = "123" },
                    new User(){ UserId = new Guid(), Full_Name = "Bob", Email = "bob@mail.com", Password = "123" },
                    new User(){ UserId = new Guid(), Full_Name = "Charlie", Email = "charlie@mail.com", Password = "123" }
                };

                foreach (var i in tmpUsers)
                {
                    fakeDb.Users.Add(i);
                }
            }

            await fakeDb.SaveChangesAsync();


            if (await fakeDb.Posts.CountAsync() == 0)
            {
                // TODO: Vær opmærksom på at UserId ikke er tilknyttet nogen fra listen
                var tmpPosts = new List<Post>()
                {
                    new Post(){ PostId = new Guid(), Content = "Post from Alice", UserId = new Guid()},
                    new Post(){ PostId = new Guid(), Content = "Post from Bob", UserId = new Guid()},
                    new Post(){ PostId = new Guid(), Content = "Post from Charlie", UserId = new Guid()}
                };

                foreach (var i in tmpPosts)
                {
                    fakeDb.Posts.Add(i);
                }
            }

            await fakeDb.SaveChangesAsync();

            return fakeDb;
        }

        public async Task<PostsController> createPostsControllerMoqAsync()
        {
            var fakeDb = await GetDbContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperService());
            });
            var mapper = config.CreateMapper();
            var userRepository = new UserRepository(fakeDb, mapper);
            var postRepository = new PostRepository(fakeDb, mapper);
            var controller = new PostsController(postRepository,userRepository);
            return controller;
        }

        [Fact]
        public async void GetPosts_Ok()
        {
            // Arrange
            var fakeDb = await GetDbContext();
            var controller = await createPostsControllerMoqAsync();

            // Act
            var result = await controller.GetPosts();

            // Assert
            Assert.NotNull(result);

            var response = Assert.IsType<ObjectResult>(result.Result);
            var actual = Assert.IsAssignableFrom<List<User>>(response.Value);    // casting result to ObjectResult

            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(fakeDb.Posts.ToList().Count, actual.Count);

        }

        [Fact]
        public async void GetPost_Ok()
        {

        }

        [Fact]
        public async void UpdatePost_Ok()
        {

        }

        [Fact]
        public async void CreatePost_Ok()
        {

        }


        [Fact]
        public async void DeletePost_Ok()
        {

        }


    }
}
