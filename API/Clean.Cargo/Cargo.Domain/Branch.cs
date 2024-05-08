using Cargo.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo.Domain;

[Table("Branches")]
public record Branch : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
}
