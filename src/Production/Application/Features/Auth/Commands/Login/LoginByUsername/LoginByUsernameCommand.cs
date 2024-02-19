using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByUsername
{
    public class LoginByUsernameCommand : IRequest<AccessToken>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}