using Application.Features.WarehouseReceipt.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Queries.GetWarehouseReceiptById
{
    public class GetWarehouseReceiptByIdQueryHandler : IRequestHandler<GetWarehouseReceiptByIdQuery, WarehouseReceiptDto>
    {
        private readonly IWarehouseItemRepository _warehouseReceiptItemRepository;
        private readonly IWarehouseReceiptRepository _warehouseReceiptRepository;
        private readonly IMapper _mapper;

        public GetWarehouseReceiptByIdQueryHandler(IMapper mapper, IWarehouseReceiptRepository warehouseReceiptRepository, IWarehouseItemRepository warehouseReceiptItemRepository)
        {
            _mapper = mapper;
            _warehouseReceiptRepository = warehouseReceiptRepository;
            _warehouseReceiptItemRepository = warehouseReceiptItemRepository;
        }

        public async Task<WarehouseReceiptDto> Handle(GetWarehouseReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var receipt = await _warehouseReceiptRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_RECEIPT_DOESNT_EXIST);

            var items = await _warehouseReceiptItemRepository.Query().Where(x => x.IsActive && x.WarehouseReceiptId == receipt.Id).ToListAsync(cancellationToken: cancellationToken);

            receipt.WarehouseReceiptItems = items;

            var dto = _mapper.Map<WarehouseReceiptDto>(receipt);

            return dto;
        }
    }
}
