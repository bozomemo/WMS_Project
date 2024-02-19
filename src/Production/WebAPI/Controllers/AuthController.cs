using Application.Features.Auth.Commands.AuthRefreshToken;
using Application.Features.Auth.Commands.Login.LoginByEmail;
using Application.Features.Auth.Commands.Login.LoginByUsername;
using Application.Features.Auth.Models;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("LoginByEmail")]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailModel model)
        {
            var result = await Mediator.Send(new LoginByEmailCommand { Email = model.Email, Password = model.Password, IpAddress = GetIpAddress()! });

            if (result.RefreshToken is not null) SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result);
        }

        [HttpPost("LoginByUsername")]
        public async Task<IActionResult> LoginByUsername([FromBody] LoginByUsernameModel model)
        {
            var result = await Mediator.Send(new LoginByUsernameCommand { Username = model.Username, Password = model.Password, IpAddress = GetIpAddress()! });

            if (result.RefreshToken is not null) SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result);
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var command = new RefreshTokenCommand
            {
                IpAddress = GetIpAddress(),
                RefreshToken = GetRefreshTokenFromCookies()
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        private string? GetRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7), SameSite = SameSiteMode.None, Secure = true };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}