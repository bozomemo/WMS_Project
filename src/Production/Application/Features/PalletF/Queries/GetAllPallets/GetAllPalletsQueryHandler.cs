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

namespace Application.Features.PalletF.Queries.GetAllPallets
{
    public class GetAllPalletsQueryHandler : IRequestHandler<GetAllPalletsQuery, ICollection<PalletDto>>
    {
        private readonly IPalletRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPalletsQueryHandler(IMapper mapper, IPalletRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PalletDto>> Handle(GetAllPalletsQuery request, CancellationToken cancellationToken)
        {
            var pallets = await _repository.Query().ToListAsync(cancellationToken: cancellationToken);

            var dtos = _mapper.Map<List<PalletDto>>(pallets);

            return dtos;
        }
    }
}
