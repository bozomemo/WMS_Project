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

namespace Application.Features.WarehouseReceipt.Queries.GetAllWarehouseReceipts
{
    public class GetAllWarehouseReceiptsQueryHandler : IRequestHandler<GetAllWarehouseReceiptsQuery, ICollection<WarehouseReceiptDto>>
    {
        private readonly IWarehouseReceiptRepository _warehouseReceiptRepository;
        private readonly IMapper _mapper;

        public GetAllWarehouseReceiptsQueryHandler(IMapper mapper, IWarehouseReceiptRepository warehouseReceiptRepository)
        {
            _mapper = mapper;
            _warehouseReceiptRepository = warehouseReceiptRepository;
        }

        public async Task<ICollection<WarehouseReceiptDto>> Handle(GetAllWarehouseReceiptsQuery request, CancellationToken cancellationToken)
        {
            var receipts = await _warehouseReceiptRepository.Query().Include(x => x.WarehouseReceiptItems).ToListAsync();

            var dtos = _mapper.Map<List<WarehouseReceiptDto>>(receipts);

            return dtos;
        }
    }
}
