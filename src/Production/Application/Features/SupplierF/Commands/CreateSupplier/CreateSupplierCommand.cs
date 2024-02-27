using Application.Features.SupplierF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierF.Commands.CreateSupplier
{
    public class CreateSupplierCommand : IRequest<SupplierDto>, ISecuredRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}