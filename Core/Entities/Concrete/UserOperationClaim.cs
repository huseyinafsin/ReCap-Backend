using System;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
