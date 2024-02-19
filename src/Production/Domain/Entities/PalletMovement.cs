using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class PalletMovement : Entity
    {
        public int PalletId { get; set; }

        public int SourceZoneId { get; set; }

        public int DestinationZoneId { get; set; }

        public int OperationTypeId { get; set; }
        public virtual OperationType OperationType { get; set; }

        public int PerformedByUserId { get; set; }
    }
}