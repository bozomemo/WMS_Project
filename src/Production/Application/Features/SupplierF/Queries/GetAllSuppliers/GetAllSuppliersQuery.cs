using Application.Features.SupplierF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierF.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<ICollection<SupplierDto>>, ISecuredRequest
    {
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
