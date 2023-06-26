using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shipping.Entities.Domain.Identity;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUserRole> _roleManager;
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;
        public AccountController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUserRole> roleManager,
            ISalesService salesService,
            IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _salesService = salesService;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            IList<Claim> claims = new List<Claim>();
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user != null)
            {
                if (!await _userManager.CheckPasswordAsync(user, credentials.Password))
                    return Unauthorized();
            }
            else
                return Unauthorized();
               
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (role != null)
            {
                var roleName = await _roleManager.FindByNameAsync(role);
                if (roleName != null)
                    claims = await _roleManager.GetClaimsAsync(roleName);
                    
            }
            var secretKeyString = _configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiryDate = DateTime.Now.AddDays(2);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiryDate,
                signingCredentials: signingCredentials);


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString =  tokenHandler.WriteToken(token);

            return new TokenDto
            {
                Token = tokenString,
                ExpiryDate = expiryDate,
                Role = role,
                Claims = _mapper.Map<List<string>>(claims.Select(c => c.Type))
            };
        }
    }
}
