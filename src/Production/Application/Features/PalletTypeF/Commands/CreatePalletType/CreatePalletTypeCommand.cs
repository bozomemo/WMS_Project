using Application.Features.PalletTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;

namespace Application.Features.PalletTypeF.Commands.CreatePalletType
{
    public class CreatePalletTypeCommand : IRequest<PalletTypeDto>, ISecuredRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
        
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}