using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.Dtos
{
    public class PalletDto
    {
        public string? Barcode { get; set; }

        public string? Description { get; set; }

        public int SupplierId { get; set; }

        public List<Carton> Cartons { get; set; }

        public int ZoneId { get; set; }

        public int StatusId { get; set; }

        public int PalletTypeId { get; set; }
    }
}
