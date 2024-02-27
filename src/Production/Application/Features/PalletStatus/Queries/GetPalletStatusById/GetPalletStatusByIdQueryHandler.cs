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

namespace Application.Features.PalletStatus.Queries.GetPalletStatusById
{
    public class GetPalletStatusByIdQueryHandler : IRequestHandler<GetPalletStatusByIdQuery, PalletStatusDto>
    {
        private readonly IPalletStatusRepository _palletStatusRepository;
        private readonly IMapper _mapper;


        public GetPalletStatusByIdQueryHandler(IMapper mapper, IPalletStatusRepository palletStatusRepository)
        {
            _mapper = mapper;
            _palletStatusRepository = palletStatusRepository;
        }

        public async Task<PalletStatusDto> Handle(GetPalletStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var palletStatus = await _palletStatusRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_STATUS_DOESNT_EXIST);

            var dto = _mapper.Map<PalletStatusDto>(palletStatus);

            return dto;
        }
    }
}
