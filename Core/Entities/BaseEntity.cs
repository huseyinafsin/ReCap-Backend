using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BaseEntity : IEntity
    {
        
        public Guid Id { get; set; }
        public Guid InsertedUserId { get; set; }
        public Guid? UpdatedUserId { get; set; }

        public DateTime InsertedAt { get; set; } =DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Deleted { get; set; } = false;



    }
}
