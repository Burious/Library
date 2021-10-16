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
                                    //Id = Guid.NewGuid(),
                                    Id = 1,
                                    Title = "T1",
                                    Author = "A1",
                                    Description = "D1",
                                    Publishment = "P1"
                                },
                                new Book
                                {
                                    //Id = Guid.NewGuid(),
                                    Id=2,
                                    Title = "T2",
                                    Author = "A2",
                                    Description = "D2",
                                    Publishment = "P2"
                                }
                            );  
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var ph = new PasswordHasher<IdentityUser>();
            var user1 = new IdentityUser
            {
                Id = "1",
                UserName = "patrick",
                NormalizedUserName = "patrick".ToUpper(),
                Email = "patrick@fakemail.com",
                EmailConfirmed = true
            };
            user1.PasswordHash = ph.HashPassword(user1, "Patrick123");

            var user2 = new IdentityUser
            {
                Id = "2",
                UserName = "mike",
                NormalizedUserName = "mike".ToUpper(),
                Email = "mike@fakemail.Com",
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
