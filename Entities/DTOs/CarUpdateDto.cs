using Core.Entities;
using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarUpdateDto : IDto
    {

        public Guid Id { get; set; }
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

        public IEnumerable<CarImage> Images { get; set; }

    }
}
