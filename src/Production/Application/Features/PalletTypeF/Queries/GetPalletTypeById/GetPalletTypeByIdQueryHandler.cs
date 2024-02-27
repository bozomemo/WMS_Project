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

namespace Application.Features.PalletTypeF.Queries.GetPalletTypeById
{
    public class GetPalletTypeByIdQueryHandler : IRequestHandler<GetPalletTypeByIdQuery, PalletTypeDto>
    {
        private readonly IPalletTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetPalletTypeByIdQueryHandler(IMapper mapper, IPalletTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PalletTypeDto> Handle(GetPalletTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var palletType = await _repository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_TYPE_DOESNT_EXIST);

            var dto = _mapper.Map<PalletTypeDto>(palletType);

            return dto;
        }
    }
}
