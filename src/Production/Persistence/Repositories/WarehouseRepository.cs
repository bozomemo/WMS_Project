using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class WarehouseRepository(WMS_DbContext dbContext) : EfRepositoryBase<Warehouse, WMS_DbContext>(dbContext), IWarehouseRepository
    {
    }
}