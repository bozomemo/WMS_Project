using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ZoneRepository(WMS_DbContext dbContext) : EfRepositoryBase<Zone, WMS_DbContext>(dbContext)
    {
    }
}