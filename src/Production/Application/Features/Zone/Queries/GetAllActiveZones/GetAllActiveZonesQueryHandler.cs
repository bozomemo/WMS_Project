using Application.Features.Zone.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Queries.GetAllActiveZones
{
    public class GetAllActiveZonesQueryHandler : IRequestHandler<GetAllActiveZonesQuery, ICollection<ZoneDto>>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public GetAllActiveZonesQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<ICollection<ZoneDto>> Handle(GetAllActiveZonesQuery request, CancellationToken cancellationToken)
        {
            var zones = await _zoneRepository.Query().Where(x => x.IsActive).ToListAsync(cancellationToken: cancellationToken);

            var dtos = _mapper.Map<List<ZoneDto>>(zones);

            return dtos;
        }
    }
}
