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

namespace Application.Features.PalletF.Commands.DeletePallet
{
    public class DeletePalletCommandHandler : IRequestHandler<DeletePalletCommand, PalletDto>
    {
        private readonly IPalletRepository _repository;
        private readonly IMapper _mapper;

        public DeletePalletCommandHandler(IMapper mapper, IPalletRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        async Task<PalletDto> IRequestHandler<DeletePalletCommand, PalletDto>.Handle(DeletePalletCommand request, CancellationToken cancellationToken)
        {
            var pallet = await _repository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_DOESNT_EXIST);

            var deletedPallet = await _repository.DeleteAsync(pallet);

            var dto = _mapper.Map<PalletDto>(deletedPallet);

            return dto;
        }
    }
}
