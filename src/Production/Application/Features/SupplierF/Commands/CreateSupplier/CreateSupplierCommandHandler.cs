using Application.Features.SupplierF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierF.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request);

            var addedSupplier = await _supplierRepository.AddAsync(supplier);

            var dto = _mapper.Map<SupplierDto>(addedSupplier);

            return dto;
        }
    }
}
