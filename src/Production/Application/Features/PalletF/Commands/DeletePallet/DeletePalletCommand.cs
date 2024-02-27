using Application.Features.PalletF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Commands.DeletePallet
{
    public class DeletePalletCommand : IRequest<PalletDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
