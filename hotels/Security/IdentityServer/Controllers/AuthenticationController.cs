using AutoMapper;
using IdentityServer.Controllers.Base;
using IdentityServer.DTOs;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticationController : RegistrationControllerBase
    {
        public AuthenticationController(ILogger<AuthenticationController> logger, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(logger, mapper, userManager, roleManager)
        {
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
    }
}
