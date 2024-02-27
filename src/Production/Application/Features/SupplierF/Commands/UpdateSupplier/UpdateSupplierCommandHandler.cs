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

namespace Application.Features.SupplierF.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.SUPPLIER_DOESNT_EXIST);

            _mapper.Map(request, supplier);

            var updatedSupplier = await _supplierRepository.UpdateAsync(supplier);

            var dto = _mapper.Map<SupplierDto>(updatedSupplier);

            return dto;
        }
    }
}
