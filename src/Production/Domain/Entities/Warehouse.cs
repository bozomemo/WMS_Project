using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Warehouse : Entity
    {
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public virtual List<Zone>? Zones { get; set; }
    }
}