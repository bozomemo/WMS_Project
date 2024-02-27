using Application.Features.SupplierF.Dtos;
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

namespace Application.Features.SupplierF.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.SUPPLIER_DOESNT_EXIST);

            var dto = _mapper.Map<SupplierDto>(supplier);

            return dto;
        }
    }
}
