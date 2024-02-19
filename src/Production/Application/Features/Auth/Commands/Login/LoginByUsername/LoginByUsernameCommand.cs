using Application.Features.Auth.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByUsername
{
    public class LoginByUsernameCommand : IRequest<LoggedDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string? IpAddress { get; set; }
    }
}