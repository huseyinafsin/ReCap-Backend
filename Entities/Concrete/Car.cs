using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : BaseEntity
    {   

        public string CarName { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public int ModelYear { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal DaiyPrice { get; set; }
        public string  Model { get; set; }
        public string Description { get; set; }
        public int MinFindexScore { get; set; }
    }
}
