using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OtpAuthenticatorRepository(WMS_DbContext dbContext) : EfRepositoryBase<OtpAuthenticator, WMS_DbContext>(dbContext), IOtpAuthenticatorRepository
    {
    }
}