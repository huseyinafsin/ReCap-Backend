using Core.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarCreateDto : IDto
    {

        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public Guid CarTypeId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid GearTypeId { get; set; }
        public Guid InsertedUserId { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int MinFindexScore { get; set; }

    }
}
