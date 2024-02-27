using Application.Features.WarehouseF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseF.Queries.GetAllWarehouses
{
    public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, ICollection<WarehouseDto>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllWarehousesQueryHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ICollection<WarehouseDto>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _warehouseRepository.Query().ToListAsync();

            var dtos = _mapper.Map<List<WarehouseDto>>(warehouses);

            return dtos;
        }
    }
}
