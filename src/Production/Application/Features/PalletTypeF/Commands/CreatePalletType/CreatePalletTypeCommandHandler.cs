using Application.Features.PalletTypeF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletTypeF.Commands.CreatePalletType
{
    public class CreatePalletTypeCommandHandler : IRequestHandler<CreatePalletTypeCommand, PalletTypeDto>
    {
        private readonly IPalletTypeRepository _repository;
        private readonly IMapper _mapper;

        public CreatePalletTypeCommandHandler(IMapper mapper, IPalletTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PalletTypeDto> Handle(CreatePalletTypeCommand request, CancellationToken cancellationToken)
        {
            var palletType = _mapper.Map<PalletType>(request);

            var addedPalletType = await _repository.AddAsync(palletType);

            var dto = _mapper.Map<PalletTypeDto>(addedPalletType);

            return dto;
        }
    }
}
