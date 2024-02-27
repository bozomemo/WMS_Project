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

namespace Application.Features.WarehouseF.Queries.GetAllActiveWarehouses
{
    public class GetAllActiveWarehousesQueryHandler : IRequestHandler<GetAllActiveWarehousesQuery, ICollection<WarehouseDto>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllActiveWarehousesQueryHandler(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ICollection<WarehouseDto>> Handle(GetAllActiveWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _warehouseRepository.Query().Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<WarehouseDto>>(warehouses);

            return dtos;
        }
    }
}
