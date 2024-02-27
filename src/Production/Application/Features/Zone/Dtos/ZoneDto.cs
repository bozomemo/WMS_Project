using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.Dtos
{
    public class ZoneDto
    {
        public string ZoneCode { get; set; }

        public string? Description { get; set; }

        public int? WarehouseId { get; set; }

        public bool IsBin { get; set; }
    }
}
