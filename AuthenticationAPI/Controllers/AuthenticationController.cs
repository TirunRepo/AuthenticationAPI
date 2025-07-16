using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationAPI.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public AuthenticationController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] ValidateUserCommand request)
        {
            var response = await _mediator.Send(request);
            if (response)
            {
                var jwtSettings = _config.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresInMinutes"])),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }
    }
}
