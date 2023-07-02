using Flowers.Api.Dtos;
using Flowers.Api.Services;
using Flowers.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flowers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, JwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        //[HttpGet("Role")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

        //    return Ok();
        //}

        //[HttpGet("CreateAdmin")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    var user = new AppUser
        //    {
        //        UserName = "Admin",
        //        FullName = "Elmeddin Mirzeyev",
        //        Email = "admin@gmail.com"
        //    };

        //    await _userManager.CreateAsync(user, "Admin123");
        //    await _userManager.AddToRoleAsync(user, "Admin");

        //    return Ok();
        //}


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(_jwtService.GenerateToken(user, roles));
        }
    }
}
