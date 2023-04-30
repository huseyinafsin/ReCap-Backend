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
        public Guid GearTypeId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid CarTypeId { get; set; }
        public string  Model { get; set; }
        public string Description { get; set; }
        public int MinFindexScore { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual GearType GearType { get; set; }
        public virtual CarType CarType { get; set; }
    }
}
