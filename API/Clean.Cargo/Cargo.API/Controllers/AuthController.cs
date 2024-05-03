using Cargo.Application.Contracts.Identity;
using Cargo.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login(AuthRequest model)
        {
            return await _authService.Login(model);
        }

        [HttpPost("register")]

        public async Task<RegistrationResponse> Register(RegistrationRequest model)
        {
            return await _authService.Register(model, model.Role);
        }

        [HttpPost("logOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return Ok();
        }
    }
}

