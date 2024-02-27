using Application.Features.PalletTypeF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletTypeF.Queries.GetAllPalletTypes
{
    public class GetAllPalletTypesQuery : IRequest<ICollection<PalletTypeDto>>, ISecuredRequest
    {
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
