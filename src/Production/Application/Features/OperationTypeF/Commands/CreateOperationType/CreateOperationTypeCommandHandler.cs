using Application.Features.OperationTypeF.Dtos;
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

namespace Application.Features.OperationTypeF.Commands.CreateOperationType
{
    public class CreateOperationTypeCommandHandler : IRequestHandler<CreateOperationTypeCommand, OperationTypeDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public CreateOperationTypeCommandHandler(IMapper mapper, IOperationTypeRepository operationTypeRepository, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<OperationTypeDto> Handle(CreateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = _mapper.Map<OperationType>(request);

            _ = await _warehouseRepository.GetAsync(x => x.Id == request.WarehouseId) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            var addedOpType = await _operationTypeRepository.AddAsync(operationType);

            var dto = _mapper.Map<OperationTypeDto>(addedOpType);

            return dto;
        }
    }
}
