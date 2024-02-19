using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OperationClaimRepository(WMS_DbContext dbContext) : EfRepositoryBase<OperationClaim, WMS_DbContext>(dbContext), IOperationClaimRepository
    {
    }
}