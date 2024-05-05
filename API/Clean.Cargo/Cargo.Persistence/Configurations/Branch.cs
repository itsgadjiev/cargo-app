using Cargo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Persistence.Configurations
{
    public class Branch : IEntityTypeConfiguration<Domain.Branch>
    {
        public void Configure(EntityTypeBuilder<Domain.Branch> builder)
        {
            Guid filial1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            Guid filial2Id = Guid.Parse("00000000-0000-0000-0000-000000000002");

            builder.HasData(
                new Domain.Branch
                {
                    Id = filial1Id,
                    Name = "Filial 1",
                    Address = "Address 1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Domain.Branch
                {
                    Id = filial2Id,
                    Name = "Filial 2",
                    Address = "Address 2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            );
        }
    }
}
