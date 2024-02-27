using Application.Features.PalletStatus.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletStatus.Queries.GetPalletStatusById
{
    public class GetPalletStatusByIdQuery : IRequest<PalletStatusDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
