﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "abc43a8e-f7bb-8875-baaf-1add431ffbbf",
                    Name = "Driver",
                    NormalizedName = "DRIVER"
                },
                 new IdentityRole
                 {
                     Id = "acf62g8e-f7bb-8875-baaf-1add431ffbbf",
                     Name = "Dispatcher",
                     NormalizedName = "DISPATCHER"
                 },
                  new IdentityRole
                  {
                      Id = "acf61g8e-f9bb-8875-baaf-1add431ffbbf",
                      Name = "CustomerService",
                      NormalizedName = "CUSTOMERSERVICE"
                  }, new IdentityRole
                  {
                      Id = "vcf61g8e-f9bb-8175-bcaf-1add431ffbbf",
                      Name = "ITSupport",
                      NormalizedName = "ITSUPPORT"
                  });
        }
    }
}
