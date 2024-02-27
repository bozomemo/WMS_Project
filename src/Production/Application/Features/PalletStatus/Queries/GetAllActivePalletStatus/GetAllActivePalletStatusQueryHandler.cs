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

namespace Application.Features.PalletStatus.Queries.GetAllActivePalletStatus
{
    public class GetAllActivePalletStatusQueryHandler : IRequestHandler<GetAllActivePalletStatusQuery, ICollection<PalletStatusDto>>
    {
        private readonly IPalletStatusRepository _repository;
        private readonly IMapper _mapper;

        public GetAllActivePalletStatusQueryHandler(IMapper mapper, IPalletStatusRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PalletStatusDto>> Handle(GetAllActivePalletStatusQuery request, CancellationToken cancellationToken)
        {
            var palletStatuses = await _repository.Query().Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<PalletStatusDto>>(palletStatuses);

            return dtos;
        }
    }
}
