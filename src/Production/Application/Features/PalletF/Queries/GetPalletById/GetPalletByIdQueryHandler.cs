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

namespace Application.Features.PalletF.Queries.GetPalletById
{
    public class GetPalletByIdQueryHandler : IRequestHandler<GetPalletByIdQuery, PalletDto>
    {
        private readonly IPalletRepository _palletRepository;
        private readonly IMapper _mapper;

        public GetPalletByIdQueryHandler(IMapper mapper, IPalletRepository palletRepository)
        {
            _mapper = mapper;
            _palletRepository = palletRepository;
        }

        public async Task<PalletDto> Handle(GetPalletByIdQuery request, CancellationToken cancellationToken)
        {
            var pallet = await _palletRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_DOESNT_EXIST);

            var dto = _mapper.Map<PalletDto>(pallet);

            return dto;
        }
    }
}
