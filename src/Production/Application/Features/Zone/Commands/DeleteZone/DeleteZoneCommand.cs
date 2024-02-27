using Application.Features.Zone.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Commands.DeleteZone
{
    public class DeleteZoneCommand : IRequest<ZoneDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
