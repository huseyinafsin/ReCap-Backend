using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{

    public class CarImage : BaseEntity
    {

        public Guid CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public virtual Car Car { get; set; }


    }
}
