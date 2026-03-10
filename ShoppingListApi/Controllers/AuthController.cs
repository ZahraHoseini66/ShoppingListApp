using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AuthController : ControllerBase
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly IConfiguration _config;
	public AuthController(
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		IConfiguration configuration)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_config = configuration;

	}

	[HttpPost("register")]
	
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var user = new ApplicationUser
		{
			UserName = request.Email,
			Email = request.Email,
			FirstName = request.FirstName,
			LastName = request.LastName,
			RoleId = request.RoleId

		};

		var result = await _userManager.CreateAsync(user, request.Password);

		if (!result.Succeeded)
		{
			return BadRequest(result.Errors);

		}
		var token = GenerateJwtToken(user);
		return Ok(token);
	}

	[HttpPost("Login")]
	public async Task<IActionResult> Login(LoginRequest request)
	{
		var user = await _userManager.FindByEmailAsync(request.Email);
		if (user == null)
		{
			return Unauthorized("Invalid credentials");
		}

		var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
		if (!result.Succeeded)
		{
			return Unauthorized("Invalid credentials");

		}
		var token = GenerateJwtToken(user);
		return Ok(token);
	}

	private AuthResponse GenerateJwtToken(ApplicationUser user)
	{
		var jwtSetting = _config.GetSection("JwtSettings");
		var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["SecretKey"]));

		var claims = new List<Claim>
	{
		new Claim(JwtRegisteredClaimNames.Sub,user.Id),
		new Claim(JwtRegisteredClaimNames.Email , user.Email ?? string.Empty),
		new Claim(ClaimTypes.NameIdentifier,user.Id)

	};

		var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
		var expires = DateTime.UtcNow.AddHours(2);

		var token = new JwtSecurityToken(
			issuer: jwtSetting["Issuer"],
			audience: jwtSetting["Audience"],
			claims: claims,
			expires: expires,
			signingCredentials: creds);

		var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

		return new AuthResponse
		{
			Token = tokenString,
			ExpiresAt = expires
		};


	}
}	
