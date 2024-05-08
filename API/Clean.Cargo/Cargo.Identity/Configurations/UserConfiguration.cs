﻿using Cargo.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "123"),
                     EmailConfirmed = true,
                     Adress = "Baku",
                     PinCode = "1234567",
                     BranchId = Guid.Parse("00000000-0000-0000-0000-000000000001"),

                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user",
                     NormalizedUserName = "USER",
                     PasswordHash = hasher.HashPassword(null, "123"),
                     EmailConfirmed = true,
                     Adress = "Baku",
                     PinCode="1234567",
                     BranchId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                 }
            );
        }
    }
}
