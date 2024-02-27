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

namespace Application.Features.Zone.Queries.GetAllZones
{
    public class GetAllZonesQueryHandler : IRequestHandler<GetAllZonesQuery, ICollection<ZoneDto>>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public GetAllZonesQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<ICollection<ZoneDto>> Handle(GetAllZonesQuery request, CancellationToken cancellationToken)
        {
            var zones = await _zoneRepository.Query().ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<ZoneDto>>(zones);

            return dtos;
        }
    }
}
