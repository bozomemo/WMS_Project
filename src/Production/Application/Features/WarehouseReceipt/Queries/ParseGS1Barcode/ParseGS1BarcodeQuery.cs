using Application.Features.WarehouseReceipt.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Queries.ParseGS1Barcode
{
    public class ParseGS1BarcodeQuery : IRequest<GS1BarcodeContentDTO>, ISecuredRequest
    {
        public string GS1Barcode { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
