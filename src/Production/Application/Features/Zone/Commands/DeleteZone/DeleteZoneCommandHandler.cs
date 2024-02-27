using Application.Features.Zone.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Commands.DeleteZone
{
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand, ZoneDto>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public DeleteZoneCommandHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<ZoneDto> Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = await _zoneRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.ZONE_DOESNT_EXIST);

            var deletedZone = await _zoneRepository.DeleteAsync(zone);

            var dto = _mapper.Map<ZoneDto>(deletedZone);

            return dto;
        }
    }
}
