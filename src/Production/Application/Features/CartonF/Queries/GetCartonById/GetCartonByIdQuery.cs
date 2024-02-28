using Application.Features.CartonF.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.Queries.GetCartonById
{
    public class GetCartonByIdQuery : IRequest<CartonDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => [RolesConstants.ADMIN_ROLE];
    }
}
