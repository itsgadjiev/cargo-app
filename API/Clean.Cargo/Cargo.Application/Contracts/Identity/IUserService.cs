using Cargo.Application.Models.Identity;

namespace Cargo.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<LoginedUser> GetUserAsync(string userId);
        public string UserId { get; }
        Task<LoginedUser> GetCurrentUserAsync();
    }
}
