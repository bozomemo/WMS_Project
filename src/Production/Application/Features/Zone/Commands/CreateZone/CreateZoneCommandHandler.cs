using Application.Features.Zone.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Commands.CreateZone
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, ZoneDto>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public CreateZoneCommandHandler(IMapper mapper, IZoneRepository zoneRepository, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ZoneDto> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetAsync(x => x.Id == request.WarehouseId) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            var zone = _mapper.Map<Domain.Entities.Zone>(request);

            var addedZone = await _zoneRepository.AddAsync(zone);

            var dto = _mapper.Map<ZoneDto>(addedZone);

            return dto;
        }
    }
}
