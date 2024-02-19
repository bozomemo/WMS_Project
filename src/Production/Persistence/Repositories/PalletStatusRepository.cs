using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PalletStatusRepository(WMS_DbContext dbContext) : EfRepositoryBase<PalletStatus, WMS_DbContext>(dbContext)
    {
    }
}