using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _salesManager;

        public AccountController(IConfiguration configuration, UserManager<ApplicationUser> salesManager)
        {
            _configuration = configuration;
            _salesManager = salesManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _salesManager.FindByNameAsync(credentials.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var isAuthenticated = await _salesManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }

            var claimsList = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user?.Email)
            };

            var userRoles = await _salesManager.GetRolesAsync(user);
            if (userRoles.Contains("trader") || userRoles.Contains("salesrepresentative") || userRoles.Contains("employee"))
            {
                claimsList.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var secretKeyString = _configuration.GetValue<string>("SecretKey");
            var secretKeyBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretKeyBytes);

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expiryDate = DateTime.Now.AddDays(2);
            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiryDate,
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenDto
            {
                Token = tokenString,
                ExpiryDate = expiryDate,
            };
        }

    }

}
