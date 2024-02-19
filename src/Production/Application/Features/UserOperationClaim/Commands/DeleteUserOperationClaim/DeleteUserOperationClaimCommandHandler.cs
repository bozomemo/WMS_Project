using Application.Features.UserOperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, EntityIdDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<EntityIdDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id && x.IsActive) ?? 
                throw new BusinessException(AuthConstants.USER_OPERATION_CLAIM_DOESNT_EXIST);

            var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

            var entityIdDto = _mapper.Map<EntityIdDto>(deletedUserOperationClaim);

            return entityIdDto;
        }
    }
}
