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

namespace Application.Features.SupplierF.Queries.GetAllActiveSuppliers
{
    public class GetAllActiveSuppliersQueryHandler : IRequestHandler<GetAllActiveSuppliersQuery, ICollection<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllActiveSuppliersQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<ICollection<SupplierDto>> Handle(GetAllActiveSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.Query().Where(x => x.IsActive).ToListAsync();

            var suppliersDto = _mapper.Map<List<SupplierDto>>(suppliers);

            return suppliersDto;
        }
    }
}
