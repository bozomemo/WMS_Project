using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class PalletType : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}