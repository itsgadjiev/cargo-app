using Cargo.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cargo.Application.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(7)]
        public string PinCode { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        public Branch Filial { get; set; }
        public Guid FilialId { get; set; }
    }
}

