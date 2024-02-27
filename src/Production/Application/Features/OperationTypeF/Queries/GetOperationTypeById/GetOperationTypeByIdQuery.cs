using Application.Features.OperationTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationTypeF.Queries.GetOperationTypeById
{
    public class GetOperationTypeByIdQuery : IRequest<OperationTypeDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
