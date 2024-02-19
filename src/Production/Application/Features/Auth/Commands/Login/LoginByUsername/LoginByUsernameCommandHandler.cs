using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByUsername
{
    public class LoginByUsernameCommandHandler : IRequestHandler<LoginByUsernameCommand, AccessToken>
    {
        public Task<AccessToken> Handle(LoginByUsernameCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}