using Application.Features.OperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.OperationClaim.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, OperationClaimWithIdDto>
    {
        public readonly IOperationClaimRepository _operationClaimRepository;
        public readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimWithIdDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id && x.IsActive) ?? throw new BusinessException(AuthConstants.OPERATION_CLAIM_DOESNT_EXIST);

            var deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);

            return _mapper.Map<OperationClaimWithIdDto>(deletedOperationClaim);
        }
    }
}