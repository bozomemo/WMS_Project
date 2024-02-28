using Application.Features.CartonF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.Commands.CreateCarton
{
    public class CreateCartonCommandHandler : IRequestHandler<CreateCartonCommand, CartonDto>
    {
        private readonly IPalletRepository _palletRepository;
        private readonly ICartonRepository _cartonRepository;
        private readonly IMapper _mapper;

        public CreateCartonCommandHandler(IMapper mapper, ICartonRepository cartonRepository, IPalletRepository palletRepository)
        {
            _mapper = mapper;
            _cartonRepository = cartonRepository;
            _palletRepository = palletRepository;
        }

        public async Task<CartonDto> Handle(CreateCartonCommand request, CancellationToken cancellationToken)
        {
            _ = await _palletRepository.GetAsync(x => x.Id == request.PalletId) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_DOESNT_EXIST);

            var carton = _mapper.Map<Carton>(request);

            var addedCarton = await _cartonRepository.AddAsync(carton);

            var dto = _mapper.Map<CartonDto>(carton);

            return dto;
        }
    }
}
