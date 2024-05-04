using Cargo.Domain.Base;

namespace Cargo.Domain;

public record Filial : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
}
