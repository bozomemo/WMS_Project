using Application.Features.Zone.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Commands.UpdateZone
{
    public class UpdateZoneCommand : IRequest<ZoneDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string? ZoneCode { get; set; }

        public string? Description { get; set; }

        public int WarehouseId { get; set; }

        public bool IsBin { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}