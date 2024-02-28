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

namespace Application.Features.CartonF.Commands.DeleteCarton
{
    public class DeleteCartonCommandHandler : IRequestHandler<DeleteCartonCommand, CartonDto>
    {
        private readonly ICartonRepository _cartonRepository;
        private readonly IMapper _mapper;

        public DeleteCartonCommandHandler(IMapper mapper, ICartonRepository cartonRepository)
        {
            _mapper = mapper;
            _cartonRepository = cartonRepository;
        }

        public async Task<CartonDto> Handle(DeleteCartonCommand request, CancellationToken cancellationToken)
        {
            var carton = await _cartonRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.CARTON_DOESNT_EXIST);

            var deletedCarton = await _cartonRepository.DeleteAsync(carton);

            var dto = _mapper.Map<CartonDto>(deletedCarton);

            return dto;
        }
    }
}
