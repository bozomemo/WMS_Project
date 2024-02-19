using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Constants;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        public static void UserPasswordShouldMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) throw new BusinessException(AuthConstants.WRONG_PASSWORD);
        }

        public static void ValidateToken(RefreshToken refreshToken)
        {
            if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires) throw new BusinessException(AuthConstants.INVALID_REFRESH_TOKEN);
        }
    }
}