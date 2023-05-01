using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("CarType", Schema = "system")]
    public class CarType: BaseEntity
    {

        public string Name { get; set; }
    }


}
