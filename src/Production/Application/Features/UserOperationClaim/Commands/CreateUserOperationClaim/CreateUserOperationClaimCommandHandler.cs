using Application.Features.UserOperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;

namespace Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, UserOperationClaimDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository,
            IOperationClaimRepository operationClaimRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
        }

        public async Task<UserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.UserId) ?? throw new BusinessException(AuthConstants.USER_DOESNT_EXIST);

            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.OperationClaimId) ?? throw new BusinessException(AuthConstants.OPERATION_CLAIM_DOESNT_EXIST);

            var userOperationClaim = new Core.Security.Entities.UserOperationClaim
            {
                User = user,
                OperationClaim = operationClaim,
            };

            var addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);

            var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);

            return userOperationClaimDto;
        }
    }
}