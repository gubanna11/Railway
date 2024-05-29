using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Railway.Core.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Railway.Infrastructure.Services;

public class JwtHandler
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly IConfigurationSection _jwtSection;

    public JwtHandler(IConfiguration configuration,
        UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _jwtSection = _configuration.GetSection("JwtSettings");
    }

    public SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSection.GetSection("securityKey").Value);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

    }

    public async Task<ClaimsIdentity> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
            new Claim(ClaimTypes.Name, user.Email)
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims);

        return identity;
    }

    public SecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, ClaimsIdentity claimsIdentity)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSection["expiryInMinutes"])),
            SigningCredentials = signingCredentials,
            Issuer = _jwtSection["validIssuer"],
            Audience = _jwtSection["validAudience"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return securityToken;
    }
}
