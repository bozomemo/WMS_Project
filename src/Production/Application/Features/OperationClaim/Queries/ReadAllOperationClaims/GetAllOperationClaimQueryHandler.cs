using Application.Features.OperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Queries.ReadAllOperationClaims
{
    public class GetAllOperationClaimQueryHandler : IRequestHandler<GetAllOperationClaimQuery, ICollection<OperationClaimWithIdDto>>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetAllOperationClaimQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<ICollection<OperationClaimWithIdDto>> Handle(GetAllOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operationClaims = await _operationClaimRepository.Query().ToListAsync();

            return _mapper.Map<List<OperationClaimWithIdDto>>(operationClaims);
        }
    }
}
