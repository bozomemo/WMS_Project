using Application.Features.WarehouseF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseF.Commands.UpdateWarehouse
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, WarehouseDto>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;


        public UpdateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseDto> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            _mapper.Map(request, warehouse);

            var updatedWarehouse = await _warehouseRepository.UpdateAsync(warehouse);

            var dto = _mapper.Map<WarehouseDto>(updatedWarehouse);

            return dto;
        }
    }
}
