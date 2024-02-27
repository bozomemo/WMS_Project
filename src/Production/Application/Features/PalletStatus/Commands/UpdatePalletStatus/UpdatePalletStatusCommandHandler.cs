using Application.Features.PalletStatus.Dtos;
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

namespace Application.Features.PalletStatus.Commands.UpdatePalletStatus
{
    public class UpdatePalletStatusCommandHandler : IRequestHandler<UpdatePalletStatusCommand, PalletStatusDto>
    {
        private readonly IPalletStatusRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePalletStatusCommandHandler(IMapper mapper, IPalletStatusRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PalletStatusDto> Handle(UpdatePalletStatusCommand request, CancellationToken cancellationToken)
        {
            var palletStatus = await _repository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_STATUS_DOESNT_EXIST);

            _mapper.Map(request, palletStatus);

            var updatedStatus = await _repository.UpdateAsync(palletStatus);

            var dto = _mapper.Map<PalletStatusDto>(updatedStatus);

            return dto;
        }
    }
}
