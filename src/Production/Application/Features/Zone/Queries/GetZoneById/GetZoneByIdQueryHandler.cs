using Application.Features.Zone.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.Zone.Queries.GetZoneById
{
    public class GetZoneByIdQueryHandler : IRequestHandler<GetZoneByIdQuery, ZoneDto>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public GetZoneByIdQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            var zone = await _zoneRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.ZONE_DOESNT_EXIST);

            var dto = _mapper.Map<ZoneDto>(zone);

            return dto;
        }
    }
}