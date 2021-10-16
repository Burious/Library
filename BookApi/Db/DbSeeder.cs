using BookApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookApi.Db
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedBooks(modelBuilder);
            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        private static void SeedBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                                new Book
                                {
                                    Id = Guid.NewGuid(),
                                    //Id = 1,
                                    Title = "CLR via C#",
                                    Author = "Jeffrey Richter",
                                    Description = "Programming on Microsoft .Net platform with C# language",
                                    Publishment = "Piter Publishment",
                                    YearOfPublish = new DateTime(2020,1,1)
                                    
                                },
                                new Book
                                {
                                    Id = Guid.NewGuid(),
                                    //Id=2,
                                    Title = "Investor's Manifest",
                                    Author = "William J. Bernstein",
                                    Description = "Prepearing for Prosperity, Armagedon, and everything in between",
                                    Publishment = "Alpina publisher",
                                    YearOfPublish = new DateTime(2021,1,1)
                                }
                            );  
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var ph = new PasswordHasher<IdentityUser>();
            var user1 = new IdentityUser
            {
                Id = "1",
                UserName = "artsemi",
                NormalizedUserName = "artsemi".ToUpper(),
                Email = "artsemi@gmail.com",
                EmailConfirmed = true
            };
            user1.PasswordHash = ph.HashPassword(user1, "Artsemi123");

            var user2 = new IdentityUser
            {
                Id = "2",
                UserName = "mike",
                NormalizedUserName = "mike".ToUpper(),
                Email = "mike@gmail.Com",
                EmailConfirmed = true
            };
            user2.PasswordHash = ph.HashPassword(user2, "Mike123");

            modelBuilder.Entity<IdentityUser>().HasData(user1, user2);

        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "admin_role",
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                },
                new IdentityRole
                {
                    Id = "reader_role",
                    Name = "reader",
                    NormalizedName = "reader".ToUpper()
                }); 
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "admin_role",
                    UserId = "1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "reader_role",
                    UserId = "2"
                });
        }
    }
}
