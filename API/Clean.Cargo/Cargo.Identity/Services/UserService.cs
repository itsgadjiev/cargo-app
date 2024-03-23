using Cargo.Application.Contracts.Identity;
using Cargo.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cargo.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId => _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        private async Task<LoginedUser> GetUserFromIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User is not authenticated");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new LoginedUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList(),
                Name = user.FirstName,
                Surname = user.LastName,
            };
        }

        public async Task<LoginedUser> GetUserAsync(string userId)
        {
            return await GetUserFromIdAsync(userId);
        }

        public async Task<LoginedUser> GetCurrentUserAsync()
        {
            return await GetUserFromIdAsync(UserId);
        }
    }
}
