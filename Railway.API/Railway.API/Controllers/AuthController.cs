using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Railway.Core.Entities;
using Railway.Core.Entities.Static;
using Railway.Infrastructure.Dtos.Auth;
using Railway.Infrastructure.Dtos.Registration;
using Railway.Infrastructure.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Railway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly JwtHandler _jwtHandler;

    public AuthController(UserManager<User> userManager,
        IMapper mapper,
        JwtHandler jwtHandler)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        if (userForRegistrationDto == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var user = _mapper.Map<User>(userForRegistrationDto);

        var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);

            return BadRequest(new RegistrationResponseDto { Errors = errors });
        }

        await _userManager.AddToRoleAsync(user, UserRoles.User);

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
    {
        var user = await _userManager.FindByNameAsync(userForAuthenticationDto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthenticationDto.Password))
        {
            return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
        }

        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = await _jwtHandler.GetClaims(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
    }

    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var roles = User
            .FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        return Ok(new { Roles = roles });
    }
}
