using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
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
        private readonly ISalesService _salesService;
        private readonly ITraderService _traderService;
        private readonly IEmployeeService _employeeService;
        public AccountController(IConfiguration configuration, UserManager<ApplicationUser> userManager, ISalesService salesService,ITraderService traderService, IEmployeeService employeeService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _salesService = salesService;
            _traderService = traderService;
            _employeeService = employeeService;
        }
        [HttpPost]
        [Route("registerSales")]
        public async Task<ActionResult> RegisterSalesRepresentative(AddSalesDto salesRepresentative)
        {
            await _salesService.AddAsync(salesRepresentative);
            return Ok("SalesRepresentative Registered Successfully");
        }
        [HttpPost]
        [Route("registerTrader")]
        public async Task<ActionResult> RegisterTrader(TraderAddDto trader)
        {
            await _traderService.AddTraderAsync(trader);
            return Ok("Trader Registered Successfully");
        }
        [HttpPost]
        [Route("registerEmployee")]
        public async Task<ActionResult> RegisterEmployee(EmployeeAddDto employee)
        {
            await _employeeService.Add(employee);
            return Ok("Employee Registered Successfully");
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }

            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user?.Email)
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("Trader") || userRoles.Contains("SalesRepresentative") || userRoles.Contains("Employee"))
            {
                claimsList.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            }


            var secretKeyString = _configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);


            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

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
