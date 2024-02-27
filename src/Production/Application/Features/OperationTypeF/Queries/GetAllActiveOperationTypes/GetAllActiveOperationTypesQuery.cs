using Application.Features.OperationTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationTypeF.Queries.GetAllActiveOperationTypes
{
    public class GetAllActiveOperationTypesQuery : IRequest<ICollection<OperationTypeDto>>, ISecuredRequest
    {
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
