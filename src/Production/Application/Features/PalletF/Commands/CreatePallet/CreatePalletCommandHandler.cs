using Application.Features.PalletF.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Commands.CreatePallet
{
    public class CreatePalletCommandHandler : IRequestHandler<CreatePalletCommand, PalletDto>
    {
        private readonly IPalletRepository _palletRepository;
        private readonly IPalletStatusRepository _palletStatusRepository;
        private readonly IPalletTypeRepository _palletTypeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;

        public CreatePalletCommandHandler(IMapper mapper, IPalletRepository palletRepository, ISupplierRepository supplierRepository, 
            IZoneRepository zoneRepository, IPalletStatusRepository palletStatusRepository, IPalletTypeRepository palletTypeRepository)
        {
            _mapper = mapper;
            _palletRepository = palletRepository;
            _supplierRepository = supplierRepository;
            _zoneRepository = zoneRepository;
            _palletStatusRepository = palletStatusRepository;
            _palletTypeRepository = palletTypeRepository;
        }

        public async Task<PalletDto> Handle(CreatePalletCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetAsync(x => x.Id == request.SupplierId) ?? throw new BusinessException(BusinessExceptionConstants.SUPPLIER_DOESNT_EXIST);

            var zone = await _zoneRepository.GetAsync(x => x.Id == request.ZoneId) ?? throw new BusinessException(BusinessExceptionConstants.ZONE_DOESNT_EXIST);

            var palletStatus = await _palletStatusRepository.GetAsync(x => x.Id == request.StatusId) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_STATUS_DOESNT_EXIST);

            var palletType = await _palletTypeRepository.GetAsync(x => x.Id == request.PalletTypeId) ?? throw new BusinessException(BusinessExceptionConstants.PALLET_TYPE_DOESNT_EXIST);

            var pallet = _mapper.Map<Pallet>(request);

            var addedPallet = await _palletRepository.AddAsync(pallet);

            var dto = _mapper.Map<PalletDto>(addedPallet);

            return dto;
        }
    }
}
