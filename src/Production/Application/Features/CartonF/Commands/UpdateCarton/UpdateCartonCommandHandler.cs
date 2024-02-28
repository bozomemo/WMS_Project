using Application.Features.CartonF.Dtos;
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

namespace Application.Features.CartonF.Commands.UpdateCarton
{
    public class UpdateCartonCommandHandler : IRequestHandler<UpdateCartonCommand, CartonDto>
    {
        private readonly ICartonRepository _cartonRepository;
        private readonly IMapper _mapper;

        public UpdateCartonCommandHandler(IMapper mapper, ICartonRepository cartonRepository)
        {
            _mapper = mapper;
            _cartonRepository = cartonRepository;
        }

        public async Task<CartonDto> Handle(UpdateCartonCommand request, CancellationToken cancellationToken)
        {
            var carton = await _cartonRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.CARTON_DOESNT_EXIST);

            _mapper.Map(request, carton);

            var updatedCarton = await _cartonRepository.UpdateAsync(carton);

            var dto = _mapper.Map<CartonDto>(updatedCarton);

            return dto;
        }
    }
}
