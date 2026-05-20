using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Lap03.DTOs;
using Lap03.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lap03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeController(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return BadRequest("User already exists");

            var employee = new Employee
            {
                FirstName = model.FirstName,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(employee, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Create role if not exists
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            // Add user to role
            await _userManager.AddToRoleAsync(employee, model.Role);

            return Ok("User created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return Unauthorized("Invalid email or password");

            var checkPassword =
                await _userManager.CheckPasswordAsync(user, model.Password);

            if (!checkPassword)
                return Unauthorized("Invalid email or password");

            var roles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // ================= JWT KEY =================
            string key = "THIS_IS_SUPER_SECRET_KEY_FOR_JWT_12345";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // ================= TOKEN =================
            var token = new JwtSecurityToken(
                claims: authClaims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = tokenString,
                expiration = token.ValidTo
            });
        }
    }
}