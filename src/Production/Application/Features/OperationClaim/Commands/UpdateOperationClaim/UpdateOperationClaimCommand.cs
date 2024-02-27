using Application.Features.OperationClaim.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<OperationClaimWithIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool? IsActive { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}