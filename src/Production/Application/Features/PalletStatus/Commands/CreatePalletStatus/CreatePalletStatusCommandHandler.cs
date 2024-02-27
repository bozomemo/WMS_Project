using Application.Features.PalletStatus.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletStatus.Commands.CreatePalletStatus
{
    public class CreatePalletStatusCommandHandler : IRequestHandler<CreatePalletStatusCommand, PalletStatusDto>
    {
        private readonly IPalletStatusRepository _palletStatusRepository;
        private readonly IMapper _mapper;

        public CreatePalletStatusCommandHandler(IMapper mapper, IPalletStatusRepository palletStatusRepository)
        {
            _mapper = mapper;
            _palletStatusRepository = palletStatusRepository;
        }

        public async Task<PalletStatusDto> Handle(CreatePalletStatusCommand request, CancellationToken cancellationToken)
        {
            var palletStatus = _mapper.Map<Domain.Entities.PalletStatus>(request);

            var addedPalletStatus = await _palletStatusRepository.AddAsync(palletStatus);

            var dto = _mapper.Map<PalletStatusDto>(addedPalletStatus);

            return dto;
        }
    }
}
