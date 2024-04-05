using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using TAB.Data.Enums;

namespace TAB.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Configs
            modelBuilder.Entity<Config>().HasData
            (
                new Config()
                {
                    Key = "Home Title",
                    Value = "Home Page"
                },

                new Config()
                {
                    Key = "Key Word",
                    Value = "Key Word"
                },

                new Config()
                {
                    Key = "Home Description",
                    Value = "Description Page"
                }
            );

            // Categories
            modelBuilder.Entity<Category>().HasData
            (
                new Category()
                {
                    CategoryId = 1,
                    BrandId = 1,
                    CategoryName = "Vợt cầu lông",
                    Status = Status.Active,
                },

                new Category()
                {
                    CategoryId = 2,
                    BrandId = 1,
                    CategoryName = "Giày cầu lông",
                    Status = Status.Active,
                }
            );

           

            // Brands
            modelBuilder.Entity<Brand>().HasData
            (
                new Brand()
                {
                    BrandId = 1,
                    BrandName = "VNB",
                    Address = "Việt Nam",
                    NumberPhone = "null",
                    Status = Status.Active
                }
            );

            // Products
            modelBuilder.Entity<Product>().HasData
            (
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Vợt cầu lông VNB TC88C",
                    ProductImage = "",
                    CategoryIds = 1,
                    Price = 790000,
                    OriginalPrice = 700000,
                    DateCreated = DateTime.Now,
                    Stock = 0,
                    ViewCount = 0,
                    Description = "Vợt thiên công nặng đầu 3U",
                },

                new Product()
                {
                    ProductId = 2,
                    CategoryIds = 1,
                    ProductName = "Vợt cầu lông VNB TC88B",
                    ProductImage = "",
                    Price = 790000,
                    OriginalPrice = 700000,
                    DateCreated = DateTime.Now,
                    Stock = 0,
                    ViewCount = 0,
                    Description = "Vợt thiên công nặng đầu 3U",
                }
            );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            // Roles
            modelBuilder.Entity<Role>().HasData
            (
                new Role
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                }
            );

            // Users
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = adminId,
                    UserName = "admin",
                    Password = "1",
                    NormalizedUserName = "admin",
                    Email = "kudoshinichi2804@gmail.com",
                    NormalizedEmail = "kudoshinichi2804@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "1"),
                    SecurityStamp = string.Empty,
                    FullName = "Kudo Shinichi",
                    Dob = new DateTime(2020, 01, 31),
                    PhoneNumber = "0932690343",
                    Address = "26 Lam Hoanh, P.An Lac, Q.Binh Tan, TP.HCM",
                    Avatar = "https://scontent.fsgn5-3.fna.fbcdn.net/v/t1.15752-9/430866613_945496816974002_8073114596546427994_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=5f2048&_nc_ohc=qNpNZ_y0TdUAX_b6ZGV&_nc_ht=scontent.fsgn5-3.fna&oh=03_AdTVWK9bgUw9-VtEDmnB6EwpiryBn-4iRLRBzGIEflDOcw&oe=662232AA",
                    PhoneNumberConfirmed = true,
                    AccessFailedCount = 0,
                }
            );

            // IdentityUserRole GUId
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData
            (new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            }
            );

            // Slides
            modelBuilder.Entity<Slide>().HasData(
              new Slide() { SlideId = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { SlideId = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { SlideId = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { SlideId = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { SlideId = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { SlideId = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );
        }
    }
}