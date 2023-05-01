using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Language", Schema = "system")]
    public class Language : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }

}
