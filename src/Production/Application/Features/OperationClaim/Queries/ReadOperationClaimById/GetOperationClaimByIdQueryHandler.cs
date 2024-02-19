using Application.Features.OperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.OperationClaim.Queries.ReadOperationClaimById
{
    public class GetOperationClaimByIdQueryHandler : IRequestHandler<GetOperationClaimByIdQuery, OperationClaimWithIdDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetOperationClaimByIdQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimWithIdDto> Handle(GetOperationClaimByIdQuery request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id && x.IsActive) ?? throw new BusinessException(AuthConstants.OPERATION_CLAIM_DOESNT_EXIST);

            var operationClaimDto = _mapper.Map<OperationClaimWithIdDto>(operationClaim);

            return operationClaimDto;
        }
    }
}