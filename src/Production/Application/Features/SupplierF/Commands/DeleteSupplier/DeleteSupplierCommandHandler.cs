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

namespace Application.Features.SupplierF.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public DeleteSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.SUPPLIER_DOESNT_EXIST);

            var deletedSupplier = await _supplierRepository.DeleteAsync(supplier);

            var dto = _mapper.Map<SupplierDto>(deletedSupplier);

            return dto;
        }
    }
}
