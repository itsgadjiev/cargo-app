using Cargo.Application.Models.Identity;

namespace Cargo.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registartionRequest, string role);
        Task SignOut();

    }
}
