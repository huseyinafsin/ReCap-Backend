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
    [Table("FuelType", Schema = "system")]
    public class FuelType: BaseEntity
    {

        public string Name { get; set; }
    }


}
