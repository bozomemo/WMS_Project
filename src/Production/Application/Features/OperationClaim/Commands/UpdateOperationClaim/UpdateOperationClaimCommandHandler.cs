using Application.Features.OperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.OperationClaim.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, OperationClaimWithIdDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimWithIdDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(AuthConstants.OPERATION_CLAIM_DOESNT_EXIST);

            _mapper.Map(request, operationClaim);

            var updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);

            return _mapper.Map<OperationClaimWithIdDto>(updatedOperationClaim);
        }
    }
}