using Application.Features.PalletStatus.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletStatus.Queries.GetAllPalletStatus
{
    public class GetAllPalletStatusQueryHandler : IRequestHandler<GetAllPalletStatusQuery, ICollection<PalletStatusDto>>
    {
        private readonly IPalletStatusRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPalletStatusQueryHandler(IMapper mapper, IPalletStatusRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PalletStatusDto>> Handle(GetAllPalletStatusQuery request, CancellationToken cancellationToken)
        {
            var palletStatuses = await _repository.Query().ToListAsync();

            var dtos = _mapper.Map<List<PalletStatusDto>>(palletStatuses);

            return dtos;
        }
    }
}
