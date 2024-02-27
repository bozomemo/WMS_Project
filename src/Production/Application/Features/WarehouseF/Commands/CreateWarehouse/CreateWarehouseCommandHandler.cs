using Application.Features.WarehouseF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseF.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, WarehouseDto>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public CreateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseDto> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = _mapper.Map<Warehouse>(request);

            var addedWh = await _warehouseRepository.AddAsync(warehouse);

            var dto = _mapper.Map<WarehouseDto>(addedWh);

            return dto;
        }
    }
}
