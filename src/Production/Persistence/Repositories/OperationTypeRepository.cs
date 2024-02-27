using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OperationTypeRepository(WMS_DbContext dbContext) :EfRepositoryBase<OperationType,WMS_DbContext>(dbContext), IOperationTypeRepository
    {
    }
}
