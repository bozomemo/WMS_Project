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

namespace Application.Features.CartonF.Queries.GetCartonById
{
    public class GetCartonByIdQueryHandler : IRequestHandler<GetCartonByIdQuery, CartonDto>
    {
        private readonly ICartonRepository _cartonRepository;
        private readonly IMapper _mapper;

        public GetCartonByIdQueryHandler(IMapper mapper, ICartonRepository cartonRepository)
        {
            _mapper = mapper;
            _cartonRepository = cartonRepository;
        }

        public async Task<CartonDto> Handle(GetCartonByIdQuery request, CancellationToken cancellationToken)
        {
            var carton = await _cartonRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.CARTON_DOESNT_EXIST);

            var dto = _mapper.Map<CartonDto>(carton);

            return dto;
        }
    }
}
