using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PalletTypeRepository(WMS_DbContext dbContext) : EfRepositoryBase<PalletType, WMS_DbContext>(dbContext)
    {
    }
}