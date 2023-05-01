using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    [Table("Page", Schema = "system")]
    public class Page : BaseEntity
    {

        public string Name { get; set; }
    }

    [Table("Menu", Schema = "system")]
    public class Menu : BaseEntity
    {

        public string Name { get; set; }
    }
}
