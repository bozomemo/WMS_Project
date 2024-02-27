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

namespace Application.Features.PalletTypeF.Commands.DeletePalletType
{
    public class DeletePalletTypeCommandHandler : IRequestHandler<DeletePalletTypeCommand, PalletTypeDto>
    {
        private readonly IPalletTypeRepository _palletTypeRepository;
        private readonly IMapper _mapper;

        public DeletePalletTypeCommandHandler(IMapper mapper, IPalletTypeRepository palletTypeRepository)
        {
            _mapper = mapper;
            _palletTypeRepository = palletTypeRepository;
        }

        public async Task<PalletTypeDto> Handle(DeletePalletTypeCommand request, CancellationToken cancellationToken)
        {
            var palletType = await _palletTypeRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_TYPE_DOESNT_EXIST);

            var deletedPalletType = await _palletTypeRepository.DeleteAsync(palletType);

            var dto = _mapper.Map<PalletTypeDto>(deletedPalletType);

            return dto;
        }
    }
}
