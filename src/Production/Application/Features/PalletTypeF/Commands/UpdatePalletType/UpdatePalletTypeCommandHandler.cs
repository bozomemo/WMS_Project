using Application.Features.PalletTypeF.Dtos;
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

namespace Application.Features.PalletTypeF.Commands.UpdatePalletType
{
    public class UpdatePalletTypeCommandHandler : IRequestHandler<UpdatePalletTypeCommand, PalletTypeDto>
    {
        private readonly IPalletTypeRepository _palletTypeRepository;
        private readonly IMapper _mapper;

        public UpdatePalletTypeCommandHandler(IMapper mapper, IPalletTypeRepository palletTypeRepository)
        {
            _mapper = mapper;
            _palletTypeRepository = palletTypeRepository;
        }

        public async Task<PalletTypeDto> Handle(UpdatePalletTypeCommand request, CancellationToken cancellationToken)
        {
            var palletType = await _palletTypeRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_TYPE_DOESNT_EXIST);

            _mapper.Map(request, palletType);

            var updatedPalletType = await _palletTypeRepository.UpdateAsync(palletType);

            var dto = _mapper.Map<PalletTypeDto>(updatedPalletType);

            return dto;
        }
    }
}
