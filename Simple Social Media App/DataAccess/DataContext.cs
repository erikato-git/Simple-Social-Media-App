using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "user1@mail.com",
                    Password = "pa$$w0rd",
                    Full_Name = "Per Hansen",
                },
                new User
                {
                    Id = 2,
                    Email = "user2@mail.com",
                    Password = "pa$$w0rd",
                    Full_Name = "Bo Warmming"
                },
                new User
                {
                    Id = 3,
                    Email = "user3@mail.com",
                    Password = "pa$$w0rd",
                    Full_Name = "Rasmus Paludan"
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Content = "Per Hansen ...",
                    UserId = 1,
                },
                new Post
                {
                    Id = 2,
                    Content = "Bo Warmming ...",
                    UserId = 2,
                },
                new Post
                {
                    Id = 3,
                    Content = "Rasmus Paludan ...",
                    UserId = 3,
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Content = "Bo Warmming - Thumbs Up ...",
                    PostId = 1,
                    UserId = 2,
                },
                new Comment
                {
                    Id = 2,
                    Content = "Rasmus Paludan - Thumbs Up ...",
                    PostId = 2,
                    UserId = 3,
                },
                new Comment
                {
                    Id = 3,
                    Content = "Per Hansen - Thumbs Up ...",
                    PostId = 3,
                    UserId = 1,
                }
            );


        }
    }
}
