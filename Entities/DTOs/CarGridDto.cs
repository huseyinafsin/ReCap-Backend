using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class CarGridDto : IDto
    {
        public Guid Id { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public string Gear { get; set; }
        public string CarType { get; set; }
        public string Fuel { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int MinFindexScore { get; set; }
    }
}
