using Application.Features.OperationTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationTypeF.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommand : IRequest<OperationTypeDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public int WarehouseId { get; set; }
        
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
