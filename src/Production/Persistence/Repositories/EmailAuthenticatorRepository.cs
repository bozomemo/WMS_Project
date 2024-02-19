using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmailAuthenticatorRepository(WMS_DbContext dbContext) : EfRepositoryBase<EmailAuthenticator, WMS_DbContext>(dbContext), IEmailAuthenticatorRepository
    {
    }
}