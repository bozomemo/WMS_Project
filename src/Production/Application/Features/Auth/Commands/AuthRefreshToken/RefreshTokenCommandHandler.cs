using Application.Features.Auth.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Constants;
using MediatR;

namespace Application.Features.Auth.Commands.AuthRefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenDto>
    {
        private readonly IAuthService _authService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;

        public RefreshTokenCommandHandler(IAuthService authService, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
        {
            _authService = authService;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
        }

        public async Task<RefreshTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken ??
                throw new BusinessException(AuthConstants.REFRESH_TOKEN_COOKIE_DOESNT_EXIST)) ??
                throw new BusinessException(AuthConstants.REFRESH_TOKEN_DOESNT_EXIST);

            if (refreshToken.Revoked != null)
                await _authService.RevokeDescendantRefreshTokens(refreshToken, request.IpAddress ??
                    throw new BusinessException(AuthConstants.IP_ADDRESS_NULL), $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");

            if (refreshToken.Revoked != null && refreshToken.Expires > DateTime.UtcNow) throw new BusinessException(AuthConstants.REFRESH_TOKEN_EXPIRED);

            User? user = await _userRepository.GetAsync(x => x.Id == refreshToken.UserId) ?? throw new BusinessException(AuthConstants.USER_DOESNT_EXIST);

            RefreshToken newRefreshToken = await _authService.RotateRefreshToken(user, refreshToken, request.IpAddress!);

            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);

            await _authService.DeleteOldRefreshTokens(refreshToken.UserId);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            RefreshTokenDto refreshTokenDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };
            return refreshTokenDto;
        }
    }
}