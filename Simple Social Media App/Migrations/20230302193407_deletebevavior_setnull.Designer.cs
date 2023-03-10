// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simple_Social_Media_App.DataAccess;

#nullable disable

namespace Simple_Social_Media_App.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230302193407_deletebevavior_setnull")]
    partial class deletebevavior_setnull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PostId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa311"),
                            Content = "comment 1",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4775),
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa211"),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa111")
                        },
                        new
                        {
                            CommentId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa312"),
                            Content = "comment 2",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4783),
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa212"),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa112")
                        },
                        new
                        {
                            CommentId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa313"),
                            Content = "comment 3",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4787),
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa211"),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa111")
                        });
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa211"),
                            Content = "user 1",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4739),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa111")
                        },
                        new
                        {
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa212"),
                            Content = "user 2",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4747),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa112")
                        },
                        new
                        {
                            PostId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa213"),
                            Content = "user 3",
                            CreatedAt = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4750),
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa113")
                        });
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Profile_Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Salt")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa111"),
                            DateOfBirth = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4448),
                            Email = "user1@mail.com",
                            Full_Name = "user 1",
                            Password = "123",
                            Salt = 0
                        },
                        new
                        {
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa112"),
                            DateOfBirth = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4478),
                            Email = "user2@mail.com",
                            Full_Name = "user 2",
                            Password = "123",
                            Salt = 0
                        },
                        new
                        {
                            UserId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaa113"),
                            DateOfBirth = new DateTime(2023, 3, 2, 19, 34, 7, 463, DateTimeKind.Utc).AddTicks(4482),
                            Email = "user3@mail.com",
                            Full_Name = "user 3",
                            Password = "123",
                            Salt = 0
                        });
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.Comment", b =>
                {
                    b.HasOne("Simple_Social_Media_App.DataAccess.Model.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Simple_Social_Media_App.DataAccess.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.Post", b =>
                {
                    b.HasOne("Simple_Social_Media_App.DataAccess.Model.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Simple_Social_Media_App.DataAccess.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
