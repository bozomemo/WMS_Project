using Application.Features.SupplierF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierF.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, ICollection<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<ICollection<SupplierDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.Query().ToListAsync();

            var dtos = _mapper.Map<List<SupplierDto>>(suppliers);

            return dtos;
        }
    }
}
