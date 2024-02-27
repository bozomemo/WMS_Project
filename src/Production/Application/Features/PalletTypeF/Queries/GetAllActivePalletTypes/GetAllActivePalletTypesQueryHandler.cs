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

namespace Application.Features.PalletTypeF.Queries.GetAllActivePalletTypes
{
    public class GetAllActivePalletTypesQueryHandler : IRequestHandler<GetAllActivePalletTypesQuery, ICollection<PalletTypeDto>>
    {
        private readonly IPalletTypeRepository _palletTypeRepository;
        private readonly IMapper _mapper;

        public GetAllActivePalletTypesQueryHandler(IMapper mapper, IPalletTypeRepository palletTypeRepository)
        {
            _mapper = mapper;
            _palletTypeRepository = palletTypeRepository;
        }

        public async Task<ICollection<PalletTypeDto>> Handle(GetAllActivePalletTypesQuery request, CancellationToken cancellationToken)
        {
            var palletTypes = await _palletTypeRepository.Query().Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<PalletTypeDto>>(palletTypes);

            return dtos;
        }
    }
}
