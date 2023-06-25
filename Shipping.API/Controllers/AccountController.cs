using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Shipping.Entities.Domain.Identity;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.PrermissionDtos;
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
            var identity = new ClaimsIdentity();
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user != null)
                 await _userManager.CheckPasswordAsync(user, credentials.Password);
            else
                return Unauthorized();
               
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (role != null)
            {
                var roleName = await _roleManager.FindByNameAsync(role);
                if (roleName != null)
                {
                    var userClaims = await _userManager.GetClaimsAsync(user);
                    claims = await _roleManager.GetClaimsAsync(roleName);
                    identity = new ClaimsIdentity(userClaims, "Bearer");
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                }
                    
            }
            var secretKeyString = _configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

            //var signingCredentials = new SigningCredentials(secretKey,
            //    SecurityAlgorithms.HmacSha256Signature);

            //var expiryDate = DateTime.Now.AddDays(2);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
            };
            //var token = new JwtSecurityToken(
            //    claims: claims,
            //    expires: expiryDate,
            //    signingCredentials: signingCredentials);


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString =  tokenHandler.WriteToken(token);

            return new TokenDto
            {
                Token = tokenString,
                ExpiryDate = tokenDescriptor.Expires,
                Role = role,
                Claims = _mapper.Map<List<ClaimDto>>(claims)
            };
        }
    }
}
