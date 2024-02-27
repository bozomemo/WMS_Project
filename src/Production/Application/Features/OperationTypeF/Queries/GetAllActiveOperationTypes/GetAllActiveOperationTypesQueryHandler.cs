using Application.Features.OperationTypeF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationTypeF.Queries.GetAllActiveOperationTypes
{
    public class GetAllActiveOperationTypesQueryHandler : IRequestHandler<GetAllActiveOperationTypesQuery, ICollection<OperationTypeDto>>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;

        public GetAllActiveOperationTypesQueryHandler(IMapper mapper, IOperationTypeRepository operationTypeRepository)
        {
            _mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<ICollection<OperationTypeDto>> Handle(GetAllActiveOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var opTypes = await _operationTypeRepository.Query().Where(x => x.IsActive).ToListAsync();

            var opTypesDto = _mapper.Map<List<OperationTypeDto>>(opTypes);

            return opTypesDto;
        }
    }
}
