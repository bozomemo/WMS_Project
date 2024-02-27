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

namespace Application.Features.OperationTypeF.Queries.GetAllOperationTypes
{
    public class GetAllOperationTypesQueryHandler : IRequestHandler<GetAllOperationTypesQuery, ICollection<OperationTypeDto>>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;

        public GetAllOperationTypesQueryHandler(IMapper mapper, IOperationTypeRepository operationTypeRepository)
        {
            _mapper = mapper;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<ICollection<OperationTypeDto>> Handle(GetAllOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var opTypes = await _operationTypeRepository.Query().ToListAsync();

            var opTypesDto = _mapper.Map<List<OperationTypeDto>>(opTypes);

            return opTypesDto;
        }
    }
}
