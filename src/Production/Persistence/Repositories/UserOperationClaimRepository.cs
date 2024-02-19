using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository(WMS_DbContext dbContext) : EfRepositoryBase<UserOperationClaim, WMS_DbContext>(dbContext), IUserOperationClaimRepository
    {
    }
}