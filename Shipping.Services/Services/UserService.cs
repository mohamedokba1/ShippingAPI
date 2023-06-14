using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipping.Entities.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserService(IConfiguration configuration,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<TokenDto> LoginUser(string email, string password)
    {
        var user = await _userManager.FindByNameAsync(email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Contains("Employee") && !roles.Contains("Trader") && !roles.Contains("Sales"))
        {
            throw new Exception("User does not have the required role");
        }

        var claimsList = new List<Claim>
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Email)
        };

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


    public async Task LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }
}