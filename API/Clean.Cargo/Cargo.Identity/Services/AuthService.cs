﻿using Cargo.Application.Contracts.Identity;
using Cargo.Application.Contracts.Logging;
using Cargo.Application.Exceptions;
using Cargo.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cargo.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAppLogger<AuthService> _appLogger;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IAppLogger<AuthService> appLogger
            )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _appLogger = appLogger;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new NotFoundException(nameof(AuthService), $"Invalid username or Password.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (result.Succeeded == false)
            {
                throw new NotFoundException(nameof(AuthService), $"Invalid username or Password.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var roleName = await _userManager.GetRolesAsync(user);
            var response = new AuthResponse
            {
                LoginedUser = new LoginedUser
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = roleName.ToList(),
                    Name = user.FirstName,
                    Surname = user.LastName,
                    Adress = user.Adress,
                    Number = user.PhoneNumber,
                    PinCode = user.PinCode,
                }
            };

            _appLogger.LogInformation("Success login");
            return response;
        }


        public async Task<RegistrationResponse> Register(RegistrationRequest request, string role)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = false,
                Id = request.Id,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                _appLogger.LogInformation("Success register");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }
                _appLogger.LogCritical("Invalid register");
                throw new BadRequestException($"{str}");
            }

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),

            }
            .Union(userClaims)
            .Union(roleClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task SignOut()
        {
            _appLogger.LogInformation("Success SignOut");
            await _signInManager.SignOutAsync();
        }

    }
}
