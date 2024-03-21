using Application.Features.Shipment.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.Queries.GetAllActiveShipments
{
    public class GetAllActiveShipmentsQueryHandler : IRequestHandler<GetAllActiveShipmentsQuery, ICollection<ShipmentDto>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetAllActiveShipmentsQueryHandler(IMapper mapper, IShipmentRepository shipmentRepository)
        {
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ICollection<ShipmentDto>> Handle(GetAllActiveShipmentsQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentRepository.Query().Include(x => x.ShipmentItems).Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<ShipmentDto>>(shipments);

            return dtos;
        }
    }
}
