using Application.Features.WarehouseF.Dtos;
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

namespace Application.Features.WarehouseF.Commands.DeleteWarehouse
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, WarehouseDto>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public DeleteWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseDto> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            var deletedWarehouse = await _warehouseRepository.DeleteAsync(warehouse);

            var dto = _mapper.Map<WarehouseDto>(deletedWarehouse);

            return dto;
        }
    }
}
