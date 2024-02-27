using Application.Features.PalletF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Commands.CreatePallet
{
    public class CreatePalletCommand : IRequest<PalletDto>, ISecuredRequest
    {
        public string Barcode { get; set; }

        public string? Description { get; set; }

        public int SupplierId { get; set; }

        public int ZoneId { get; set; }

        public int StatusId { get; set; }

        public int PalletTypeId { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
