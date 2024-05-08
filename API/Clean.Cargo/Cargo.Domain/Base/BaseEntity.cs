using System.ComponentModel.DataAnnotations;

namespace Cargo.Domain.Base
{
    public record BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
