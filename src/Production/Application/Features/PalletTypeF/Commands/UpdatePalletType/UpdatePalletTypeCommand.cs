using Application.Features.PalletTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletTypeF.Commands.UpdatePalletType
{
    public class UpdatePalletTypeCommand : IRequest<PalletTypeDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
