using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class SupplierRepository(WMS_DbContext dbContext) : EfRepositoryBase<Supplier, WMS_DbContext>(dbContext), ISupplierRepository
    {
    }
}