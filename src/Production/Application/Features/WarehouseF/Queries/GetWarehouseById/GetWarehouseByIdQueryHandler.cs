using Application.Features.WarehouseF.Dtos;
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

namespace Application.Features.WarehouseF.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseDto>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetWarehouseByIdQueryHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseDto> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_DOESNT_EXIST);

            var dto = _mapper.Map<WarehouseDto>(warehouse);

            return dto;
        }
    }
}
