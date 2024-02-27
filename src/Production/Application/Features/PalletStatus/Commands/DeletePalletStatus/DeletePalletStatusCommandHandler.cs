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

namespace Application.Features.PalletStatus.Commands.DeletePalletStatus
{
    public class DeletePalletStatusCommandHandler : IRequestHandler<DeletePalletStatusCommand, PalletStatusDto>
    {
        private readonly IPalletStatusRepository _repository;
        private readonly IMapper _mapper;

        public DeletePalletStatusCommandHandler(IMapper mapper, IPalletStatusRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PalletStatusDto> Handle(DeletePalletStatusCommand request, CancellationToken cancellationToken)
        {
            var palletStatus = await _repository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_STATUS_DOESNT_EXIST);

            var deletedPs = await _repository.DeleteAsync(palletStatus);

            var dto = _mapper.Map<PalletStatusDto>(deletedPs);

            return dto;
        }
    }
}
