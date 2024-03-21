using Application.Features.Shipment.Dtos;
using Application.Features.WarehouseReceipt.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.Commands.UpdateShipment
{
    public class UpdateShipmentCommand : IRequest<ShipmentDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string? OrderNo { get; set; }
        /// <summary>
        /// İrsaliye numarası
        /// </summary>
        public string? DeliveryNoteNo { get; set; }

        public bool? Approved { get; set; }

        public bool? HasIrregularProducts { get; set; }

        public bool? IsActive { get; set; }

        public int? ApprovedByUserId { get; set; }

        public int? CreatedByUserId { get; set; }

        public ICollection<WarehouseItemDto>? ShipmentItems { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
