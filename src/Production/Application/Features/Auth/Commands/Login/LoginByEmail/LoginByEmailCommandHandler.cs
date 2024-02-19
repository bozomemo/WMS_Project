using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByEmail
{
    public class LoginByEmailCommandHandler : IRequestHandler<LoginByEmailCommand, LoggedDto>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public LoginByEmailCommandHandler(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<LoggedDto> Handle(LoginByEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmail(request.Email) ?? throw new BusinessException(AuthConstants.USER_DOESNT_EXIST);

            AuthBusinessRules.UserPasswordShouldMatch(user, request.Password);

            var accessToken = await _authService.CreateAccessToken(user);

            var refreshToken = _authService.CreateRefreshToken(user, request.IpAddress);

            var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

            return new() { AccessToken = accessToken, RefreshToken = addedRefreshToken };
        }
    }
}