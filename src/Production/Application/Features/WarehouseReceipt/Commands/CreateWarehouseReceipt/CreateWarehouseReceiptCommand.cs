using Application.Features.WarehouseReceipt.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Commands.CreateWarehouseReceipt
{
    public class CreateWarehouseReceiptCommand : IRequest<WarehouseReceiptDto>, ISecuredRequest
    {
        public required string OrderNo { get; set; }
        /// <summary>
        /// İrsaliye numarası
        /// </summary>
        public required string DeliveryNoteNo { get; set; }

        public bool Approved { get; set; }

        public bool HasIrregularProducts { get; set; }

        public int? ApprovedByUserId { get; set; }

        public int CreatedByUserId { get; set; }

        public virtual List<WarehouseItemDto> WarehouseReceiptItems { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
