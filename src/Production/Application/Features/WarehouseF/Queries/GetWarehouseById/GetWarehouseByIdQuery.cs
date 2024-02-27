using Application.Features.WarehouseF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseF.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQuery : IRequest<WarehouseDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
