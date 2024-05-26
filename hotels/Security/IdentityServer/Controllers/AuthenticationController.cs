using AutoMapper;
using IdentityServer.Controllers.Base;
using IdentityServer.DTOs;
using IdentityServer.Entities;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticationController : RegistrationControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAuthenticationService authenticationService) : base(logger, mapper, userManager, roleManager)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterGuest([FromBody] NewUserDto newUser)
        {
            return await RegisterNewUserWithRoles(newUser, new string[] { "Guest" });
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterHotel([FromBody] NewUserDto newUser)
        {
            return await RegisterNewUserWithRoles(newUser, new string[] { "Hotel" });
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(AuthenticationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogIn([FromBody] UserCredentialsDto userCredentialsDto)
        {
            var user = await _authenticationService.ValidateUser(userCredentialsDto);
            if(user == null)
            {
                _logger.LogWarning($"{nameof(LogIn)}: Authentication failed. Wrong username or password.");
                return Unauthorized();
            }

            return Ok(await _authenticationService.CreateAuthenticationModel(user));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(AuthenticationModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<AuthenticationModel>> Refresh([FromBody] RefreshTokenModel refreshTokenCredentials)
        {
            var user = await _userManager.FindByNameAsync(refreshTokenCredentials.UserName);
            if(user == null)
            {
                _logger.LogWarning($"{nameof(Refresh)}: Refreshing token failed. Unknown username {refreshTokenCredentials.UserName}.");
                return Forbid();
            }

            var refreshToken = user.RefreshTokens.FirstOrDefault(r => r.Token == refreshTokenCredentials.RefreshToken);
            if(refreshToken == null)
            {
                _logger.LogWarning($"{nameof(Refresh)}: Refreshing token failed. The refresh token is not found.");
                return Unauthorized();
            }

            if(refreshToken.ExpiryTime < DateTime.Now)
            {
                _logger.LogWarning($"{nameof(Refresh)}: Refreshing token failed. The refresh token is not valid.");
                return Unauthorized();
            }

            return Ok(await _authenticationService.CreateAuthenticationModel(user));
        }

        [Authorize]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> LogOut([FromBody] RefreshTokenModel refreshTokenCredentials)
        {
            var user = await _userManager.FindByNameAsync(refreshTokenCredentials.UserName);
            if (user == null)
            {
                _logger.LogWarning($"{nameof(LogOut)}: Logout failed. Unknown username {refreshTokenCredentials.UserName}.");
                return Forbid();
            }

            await _authenticationService.RemoveRefreshToken(user, refreshTokenCredentials.RefreshToken);

            return Accepted();
        }
    }
}
