using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Model { get; set; }
        public IEnumerable<CarImage>? Images { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int MinFindexScore { get; set; }
        public bool HasChildSeat { get; set; }


    }
}
