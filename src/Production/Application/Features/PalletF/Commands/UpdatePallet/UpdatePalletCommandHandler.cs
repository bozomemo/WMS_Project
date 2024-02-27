using Application.Features.PalletF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Commands.UpdatePallet
{
    public class UpdatePalletCommandHandler : IRequestHandler<UpdatePalletCommand, PalletDto>
    {
        private readonly IPalletRepository _palletRepository;
        private readonly IMapper _mapper;

        public UpdatePalletCommandHandler(IMapper mapper, IPalletRepository palletRepository)
        {
            _mapper = mapper;
            _palletRepository = palletRepository;
        }

        public async Task<PalletDto> Handle(UpdatePalletCommand request, CancellationToken cancellationToken)
        {
            var pallet = await _palletRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_DOESNT_EXIST);

            _mapper.Map(request, pallet);

            var updatedPallet = await _palletRepository.UpdateAsync(pallet);

            var dto = _mapper.Map<PalletDto>(updatedPallet);

            return dto;
        }
    }
}
