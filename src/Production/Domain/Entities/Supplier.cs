using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Supplier : Entity
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}