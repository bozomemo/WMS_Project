using Application.Features.Shipment.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<ShipmentDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
