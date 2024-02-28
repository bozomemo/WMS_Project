using Application.Features.CartonF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.Commands.CreateCarton
{
    public class CreateCartonCommand : IRequest<CartonDto>, ISecuredRequest
    {
        public string? Description { get; set; }

        // Can be barcode or some other identifier.
        public string? UniqueIdentifier { get; set; }

        public string? LotNumber { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PalletId { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
