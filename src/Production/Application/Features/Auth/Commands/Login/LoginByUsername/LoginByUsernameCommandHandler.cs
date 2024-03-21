using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Constants;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByUsername
{
    public class LoginByUsernameCommandHandler : IRequestHandler<LoginByUsernameCommand, UserLoginDto>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public LoginByUsernameCommandHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<UserLoginDto> Handle(LoginByUsernameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByUsername(request.Username) ?? throw new BusinessException(AuthConstants.USER_DOESNT_EXIST);

            if (request.IpAddress is null) throw new BusinessException(AuthConstants.IP_ADDRESS_NULL);

            AuthBusinessRules.UserPasswordShouldMatch(user, request.Password);

            var accessToken = await _authService.CreateAccessToken(user);

            var refreshToken = _authService.CreateRefreshToken(user, request.IpAddress);

            var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

            return new() { Id = user.Id, Email = user.Email, Name = user.FirstName + " " + user.LastName, AccessToken = accessToken, RefreshToken = addedRefreshToken };
        }
    }
}