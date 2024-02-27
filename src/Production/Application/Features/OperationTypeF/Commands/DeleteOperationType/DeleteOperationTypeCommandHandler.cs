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

namespace Application.Features.OperationTypeF.Commands.DeleteOperationType
{
    public class DeleteOperationTypeCommandHandler : IRequestHandler<DeleteOperationTypeCommand, OperationTypeDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;

        public DeleteOperationTypeCommandHandler(IMapper mapper, IOperationTypeRepository operationTypeRepository)
        {
            _mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<OperationTypeDto> Handle(DeleteOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var opType = await _operationTypeRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.OPERATION_TYPE_DOESNT_EXIST);

            var deletedOpType = await _operationTypeRepository.DeleteAsync(opType);

            var dto = _mapper.Map<OperationTypeDto>(deletedOpType);

            return dto;
        }
    }
}
