using Application.Features.PalletF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Queries.GetAllPallets
{
    public class GetAllPalletsQuery : IRequest<ICollection<PalletDto>>, ISecuredRequest
    {
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
