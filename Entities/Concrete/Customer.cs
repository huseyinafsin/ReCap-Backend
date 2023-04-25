using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Customer: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid LanguageId { get; set; }

        public string CompanyName { get; set; }
        public int FindexScore { get; set; }
        public virtual Language Language { get; set; }

    }
}
