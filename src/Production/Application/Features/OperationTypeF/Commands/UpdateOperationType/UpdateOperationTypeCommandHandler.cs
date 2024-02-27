using Application.Features.OperationTypeF.Dtos;
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

namespace Application.Features.OperationTypeF.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand, OperationTypeDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public UpdateOperationTypeCommandHandler(IMapper mapper, IOperationTypeRepository operationTypeRepository, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<OperationTypeDto> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.OPERATION_TYPE_DOESNT_EXIST);

            _ = await _warehouseRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            _mapper.Map(request, operationType);

            var updatedOpType = await _operationTypeRepository.UpdateAsync(operationType);

            var dto = _mapper.Map<OperationTypeDto>(updatedOpType);

            return dto;
        }
    }
}
