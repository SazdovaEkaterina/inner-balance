using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InnerBalance.API.Domain.DTO;
using InnerBalance.API.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InnerBalance.API.Presentation.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController(UserManager<User> userManager, 
        IConfiguration configuration)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<object?>> Login([FromBody] Login model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return NotFound();
        }

        if (!await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized();
        }

        var jwtSecurityToken = CreateJwtSecurityToken(user);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            expiration = jwtSecurityToken.ValidTo
        });

    }

    [HttpPost]
    [Route("register-teacher")]
    public async Task<ActionResult<bool>> RegisterYogaTeacher([FromBody] RegisterTeacher model)
    {
        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            return Conflict(false);
        }

        var user = new YogaTeacher()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            Email = model.Email,
            Certification = model.Certification,
            YearsOfExperience = model.YearsOfExperience,
        };

        var createdUser = await _userManager.CreateAsync(user, model.Password);
        if (!createdUser.Succeeded)
        {
            return BadRequest(false);
        }

        return Ok(true);
    }

    [HttpPost]
    [Route("register-student")]
    public async Task<ActionResult<bool>> RegisterYogaStudent([FromBody] RegisterStudent model)
    {
        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            return Conflict(false);
        }

        var user = new YogaStudent()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            Email = model.Email,
            Membership = model.Membership,
        };

        var createdUser = await _userManager.CreateAsync(user, model.Password);
        if (!createdUser.Succeeded)
        {
            return BadRequest(false);
        }

        return Ok(true);
    }

    private JwtSecurityToken CreateJwtSecurityToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Authentication:SecretForKey"]));
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("first_name", user.FirstName));
        claimsForToken.Add(new Claim("last_name", user.LastName));

        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);
        return jwtSecurityToken;
    }
}