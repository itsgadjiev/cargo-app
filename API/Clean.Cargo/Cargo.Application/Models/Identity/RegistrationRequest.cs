﻿using System.ComponentModel.DataAnnotations;

namespace Cargo.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        public string Role { get; set; }
    }
}
