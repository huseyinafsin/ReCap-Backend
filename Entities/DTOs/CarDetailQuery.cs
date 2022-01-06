using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailFilter
    {
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }

    }
}
