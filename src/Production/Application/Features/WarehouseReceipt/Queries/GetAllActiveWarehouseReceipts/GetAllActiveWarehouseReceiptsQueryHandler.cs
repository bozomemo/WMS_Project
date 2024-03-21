using Application.Features.WarehouseReceipt.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Queries.GetAllActiveWarehouseReceipts
{
    public class GetAllActiveWarehouseReceiptsQueryHandler : IRequestHandler<GetAllActiveWarehouseReceiptsQuery, ICollection<WarehouseReceiptDto>>
    {
        private readonly IWarehouseReceiptRepository _warehouseReceiptRepository;
        private readonly IMapper _mapper;

        public GetAllActiveWarehouseReceiptsQueryHandler(IMapper mapper, IWarehouseReceiptRepository warehouseReceiptRepository)
        {
            _mapper = mapper;
            _warehouseReceiptRepository = warehouseReceiptRepository;
        }

        public async Task<ICollection<WarehouseReceiptDto>> Handle(GetAllActiveWarehouseReceiptsQuery request, CancellationToken cancellationToken)
        {
            var warehouseReceipts = await _warehouseReceiptRepository.Query().Include(x => x.WarehouseReceiptItems).Where(x => x.IsActive).ToListAsync();

            var dtos = _mapper.Map<List<WarehouseReceiptDto>>(warehouseReceipts);

            return dtos;
        }
    }
}
