using Application.Features.PalletF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Queries.GetAllActivePallets
{
    public class GetAllActivePalletsQueryHandler : IRequestHandler<GetAllActivePalletsQuery, ICollection<PalletDto>>
    {
        private readonly IPalletRepository _repository;
        private readonly IMapper _mapper;

        public GetAllActivePalletsQueryHandler(IMapper mapper, IPalletRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PalletDto>> Handle(GetAllActivePalletsQuery request, CancellationToken cancellationToken)
        {
            var pallets = await _repository.Query().Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<PalletDto>>(pallets);

            return dtos;
        }
    }
}
