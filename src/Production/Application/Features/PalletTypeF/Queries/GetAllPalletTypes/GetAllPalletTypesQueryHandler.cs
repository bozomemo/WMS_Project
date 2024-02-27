using Application.Features.PalletTypeF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletTypeF.Queries.GetAllPalletTypes
{
    public class GetAllPalletTypesQueryHandler : IRequestHandler<GetAllPalletTypesQuery, ICollection<PalletTypeDto>>
    {
        private readonly IPalletTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPalletTypesQueryHandler(IMapper mapper, IPalletTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PalletTypeDto>> Handle(GetAllPalletTypesQuery request, CancellationToken cancellationToken)
        {
            var palletTypes = await _repository.Query().ToListAsync();

            var dtos = _mapper.Map<List<PalletTypeDto>>(palletTypes);

            return dtos;
        }
    }
}
