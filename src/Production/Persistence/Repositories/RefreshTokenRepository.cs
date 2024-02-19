using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository(WMS_DbContext dbContext) : EfRepositoryBase<RefreshToken, WMS_DbContext>(dbContext), IRefreshTokenRepository
    {
    }
}