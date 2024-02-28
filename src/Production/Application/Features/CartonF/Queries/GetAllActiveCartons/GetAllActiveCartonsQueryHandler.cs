using Application.Features.CartonF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.Queries.GetAllActiveCartons
{
    public class GetAllActiveCartonsQueryHandler : IRequestHandler<GetAllActiveCartonsQuery, ICollection<CartonDto>>
    {
        private readonly ICartonRepository _cartonRepository;
        private readonly IMapper _mapper;

        public GetAllActiveCartonsQueryHandler(IMapper mapper, ICartonRepository cartonRepository)
        {
            _mapper = mapper;
            _cartonRepository = cartonRepository;
        }

        public async Task<ICollection<CartonDto>> Handle(GetAllActiveCartonsQuery request, CancellationToken cancellationToken)
        {
            var cartons = await _cartonRepository.Query().Where(x => x.IsActive).ToListAsync(cancellationToken: cancellationToken);

            var dtos = _mapper.Map<List<CartonDto>>(cartons);

            return dtos;
        }
    }
}
