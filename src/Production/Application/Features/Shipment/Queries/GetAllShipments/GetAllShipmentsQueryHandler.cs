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

namespace Application.Features.Shipment.Queries.GetAllShipments
{
    public class GetAllShipmentsQueryHandler : IRequestHandler<GetAllShipmentsQuery, ICollection<ShipmentDto>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetAllShipmentsQueryHandler(IMapper mapper, IShipmentRepository shipmentRepository)
        {
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ICollection<ShipmentDto>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentRepository.Query().Include(x => x.ShipmentItems).ToListAsync();

            var dtos = _mapper.Map<List<ShipmentDto>>(shipments);

            return dtos;
        }
    }
}
