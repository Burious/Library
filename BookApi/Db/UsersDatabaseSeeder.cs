using BookApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookApi.Db
{
    public static class UsersDatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedAdmins(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        private static void SeedAdmins(ModelBuilder modelBuilder)
        {
            var ph = new PasswordHasher<IdentityUser>();
            var user1 = new IdentityUser
            {
                Id = "1",
                UserName = "Artsemi",
                NormalizedUserName = "artsemi".ToUpper(),
                Email = "artsemi@gmail.com",
                EmailConfirmed = true
            };
            user1.PasswordHash = ph.HashPassword(user1, "Artsemi123");
            var user2 = new IdentityUser
            {
                Id = "2",
                UserName = "Admin",
                NormalizedUserName = "artsemi".ToUpper(),
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            user2.PasswordHash = ph.HashPassword(user2, "Admin123");
            modelBuilder.Entity<IdentityUser>().HasData(user1);

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
                });
        }
        public static void SeedUserRoles(ModelBuilder modelBuilder, string userId)
        {

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "reader_role",
                   UserId = userId
               });
           

        }
    }
}
