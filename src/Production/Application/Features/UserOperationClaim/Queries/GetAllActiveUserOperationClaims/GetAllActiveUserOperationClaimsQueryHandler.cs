using Application.Features.UserOperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Queries.GetAllActiveUserOperationClaims
{
    public class GetAllActiveUserOperationClaimsQueryHandler : IRequestHandler<GetAllActiveUserOperationClaimsQuery, ICollection<UserOperationClaimDto>>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetAllActiveUserOperationClaimsQueryHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<ICollection<UserOperationClaimDto>> Handle(GetAllActiveUserOperationClaimsQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimRepository.Query().Include(x => x.User).Include(x => x.OperationClaim).Where(x => x.IsActive).ToListAsync();

            var userOperationClaimsDto = _mapper.Map<ICollection<UserOperationClaimDto>>(userOperationClaims);

            return userOperationClaimsDto;
        }
    }
}
