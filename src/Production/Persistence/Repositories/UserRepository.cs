using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRepository(WMS_DbContext dbContext) : EfRepositoryBase<User, WMS_DbContext>(dbContext), IUserRepository
    {
    }
}